using LSExtensionWindowLib;
using LSSERVICEPROVIDERLib;
using PathologResultEntry.Controls;
using ONE1_richTextCtrl;
using Patholab_Common;
using PathologDiagnosis;
using Patholab_DAL_V1;
using Patholab_DAL_V1.Enums;
using Patholab_XmlService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Path = System.IO.Path;
using Timer = System.Windows.Forms.Timer;
using HostUserControl;
using NautToEytan;
using System.Windows.Input;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using System.ComponentModel;
using PreviewLetter;
using System.Reflection;
using ExtraMaterialControl;
using Telerik.WinControls.UI.Export;
using Utils = Patholab_Common.Utils;


namespace PathologResultEntry
{
    public partial class PathologResultEntryCls : UserControl//, IExtensionWindow
    {
        #region Private fields
        private IExtensionWindowSite2 _ntlsSite;
        private INautilusServiceProvider _sp;
        private INautilusDBConnection _ntlsCon;
        private INautilusDBConnection _ntlsCon1;
        private INautilusUser _ntlsUser;
        private DataLayer _dal;
        private Timer _timerFocus = null;
        private TextTemplateCtrl templateCtrl;
        private bool _ispap = false;
        private RTF_Manger _rtfManager;
        List<WrapperRtf> _currentResults = new List<WrapperRtf>();
        private Dictionary<string, string> _genderDic;
        private Dictionary<string, string> _priorityDic;
        public bool DEBUG;
        private Timer _bckgrndSaver;
        // PathologDiagnosisWPF diagnosis;
        private bool loggedInOperatorSigned;
        SDG_DETAILS sdgDetails;
        PreviewLetterCls PreviewLetter;
        bool cngWeekNbr = false;
        public NautToEytan.RunProgram naut2eitan;
        private List<PHRASE_ENTRY> phrases = null;
        public bool resNaut;
        private List<OPERATOR> Pathologists;
        private List<OPERATOR> Cytoscariners;
        private SDG sdg;
        //private List<long> opToChangeAssociation = new List<long>() {2281,2280,2254,3029,2767 };
        private List<PHRASE_ENTRY> opToChangeAssociation = null;

        #endregion


        #region Ctor
        public PathologResultEntryCls()
        {
            InitializeComponent();
            historyCtl = new HistoryCtl
            {
                Location = new Point(0, 9),
                Margin = new Padding(6),
                Name = "historyCtl",
                Size = new Size(270, 760)
            };
            this.tabhistor.Controls.Add(historyCtl);


            BackColor = Color.FromName("Control");
            buttonOpenPortal.FlatStyle = FlatStyle.Flat;
            buttonOpenPortal.FlatAppearance.BorderSize = 1;
            buttonExtraDocuments.FlatStyle = FlatStyle.Flat;
            buttonExtraDocuments.FlatAppearance.BorderSize = 1;

            //      txtBarcodeName.Focus();
            this.Disposed += PathologResultEntryCls_Disposed;
            this.VisibleChanged += PathologResultEntryCls_VisibleChanged;


        }

        void PathologResultEntryCls_VisibleChanged(object sender, EventArgs e)
        {
            //Ashi 28/03/22
            if (_bckgrndSaver != null)
            {
                _bckgrndSaver.Stop();
            }
        }

        private void PathologResultEntryCls_Disposed(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        #endregion

        #region Initilaize
        string _currentUserName;
        string _currentUserFullName;
        long _SessionId;
        long _currentUserid;
        HistoryCtl historyCtl;
        /// <summary>
        /// From wf RE extension
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="sdgName">Sdg name</param>
        public void runByWf(INautilusServiceProvider sp, DataLayer dal)
        {
            this._sp = sp;
            this._dal = dal;

            _ntlsCon = Utils.GetNtlsCon(_sp);
            _ntlsUser = Utils.GetNautilusUser(_sp);
            btnMngr.Visible = _ntlsUser.GetRoleName().ToUpper() == "SYSTEM";
            _currentUserName = _ntlsUser.GetOperatorName();
            _SessionId = (long)_ntlsCon.GetSessionId();
            _currentUserid = (long)_ntlsUser.GetOperatorId();

            _currentUserFullName = dal.FindBy<OPERATOR>(op => op.OPERATOR_ID == _currentUserid)
                                     .Select(op => op.FULL_NAME)
                                     .FirstOrDefault();

            this.pathologDiagnosisWPF1.init(_ntlsCon);
            opToChangeAssociation = dal.GetPhraseByName("PermissionsChangeGatholog").PHRASE_ENTRY.ToList();

            Init();
            FirstFocus();
            if (!Environment.MachineName.ToUpper().Contains("ONE1"))
            {
                LoginToNaut();
            }

        }

        public void runByWfDebug(INautilusServiceProvider sp, string un, long uid)
        {
            this._sp = sp;


            //    diagnosis = new PathologDiagnosisWPF();

            if (DEBUG)
            {

                _currentUserName = un;// "lims_sys";
                _currentUserid = uid;
                this.pathologDiagnosisWPF1.DEBUG = true;
            }
            //else
            //{

            //    _currentUserName = un;// "lims_sys";
            //    _currentUserid = uid;
            //    this.pathologDiagnosisWPF1.DEBUG = true;
            //}


            //     diagnosis.init(_ntlsCon);
            this.pathologDiagnosisWPF1.init(_ntlsCon);

            Init();

            //   elementHost1.Child = diagnosis;

            FirstFocus();
        }
        public bool checkOperator(string phraseName)
        {
            try
            {
                PHRASE_ENTRY name = opToChangeAssociation.Where(x => x.PHRASE_NAME == phraseName).FirstOrDefault();
                if (name != null)
                {
                    return true;
                }
                return false;
            }

            catch (Exception e)
            {
                Logger.WriteLogFile("error in checkOperator func: " + e.Message);
                return false;
            }

        }
        public string getPhraseEntry(string phraseName)
        {
            return phrases.Find(x => x.PHRASE_NAME == phraseName).PHRASE_DESCRIPTION;
        }

        public void LoginToNaut()
        {
            try
            {
                Logger.WriteLogFile("start to connect naut2eytan");
                resNaut = false;
                if (_dal != null)
                {
                    phrases = new List<PHRASE_ENTRY>() { };
                    phrases = _dal.GetPhraseByName("Eitan Parameters").PHRASE_ENTRY.OrderBy(o => o.ORDER_NUMBER).ToList();
                    Logger.WriteLogFile("new List<PHRASE_ENTRY>()");
                    Logger.WriteLogFile("_dal.GetPhraseByName()");

                    naut2eitan = new NautToEytan.RunProgram();//new
                    Logger.WriteLogFile("success to RunProgram");

                    resNaut = naut2eitan.Join_to_Context(getPhraseEntry("Participant Name"), getPhraseEntry("Passcode"));//join

                    if (resNaut)
                    {
                        string userNaut = null;
                        var slash = @"\";
                        char[] slashArray = slash.ToCharArray();

                        if (_currentUserName != null)
                            Logger.WriteLogFile("_currentUserName is: " + _currentUserName);

                        if (_currentUserName.Contains(@"\"))
                        {
                            Logger.WriteLogFile("UserName contains slash");
                            var nautUserName = _currentUserName.Split(slashArray);
                            userNaut = nautUserName[1];
                        }
                        Logger.WriteLogFile("success to Join_to_Context");
                        resNaut = naut2eitan.Login(getPhraseEntry("Manage User Context Param Sufix"), userNaut);//login
                        if (resNaut)
                            Logger.WriteLogFile("success to Login");
                    }
                }
                else
                {
                    Logger.WriteLogFile("need start dal");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogFile("error in naut2eytan:  " + ex.Message);
            }
        }
        public void Open_Patient_File(string PatientContextParamSufix/*יוזר המחובר לנאוטילוס*/, string recentPatient/*תז פציינט*/)
        {
            try
            {
                Logger.WriteLogFile("start to Open Patient File");
                if (resNaut)
                {
                    Logger.WriteLogFile("UserName: " + PatientContextParamSufix);
                    resNaut = naut2eitan.Open_Patient_File(PatientContextParamSufix, recentPatient);
                    if (resNaut)
                    {
                        if (recentPatient != null)
                        {
                            Logger.WriteLogFile("success to Open Patient File");
                        }
                        else
                        {
                            Logger.WriteLogFile("success to close Patient File");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (recentPatient != null)
                {
                    Logger.WriteLogFile("error in Open Patient File:  " + ex.Message);
                }
                else
                {
                    Logger.WriteLogFile("error in close Patient File:  " + ex.Message);
                }
            }
        }
        public void Leave_Context()
        {
            try
            {
                if (resNaut)
                {
                    resNaut = naut2eitan.Leave_Context();
                    if (resNaut)
                    {
                        Logger.WriteLogFile("success to Leave_Context");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogFile("error in Leave_Context:  " + ex.Message);
            }
        }
        public void LoadPatient(string sdgName, DataLayer dal)
        {
            this._dal = dal;
            txtBarcodeName.Text = sdgName;


            LoadSdg();
            pathologDiagnosisWPF1.loadSdg(sdgName);

            this.ActiveControl = lblPathoName; // this line is just to remove focus from controls when loading the form later.



            //Ashi-תיקון באג של נפתח מסך פתולוג במקרה של ת.ז קצרה   - 12600 תקלה  
            string clntNme = sdgDetails.CLIENT_NAME;
            if (resNaut && clntNme.Length > 8 && sdgDetails.CLIENT_PASSPORT == "F")
            {
                string clientID = clntNme.Substring(0, 8);

                var G = getPhraseEntry("Manage User Context Param Sufix");
                Open_Patient_File(G, clientID.TrimStart(new Char[] { '0' }));
            }
            else
            {
                Logger.WriteLogFile("Eytan won't open in case of a  passport or a short Identity");
            }

        }

        public void Init()
        {
            Logger.WriteLogFile("PathologResultEntry.init");
            Logger.WriteLogFile("b4 new DataLayer()");
            _dal = new DataLayer();
            Logger.WriteLogFile("after new DataLayer()");



            if (DEBUG)
            {
                _dal.MockConnect();
                txtBarcodeName.Text = "P000003/18";
            }
            else { _dal.Connect(_ntlsCon); }
            Logger.WriteLogFile("after _dal.Connect()");

            InitilaizeData();
            InitSdgAttachments();

            InitilaizeRichSpellCtrl();
            txtBarcodeName.GotFocus += (s, e) => zLang.English();
            //setSnomed();

            ////Avigail added 12/02/24
            //historyCtl = new HistoryCtl();
            historyCtl.ItemSelected += historyCtl_ItemSelected;

            SartBckgrTimer();
        }

        private void InitSdgAttachments()
        {
            ////Avigail added 12/02/24
            //sdgSttachmentsCtrl1 = new SdgAttachments.SdgSttachmentsCtrl();
            sdgSttachmentsCtrl1.NautilusServiceProvider = this._sp;
            sdgSttachmentsCtrl1.dal = this._dal;
        }

        private ListData listData = null;
        private async void InitilaizeData()
        {

            CrateADODB_CON();

            listData = new ListData(_dal);

            try
            {
                _genderDic = _dal.GetPhraseByName("Gender").PhraseEntriesDictonary;
                _priorityDic = _dal.GetPhraseByName("Priority").PhraseEntriesDictonary;

            }
            catch (Exception exception) { Logger.WriteLogFile(exception); }
        }


        private void InitilaizeRichSpellCtrl()
        {
            //Ashi TODO
            //pathologDiagnosisWPF1.richSpellCtrls.ForEach(x => x.ExtraBtnClciked += () => RtfManager_tmcclicked(x));

            _rtfManager = new RTF_Manger(_dal, pathologDiagnosisWPF1.richTextDiagnosis,
                pathologDiagnosisWPF1.richTextMicro,
                pathologDiagnosisWPF1.richTextMacro);
            _rtfManager._result2RichText[Constants.HisMic].ExtraBtnClciked += (() => RtfManager_tmcclicked(_rtfManager._result2RichText[Constants.HisMic]));
            _rtfManager._result2RichText[Constants.HisMac].ExtraBtnClciked += (() => RtfManager_tmcclicked(_rtfManager._result2RichText[Constants.HisMac]));
            _rtfManager._result2RichText[Constants.Diag].ExtraBtnClciked += (() => RtfManager_tmcclicked(_rtfManager._result2RichText[Constants.Diag]));


        }

        #endregion

        #region Focus Timer

        private void FirstFocus()
        {
            ////First focus because nautius's bag
            //_timerFocus = new Timer { Interval = 20000 };
            //_timerFocus.Tick += timerFocus_Tick;
            //_timerFocus.Start();
            txtBarcodeName.Focus();
        }

        //void timerFocus_Tick(object sender, EventArgs e)
        //{
        //    txtBarcodeName.Focus();
        //    _timerFocus.Stop();
        //    //SaveRequest();
        //    //_timerFocus.Start();
        //    //_timerFocus.Dispose();
        //}
        #endregion


        // Displays the relevant templates that can be entered from the RichSpellCtrls in the diagnosis project.
        private void RtfManager_tmcclicked(RichSpellCtrl richSpell)
        {
            var sdg = _dal.FindBy<SDG>(s => s.SDG_ID == sdgDetails.SDG_ID).FirstOrDefault();

            if (sdg == null) return;

            string All_organs = "ALL";
            string l = sdg.NAME.Substring(0, 1).ToString();

            //If has organ get it, else get "All
            var organs4Sdg = sdg.SAMPLEs.Select(SM => SM.SAMPLE_USER.U_ORGAN ?? All_organs).Distinct().ToList();
            if (!organs4Sdg.Contains(All_organs))
                organs4Sdg.Add(All_organs);

            var organsList = (from item in _dal.GetAll<U_NLIST_USER>()
                              where item.U_SDG_TYPE == l
                              select item).ToList();

            List<U_NLIST_USER> list4Show = new List<U_NLIST_USER>();
            foreach (var item in organsList)
            {
                foreach (var org in organs4Sdg)
                {
                    if (item.U_ORGANS != null && item.U_ORGANS.Contains(org))
                    {
                        list4Show.Add(item);
                    }
                }
            }

            var organs4Show = list4Show.Select(SM => SM.U_TEXT).ToList().Distinct();
            if (organs4Show.Count() < 1)
            {

                MessageBox.Show(".לא קיימים טמפלייטים", Constants.MboxCaption, MessageBoxButtons.OK,
                          MessageBoxIcon.Hand);
                return;
            }
            templateCtrl = new TextTemplateCtrl(organs4Show);

            while (!templateCtrl.isFinished)
            {
                templateCtrl.ShowDialog();
                if (tabControl.SelectedTab != null && !string.IsNullOrEmpty(templateCtrl.SelectedText) && !templateCtrl.isFinished)
                {
                    if (richSpell != null) richSpell.AppendText(templateCtrl.SelectedText);
                }
            }
        }

        // helper for the requestRemarkControl -----> כפתור הערות
        private void CrateADODB_CON()
        {
            try
            {
                if (requestRemarkControl1 == null)
                {
                    requestRemarkControl1 = new RequestRemarkNet.RequestRemarkControl();
                }
                requestRemarkControl1.GetConnectionParams(_ntlsCon, _ntlsSite, _ntlsUser);
                requestRemarkControl1.InitializeConnection();
                requestRemarkControl1.StatusChanged += delegate
                {
                    btnAuth.Enabled = requestRemarkControl1.GetRemarkStatus(sdgDetails.SDG_NAME) != "P" && sdgDetails.STATUS != "A";
                };
            }

            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
            }
        }

        #region Events

        private void txtBarcode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                _bckgrndSaver.Stop();
                LoadSdg();
                StartBcgrnd();

            }
        }

        private void StartBcgrnd()
        {

            if (_bckgrndSaver != null && !_bckgrndSaver.Enabled && sdgDetails != null && "VPCI".Contains(sdgDetails.STATUS))
                _bckgrndSaver.Start();
            else
            {
                _bckgrndSaver.Stop();
            }
        }

        private string tb_text;
        private void LoadSdg()
        {
            try
            {
                var tb = txtBarcodeName;
                if (tb == null || string.IsNullOrEmpty(tb.Text)) return;

                Logger.WriteLogFile(txtBarcodeName.Name);
                string sn = tb.Text.Replace(".", "/").ToUpper();

                //aaaaaaaaaaaaaaaaaaaaaaaa
                tb_text = txtBarcodeName.Text;
                sdgDetails = _dal.Get_SDG_DETAILS(txtBarcodeName.Text);

                if (sdgDetails != null)
                {
                    Logger.WriteLogFile(sdgDetails.SDG_NAME);

                    radButtonOpenSectra_Click(null, null);

                    ClearScreen();
                    LoadDoctors();
                    LoadNewSdg();

                    // Each signature represent a signing in the inspection plan for the current sdg, and the signatures will be displayed in the snomed page.
                    List<RESULT> signatures = _dal.FindBy<RESULT>(r => r.NAME.Contains("Sign by") && r.TEST.ALIQUOT.SAMPLE.SDG.SDG_ID == sdgDetails.SDG_ID).ToList();

                    if (_AuthorizePopUpForm == null)
                    {
                        _AuthorizePopUpForm = new AuthorizePopUpForm(_SessionId, _currentUserName, _dal);
                    }

                    _AuthorizePopUpForm.LoadSignatures(_dal, signatures);
                    //     this.snomedCtrl1.LoadSignatures(sdgDetails, _dal, signatures);
                    loggedInOperatorSigned = _AuthorizePopUpForm.CheckIfOperatorSigned(signatures, _currentUserid.ToString());

                    this.Show();
                }
                else
                {
                    MessageBox.Show(".דרישה לא קיימת", Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ClearScreen();
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
                MessageBox.Show(".שגיאה בטעינת הדרישה" + ex.Message, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        internal class ExtraMaterials
        {
            private string name;
            public string Name { get { return name; } }

            private Bitmap img;
            public Bitmap Img { get { return img; } }

            public ExtraMaterials(string _name, Bitmap _img)
            {
                name = _name;
                img = _img;
            }
        }

        private void setExtraMaterialsListBox(SDG sdg)
        {
            try
            {
                dataGridViewExtraMaterials.Rows.Clear();
                List<ExtraMaterials> list = new List<ExtraMaterials>();
                var bad = Properties.Resources.bad;
                var good = Properties.Resources.good;

                sdg.SAMPLEs.OrderBy(s => s.NAME).Foreach(samp =>
                {
                    if (samp.SAMPLE_USER.U_MATERIAL != null && samp.SAMPLE_USER.U_MATERIAL.Equals("T"))
                        list.Add(new ExtraMaterials(samp.NAME, good));
                    else
                        list.Add(new ExtraMaterials(samp.NAME, bad));
                });

                var bindingList = new BindingList<ExtraMaterials>(list);
                var source = new BindingSource(bindingList, null);
                dataGridViewExtraMaterials.DataSource = source;
                sampleName_col.DataPropertyName = "Name";
                extraMaterials_col.DataPropertyName = "Img";
                dataGridViewExtraMaterials.Columns["sampleName_col"].DefaultCellStyle.Font = new Font(dataGridViewExtraMaterials.DefaultCellStyle.Font.FontFamily, 8, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewExtraMaterials_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewExtraMaterials.ClearSelection();
        }



        AuthorizePopUpForm _AuthorizePopUpForm;
        private void radButtonAuthorise_Click(object sender, EventArgs e)
        {
            try
            {


                _dal.InsertToSdgLog(sdgDetails.SDG_ID, "RE.UPDATE", !DEBUG ? (long)_ntlsCon.GetSessionId() : 1, "מסך פתולוג - אישור");
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                //First Save
                if (!SaveRequest()) return;

                _bckgrndSaver.Stop();

                //And then check if can authorize
                string validMsg = CanAuthorise();

                if (!string.IsNullOrEmpty(validMsg))
                {
                    MessageBox.Show(validMsg, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    EnableControls(sdgDetails.STATUS != "A");
                    Mouse.OverrideCursor = null;
                    return;

                }
                else
                {

                    // האם ממתין להפצה  
                    bool IsReadyForDistribute = sdgDetails.U_WEEK_NBR == 907;

                    //loggedInOperatorSigned =  האם המשתמש המחובר עכשיו לנאוטילוס, חתום על הדרישה 

                    //אם המשתמש המחובר לא חתום על הדרישה וגם היא לא ממתינה להפצה 
                    if (/*!loggedInOperatorSigned &&*/ !IsReadyForDistribute)
                    {
                        cngWeekNbr = true;
                        //מגדיר מה החתימה הנדרשת,ראשונה או שנייה
                        RESULT resultToSign = null;

                        //מגדיר האם קיימת חתימה ראשונה
                        bool firstSignExists = false;

                        foreach (WrapperRtf res1 in _currentResults)
                        {
                            if (res1.Result_.NAME.Contains("Sign by 1"))
                            {
                                //אם קיימת חתימה ראשונה מחזיר true 
                                firstSignExists = res1.Result_.FORMATTED_RESULT != null;

                                if (firstSignExists)
                                {
                                    foreach (WrapperRtf res2 in _currentResults)
                                    {
                                        if (res2.Result_.NAME.Contains("Sign by 2"))
                                        {
                                            resultToSign = res2.Result_;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    resultToSign = res1.Result_;
                                }

                                break;
                            }
                        }

                        //create new AuthorizePopUpForm
                        if (_AuthorizePopUpForm == null)
                        {
                            _AuthorizePopUpForm = new AuthorizePopUpForm(_SessionId, _currentUserName, _dal);
                        }


                        _AuthorizePopUpForm.init(firstSignExists, IsReadyForDistribute);
                        //_AuthorizePopUpForm.snomedVisible(true);

                        DialogResult dialogResult = _AuthorizePopUpForm.ShowDialog();

                        //_AuthorizePopUpForm.snomedVisible(false);



                        if (dialogResult == DialogResult.OK)//בלחיצה על ok
                        {
                            //_AuthorizePopUpForm.snomedVisible(true);

                            _AuthorizePopUpForm.SaveSnomedTab(sdgDetails, _currentResults, resultToSign, _ntlsUser, _dal, loggedInOperatorSigned);

                            _dal.SaveChanges();

                            //_AuthorizePopUpForm.snomedVisible(false);
                        }

                        if (dialogResult == DialogResult.Cancel)
                        {
                            StartBcgrnd();
                            _AuthorizePopUpForm.ClearScreen();
                            return;
                        }

                    }

                    try
                    {
                        //diagnosis.saveResults();
                        pathologDiagnosisWPF1.saveResults();
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLogFile(ex);
                        MessageBox.Show("error on saving diagnosis:" + Environment.NewLine + ex.Message);
                    }

                    _dal.SaveChanges();
                }

                ClearScreen();
                EnableControls(false);

                txtBarcodeName.Focus();

                ((Form)this.TopLevelControl).Hide();
            }
            catch (Exception ex)
            {
                EnableControls(true);
                MessageBox.Show("Error on Authorise Click." + Environment.NewLine + ex.InnerException.Message, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLogFile(ex);
                Mouse.OverrideCursor = null;
                LoadDoctors();
                LoadNewSdg();
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        private string CanAuthorise()
        {
            string stopMsg = string.Empty;

            if (string.IsNullOrEmpty(pathologDiagnosisWPF1.richTextMicro.GetOriginalText().Trim()))
            //if (string.IsNullOrEmpty(diagnosis.richTextMicro.GetOriginalText().Trim()))
            {
                stopMsg = "Micro is mandatory" + Environment.NewLine;
            }

            return stopMsg.Trim();
        }

        private void PrintPDFLetter()
        {
            var www = new FireEventXmlHandler(_sp, "Print PDF Letter");
            www.CreateFireEventXml("SDG", sdgDetails.SDG_ID, "Print PDF Letter");
            var sSs = www.ProcssXmlWithOutSave();
            if (!sSs)
            {
                Logger.WriteLogFile(www.ErrorResponse);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Logger.WriteLogFile("buttonExit_Click");

            Logger.WriteLogFile(MethodBase.GetCurrentMethod().Name);

            resetHistoryTab();

            //this.Close(); // Close the current form

            // Optionally, you can also close the top-level form if needed
            //((Form)this.TopLevelControl).Close();


            this.Hide();

            ((Form)this.TopLevelControl).Hide();
        }


        private void resetHistoryTab()
        {
            historyTabColor = Color.Black;
            DetTab.DrawItem -= tabControl1_DrawItem;

            if (DetTab.TabCount > 0)
            {
                DetTab.SelectedIndex = 0;
            }
        }
        #endregion

        #region Load SDG
        private void LoadDoctors()
        {
            var qDoctors =
           _dal.FindBy<OPERATOR>(o => o.LIMS_ROLE.NAME == "DOCTOR" || o.LIMS_ROLE.NAME == "Cytoscreener")
                              .Include(a => a.LIMS_ROLE)
                                .Include(x => x.OPERATOR_USER).OrderBy(x => x.NAME);

            var Doctors = qDoctors.ToList();//.First().OPERATOR_USER.U_HEBREW_NAMEOPERATOR_ID;

            CmbPatholog.DisplayMember = "FULL_NAME";
            CmbPatholog.ValueMember = "OPERATOR_ID";

            Pathologists = Doctors.Where(x => x.LIMS_ROLE.NAME == "DOCTOR").ToList();
            Cytoscariners = Doctors.Where(x => x.LIMS_ROLE.NAME == "Cytoscreener").ToList();

            CmbPatholog.DataSource = Doctors; //new List<string> { "test1","test2"};
            CmbPatholog.Text = "";

            CmbPatholog.Enabled = checkOperator(_currentUserid.ToString());

        }
        //my code (AE)
        private void SetTissuesTable(SDG sdg)
        {
            pnlTissuesTable.Controls.Clear();
            if (sdg != null)
            {
                pnlTissuesTable.BackColor = Color.Transparent;
                TableLayoutPanel dynamicTableLayoutPanel = new TableLayoutPanel();

                //הגדרת מידות וצבע הטבלה
                dynamicTableLayoutPanel.AutoSize = true;
                dynamicTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 22f));

                int iteration = 0;

                List<Label> labels = new List<Label>();

                foreach (var samp in sdg.SAMPLEs)
                {
                    foreach (var item in samp.ALIQUOTs)
                    {
                        if (item.ALIQUOT_USER.U_NUM_OF_TISSUES != null && item.ALIQUOT_USER.U_GLASS_TYPE.Equals("B"))
                        {
                            // הגדרת ערך + תוכן השורה                           
                            string contentText1 = item.NAME.Substring(item.NAME.Length - 3);
                            string contentText = item.NAME.Substring(item.NAME.IndexOf('.') + 1);
                            contentText += $"({item.ALIQUOT_USER.U_NUM_OF_TISSUES})";

                            Label contentLabel = new Label();
                            contentLabel.AutoSize = true;
                            contentLabel.Padding = new Padding(1, 1, 1, 1);
                            contentLabel.Text = contentText;
                            contentLabel.Font = new Font(contentLabel.Font.FontFamily, 8, contentLabel.Font.Style);

                            labels.Add(contentLabel);
                        }
                    }
                }

                // Sort the labels list
                labels.Sort(new LabelComparer());


                // Add the sorted labels to the table
                foreach (var label in labels)
                {
                    dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 22f));
                    dynamicTableLayoutPanel.Controls.Add(label, 0, iteration);
                    iteration++;
                }
                labels.Clear();
                pnlTissuesTable.Size = dynamicTableLayoutPanel.GetPreferredSize(new Size(0, 0));
                pnlTissuesTable.Controls.Add(dynamicTableLayoutPanel);
                //pnlTissuesTable.Size = dynamicTableLayoutPanel.GetPreferredSize(new Size(0, 0));

                Size tableSize = dynamicTableLayoutPanel.GetPreferredSize(new Size(0, 0));
                pnlTissuesTable.Width = tableSize.Width + 25;
                pnlTissuesTable.Height = 180;

                label3.BringToFront();
                pnlTissuesTable.BackColor = SystemColors.Control;
                pnlTissuesTable.BringToFront();
            }
        }

        private void LoadNewSdg()
        {

            _rtfManager._dal = _dal;
            Logger.WriteLogFile("Before reconnect to dal");
            if (DEBUG)
            { _dal.MockConnect(); }
            else
            { _dal.Connect(_ntlsCon); }
            Logger.WriteLogFile("After reconnect to dal");

            sdg = _dal.FindBy<SDG>(x => x.SDG_ID == sdgDetails.SDG_ID).FirstOrDefault();

            setExtraMaterialsListBox(sdg);

            //(AE)
            SetTissuesTable(sdg);

            HasRevision();

            if (sdg.STATUS == "A")
            {
                MessageBox.Show("Sdg is Authorised, No changes can be made!",
                    Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            EnableControls(sdg.STATUS != "A");

            //Load sdg details for sdg
            LoadSdgDetails();

            //Get results by sdg ID
            var currentResultsTemp = (from rl in _dal.FindBy<RESULT>(x => x.TEST.ALIQUOT.SAMPLE.SDG_ID == sdg.SDG_ID)
                                      where rl.TEST.STATUS != "X"
                                      select new WrapperRtf()
                                      {
                                          Result_ = rl,
                                          Name = rl.NAME,
                                          ResultId = rl.RESULT_ID,
                                          TestName = rl.TEST.NAME
                                      }).ToList();

            _currentResults.Clear();
            var maligRes = currentResultsTemp.FirstOrDefault(x => x.Name == Constants.Malignant);
            if (maligRes != null)
            {
                picMalig.Visible = (maligRes.Result_.FORMATTED_RESULT != null && maligRes.Result_.FORMATTED_RESULT.StartsWith("T"));
            }

            foreach (WrapperRtf rl in currentResultsTemp)
            {
                if (_rtfManager._result2RichText.ContainsKey(rl.Name) || (!_ispap && _AuthorizePopUpForm.ContainsResult(rl.Name)))
                {
                    _currentResults.Add(rl);
                }
            }

            _rtfManager.LoadResults(sdg, _currentResults);


            _AuthorizePopUpForm.EmptyAllCombos();


            _AuthorizePopUpForm.LoadSnomedResults(_currentResults);
            sdgSttachmentsCtrl1.Sdg = sdg;

            var Historylist = _dal.FindBy<SDG_USER>(x => x.U_PATIENT.Value == sdg.SDG_USER.U_PATIENT.Value && x.SDG.STATUS != "X")
                .Include(x => x.CLIENT).Include(a => a.SDG);


            historyCtl.LoadData(sdg.NAME, Historylist);


            DetTab.DrawItem += tabControl1_DrawItem;

            if (Historylist.Where(item => !item.SDG.NAME.Equals(sdg.NAME)).Count() > 0)
            {
                historyTabColor = Color.Green;
            }

            try
            {
                requestRemarkControl1.sampleInput(sdg.NAME);
            }
            catch (Exception ex12)
            {

                Logger.WriteLogFile(ex12);
            }

            if (!DEBUG)
                _dal.InsertToSdgLog(sdg.SDG_ID, "RE.SELECT",
                    (long)_ntlsCon.GetSessionId(), "מסך פתולוג - שליפה");


            if (tabControl.TabCount > 0)
                tabControl.SelectTab(0);
        }

        #endregion

        // if the current sdg has old SDGs (history), this method will change the color of the history tabName to green, indicating that there are history cases
        Color historyTabColor = Color.Black;
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = DetTab.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);

            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, DetTab.TabPages[e.Index].Text.Equals("היסטוריה") ? historyTabColor : Color.Black);
        }

        void historyCtl_ItemSelected(string obj)
        {
            _bckgrndSaver.Stop();

            txtBarcodeName.Text = obj;

            var q = (from item in _dal.FindBy<SDG_USER>(x => x.U_PATHOLAB_NUMBER == obj)
                     select new { item.SDG_ID, item.U_PDF_PATH }).FirstOrDefault();

            if (q != null)
            {
                _bckgrndSaver.Start();
                var SDG_ID = q.SDG_ID;
                var U_PDF_PATH = q.U_PDF_PATH;
                PreviewLetter = new PreviewLetterCls();
                PreviewLetter.runPreviewLetter(SDG_ID, U_PDF_PATH, _ntlsCon, _dal);
                _bckgrndSaver.Stop();
            }
            StartBcgrnd();

        }

        #region UI
        private void ClearScreen()
        {
            EnableControls(false);
            sdgSttachmentsCtrl1.Reset();
            requestRemarkControl1.Reset();
            _currentResults.Clear();
            if (historyCtl != null) historyCtl.ClearList();

            pictureBox1.Image = new Bitmap(Path.Combine(Utils.GetResourcePath(), "sdgU.ico"));

            lblPathoName.Text = string.Empty;
            CmbPatholog.Text = string.Empty;

            gbClient.Controls.OfType<RadTextBox>().Foreach(x => x.Text = string.Empty);
            gbOrder.Controls.OfType<RadTextBox>().Foreach(x => x.Text = string.Empty);
            gbMacro.Controls.OfType<RadTextBox>().Foreach(x => x.Text = string.Empty);

            _AuthorizePopUpForm.ClearScreen();


            _rtfManager.ClearScreen();
            //diagnosis.ClearScreen();
            pathologDiagnosisWPF1.ClearScreen();
            txtBarcodeName.Text = string.Empty;
            if (tabControl.TabCount > 0)
                tabControl.SelectTab(0);


            resetHistoryTab();


            this.Hide();
        }

        private void EnableControls(bool p)
        {
            //snomed tab
            _AuthorizePopUpForm.EnableControls(p);
            _rtfManager.EnableControls(p);
            //buttons
            btnAuth.Enabled = p;
            btnSave.Enabled = p;
        }
        #endregion

        #region Load SDG Details


        void setbtnColor(RadButton radButton, bool change)
        {
            Color color;
            if (change)
            {
                color = Color.GreenYellow;
            }
            else
            {
                color = Color.FromArgb(232, 241, 252); ;

            }

            ((FillPrimitive)radButton.GetChildAt(0).GetChildAt(0)).BackColor =
                color;
            ((FillPrimitive)radButton.GetChildAt(0).GetChildAt(0)).BackColor2 =
                color;
            ((FillPrimitive)
                radButton.GetChildAt(0).GetChildAt(0)).BackColor3 = color;
            ((FillPrimitive)
                radButton.GetChildAt(0).GetChildAt(0)).BackColor4 = color;
            ((FillPrimitive)radButton.GetChildAt(0).GetChildAt(0)).BackColor =
                color;
        }


        private void LoadSdgDetails()
        {
            picQC.Visible = sdgDetails.U_IS_QC == "T";
            setbtnColor(btnLetter, sdgDetails.U_PDF_PATH != null);

            LoadPatientDetails();
            LoadPhysiciansDetails();

            _AuthorizePopUpForm.LoadSdgDetails(sdg);
            bool hasReqColor = sdg.U_EXTRA_REQUEST_USER.Any(eru => eru.U_EXTRA_REQUEST.U_EXTRA_REQUEST_DATA_USER.Any(erdu => erdu.U_STATUS != "X" && erdu.U_REQ_TYPE != null && "HIO".Contains(erdu.U_REQ_TYPE)));
            bool hasReqConsult = sdg.U_EXTRA_REQUEST_USER.Any(eru => eru.U_EXTRA_REQUEST.U_EXTRA_REQUEST_DATA_USER.Any(erdu => erdu.U_STATUS.Equals("V") && erdu.U_REQ_TYPE != null && erdu.U_REQ_TYPE.Equals("T")));
            bool hasReqRescan = sdg.U_EXTRA_REQUEST_USER.Any(eru => eru.U_EXTRA_REQUEST.U_EXTRA_REQUEST_DATA_USER.Any(erdu => erdu.U_STATUS.Equals("V") && erdu.U_REQ_TYPE != null && erdu.U_REQ_TYPE.Equals("S")));
            bool hasReqExtraMaterial = sdg.U_EXTRA_REQUEST_USER.Any(eru => eru.U_EXTRA_REQUEST.U_EXTRA_REQUEST_DATA_USER.Any(erdu => erdu.U_STATUS.Equals("V") && erdu.U_REQ_TYPE != null && erdu.U_REQ_TYPE.Equals("M")));


            setbtnColor(BtnExtReq, hasReqColor);
            setbtnColor(BtnSendToAdvisor, hasReqConsult);
            setbtnColor(BtnRescan, hasReqRescan);


            //  setbtnColor(extraMaterialCtrl1.ExMaterialButton, hasReqExtraMaterial);

        }


        private void LoadPatientDetails()
        {
            pictureBox1.Image = new Bitmap(Path.Combine(Utils.GetResourcePath(), "sdg" + sdgDetails.STATUS + ".ico"));


            string cln = sdgDetails.CLIENT_FNAME + " " + sdgDetails.CLIENT_LNAME + " - " + sdgDetails.CLIENT_NAME + " ";
            lblPathoName.Text = string.Format("{0} - {1}", cln, sdgDetails.PATHOLAB_NUMBER);
            if (sdg.NAME[0] == 'P')
            {
                CmbPatholog.DataSource = Cytoscariners;
            }
            else
            {
                CmbPatholog.DataSource = Pathologists;
            }
            CmbPatholog.Text = sdgDetails.INTENDED_PATHOLOG;

            txtFN.Text = string.Format("{0} {1}", sdgDetails.CLIENT_FNAME, sdgDetails.CLIENT_LNAME);
            txtGender.Text = _genderDic.ContainsKey(sdgDetails.CLIENT_GENDER) ? _genderDic[sdgDetails.CLIENT_GENDER] : sdgDetails.CLIENT_GENDER;
            txtIdentity.Text = sdgDetails.CLIENT_NAME;

            if (sdgDetails.CLIENT_BDAY.HasValue)
            {


                txtDB.Text = sdgDetails.CLIENT_BDAY.Value.ToShortDateString();
                txtAge.Text = ((int)Math.Floor((DateTime.Now - sdgDetails.CLIENT_BDAY.Value).TotalDays / 365)).ToString();
            }
            else
            {

                txtDB.Text = "";
                txtAge.Text = "";
            }
        }

        private void LoadPhysiciansDetails()
        {

            txtImp.Text = sdgDetails.IMPLEMENTING_PHYSICIAN_FULL_NAME;
            txtImpPhone.Text = sdgDetails.IMPLEMENTING_PHYSICIAN_PHONE != null ? sdgDetails.IMPLEMENTING_PHYSICIAN_PHONE : string.Empty;
            txtRefer.Text = sdgDetails.REFERRING_PHYSICIAN_FULL_NAME;
            txtImpPhone.Text = sdgDetails.REFERRING_PHYSICIAN_PHONE != null ? sdgDetails.REFERRING_PHYSICIAN_PHONE : string.Empty;
            txtPriority.Text = sdgDetails.PRIORITY;


            OPERATOR macroDoctor = null;

            string pahologMacro = null;
            if (sdg.SAMPLEs.FirstOrDefault() != null)
                pahologMacro = sdgDetails.U_PATHOLOG_MACRO;
            if (pahologMacro != null)
            {
                long pathologMacroId = Convert.ToInt64(pahologMacro);
                macroDoctor = _dal.FindBy<OPERATOR>(op => op.OPERATOR_ID == pathologMacroId).FirstOrDefault();

                if (macroDoctor != null)
                {
                    txtMacroDoc.Text = macroDoctor.OPERATOR_USER.U_HEBREW_NAME;

                    foreach (SAMPLE samp in sdg.SAMPLEs)
                    {
                        foreach (ALIQUOT aliq in samp.ALIQUOTs)
                        {
                            foreach (TEST test in aliq.TESTs)
                            {
                                foreach (RESULT res in test.RESULTs)
                                {
                                    if (res.CREATED_BY == macroDoctor.OPERATOR_ID && res.NAME.ToLower().Equals("histology macro text") && res.COMPLETED_ON != null)
                                    {
                                        txtMacroTime.Text = res.COMPLETED_ON.Value.ToShortDateString().ToString();
                                        goto LoopEnd;
                                    }
                                }
                            }
                        }
                    }

                LoopEnd:
                    return;
                }
            }
        }

        #endregion


        #region Save methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            try
            {
                SaveRequest();

                try
                {
                    //diagnosis.saveResults();
                    pathologDiagnosisWPF1.saveResults();

                }
                catch (Exception ex)
                {
                    Logger.WriteLogFile(ex);

                    MessageBox.Show("error on saving diagnosis:" + Environment.NewLine + ex.Message);
                }
            }
            catch (Exception ex)
            {
                EnableControls(true);

                MessageBox.Show("Error on btnSave_Click" + ex.Message, Constants.MboxCaption, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Logger.WriteLogFile(ex);
            }

            txtBarcodeName.Focus();
        }

        private bool SaveRequest()
        {
            _bckgrndSaver.Stop();

            //שמירה של החלון אישור- בוטל כיוון שמיוצ[תר לשמור פה, נשמר ביציאה מהחלון
            //_AuthorizePopUpForm.SaveSnomedTab(sdgDetails, _currentResults, null, _ntlsUser, _dal, loggedInOperatorSigned);


            //Saving rtf is for every type of sdg 
            _rtfManager.SaveResults(_currentResults);
            _rtfManager.SaveAsText(_currentResults);

            string strOldPatholog = "";
            string strNewPatholog = CmbPatholog.Text;


            if (!string.IsNullOrEmpty(sdgDetails.INTENDED_PATHOLOG))
            {

                strOldPatholog = sdgDetails.INTENDED_PATHOLOG;// _sdg.SDG_USER.PATHOLOG.OPERATOR_USER.OPERATOR.FULL_NAME;
            }

            if (strOldPatholog != strNewPatholog)
            {
                sdgDetails.U_PATHOLOG = (long)CmbPatholog.SelectedValue;
                sdg.SDG_USER.U_PATHOLOG = (long)CmbPatholog.SelectedValue;
                _dal.InsertToSdgLog(sdgDetails.SDG_ID, "PTG.UPD", (long)_ntlsCon.GetSessionId(), "New: " + strNewPatholog + " , Old: " + strOldPatholog);

            }
            //Insert to sdg log
            long sid = 1;

            if (!DEBUG)
            { sid = (long)_ntlsCon.GetSessionId(); }

            _dal.InsertToSdgLog(sdgDetails.SDG_ID, "RE.SAVE", sid, "מסך פתולוג - שמירה");
            _dal.SaveChanges();

            //Set status for all tree to Completed
            SetStatusToC();

            //Reload the sdg after saving
            LoadDoctors();
            LoadNewSdg(); //This row  must to be here
            StartBcgrnd();

            return true;
        }

        private void SetStatusToC()
        {
            string notValidStatus = "XA";

            //(from rl in _dal.FindBy<ALIQUOT>(x => x.SAMPLE.SDG_ID == sdgDetails.SDG_ID && "U".Contains(x.STATUS))
            // select rl).Foreach(x => x.STATUS = "V");

            (from rl in
                 _dal.FindBy<RESULT>(x => x.TEST.ALIQUOT.SAMPLE.SDG_ID == sdgDetails.SDG_ID && !notValidStatus.Contains(x.STATUS))
             select rl).Foreach(x => x.STATUS = "C");
            (from rl in
                 _dal.FindBy<TEST>(x => x.ALIQUOT.SAMPLE.SDG_ID == sdgDetails.SDG_ID && !notValidStatus.Contains(x.STATUS))
             select rl).Foreach(x => x.STATUS = "C");
            (from rl in
                 _dal.FindBy<ALIQUOT>(x => x.SAMPLE.SDG_ID == sdgDetails.SDG_ID && !notValidStatus.Contains(x.STATUS))
             select rl).Foreach(x => x.STATUS = "C");
            (from rl in
                 _dal.FindBy<SAMPLE>(x => x.SDG_ID == sdgDetails.SDG_ID && !notValidStatus.Contains(x.STATUS))
             select rl).Foreach(x => x.STATUS = "C");
            (from rl in
                 _dal.FindBy<SDG>(x => x.SDG_ID == sdgDetails.SDG_ID && !notValidStatus.Contains(x.STATUS))
             select rl).Foreach(x => x.STATUS = "C");

            _dal.SaveChanges();
        }

        #endregion

        int bckgrndinterval = 10000; //Default time if isn't interval in parameters command(setparametres function)
        private void SartBckgrTimer()
        {
            _bckgrndSaver = new Timer();
            _bckgrndSaver.Interval = bckgrndinterval;
            StartBcgrnd();
        }
        int showMsgcnt = 0;


        private void BckgrndSaver_Tick(object sender, EventArgs e)
        {

            //Ashi 29/03/2022 Cancel Auto Save
            return;
            if (DEBUG || sdgDetails == null) return;

            try
            {
                if ("ARXU".Contains(sdgDetails.STATUS)) return;

                _rtfManager.SaveResults(_currentResults);
                //diagnosis.saveResults();
                pathologDiagnosisWPF1.saveResults();
                _dal.SaveChanges();
            }
            catch (Exception exception)
            {
                if (showMsgcnt < 2)//Show message from timer just 2 times
                {
                    MessageBox.Show("Exception " + exception.Message);
                    showMsgcnt++;
                }
            }
        }

        #region Button events

        private void PrintLetter_Click(object sender, EventArgs e)
        {
            PrintPDFLetter();
        }

        private void EditClient_Click(object sender, EventArgs e)
        {
            var client = _dal.FindBy<CLIENT>(c => c.NAME.Equals(sdgDetails.CLIENT_NAME)).FirstOrDefault();

            if (client == null)
            {
                MessageBox.Show("מטופל לא נמצא.");
                return;
            }

            using (EditClientFrm updatPat = new EditClientFrm(client, _genderDic, _sp))
            {
                updatPat.PatientEdited += updatPat_PatientEdited;
                updatPat.ShowDialog();
                updatPat.PatientEdited -= updatPat_PatientEdited;
            }
        }

        void updatPat_PatientEdited(CLIENT clientUp)
        {
            var client = clientUp.CLIENT_USER;
            string cln = client.U_FIRST_NAME + " " + client.U_LAST_NAME + " - " + clientUp.NAME + " ";
            lblPathoName.Text = string.Format("{0} - {1}", cln, sdgDetails.PATHOLAB_NUMBER);

            //Left side
            txtFN.Text = string.Format("{0} {1}", client.U_FIRST_NAME, client.U_LAST_NAME);
            txtGender.Text = _genderDic.ContainsKey(client.U_GENDER) ? _genderDic[client.U_GENDER] : "";
            if (client.U_DATE_OF_BIRTH.HasValue)
            {
                txtDB.Text = client.U_DATE_OF_BIRTH.Value.ToShortDateString().ToString();

                var age = (int)Math.Floor((DateTime.Now - client.U_DATE_OF_BIRTH.Value).TotalDays / 365);
                txtAge.Text = age.ToString();
            }
            else
            {
                txtAge.Text = "0";
            }
        }
        private void ExtraReq_Click(object sender, EventArgs e)
        {

            long sid = 1;
            if (sdgDetails == null) return;
            if (!DEBUG)
            { sid = (long)_ntlsCon.GetSessionId(); }
            _bckgrndSaver.Stop();



            var sdg = _dal.FindBy<SDG>(s => s.SDG_ID == sdgDetails.SDG_ID).FirstOrDefault();


            if (sdg == null)
            {
                MessageBox.Show("לא נמצאה דרישה.");
                return;
            }

            using (ExtraRequest extra = new ExtraRequest(_dal, sdg, _sp, _ntlsUser, sid, listData))
            {
                extra.FormClosed += extra_FormClosed;
                extra.Title = sdg.NAME;
                extra.WindowState = FormWindowState.Maximized;
                extra.ShowDialog();
                var x = sdg.U_EXTRA_REQUEST_USER.Any(eru => eru.U_EXTRA_REQUEST.U_EXTRA_REQUEST_DATA_USER.Any(erdu => erdu.U_STATUS != "X" && erdu.U_REQ_TYPE != null && "HIO".Contains(erdu.U_REQ_TYPE)));
                setbtnColor(BtnExtReq, extra.HasReq || x);
            }

            StartBcgrnd();
        }


        private void BtnSendToAdvisor_Click(object sender, EventArgs e)
        {
            long sid = 1;
            if (sdgDetails == null) return;
            if (!DEBUG)
            { sid = (long)_ntlsCon.GetSessionId(); }
            _bckgrndSaver.Stop();

            var sdg = _dal.FindBy<SDG>(s => s.SDG_ID == sdgDetails.SDG_ID).FirstOrDefault();

            if (sdg == null)
            {
                MessageBox.Show("לא נמצאה דרישה.");
                return;
            }

            using (SendToAdvisor advisor = new SendToAdvisor(_dal, sdg, _sp, _ntlsUser, sid, listData, _currentUserName))
            {
                advisor.ShowDialog();
            }

            StartBcgrnd();
        }


        private void BtnRescan_Click(object sender, EventArgs e)
        {
            long sid = 1;
            if (sdgDetails == null) return;
            if (!DEBUG)
            { sid = (long)_ntlsCon.GetSessionId(); }
            _bckgrndSaver.Stop();

            var sdg = _dal.FindBy<SDG>(s => s.SDG_ID == sdgDetails.SDG_ID).FirstOrDefault();

            if (sdg == null)
            {
                MessageBox.Show("לא נמצאה דרישה.");
                _bckgrndSaver.Start();
                return;
            }


            using (Rescan rescan = new Rescan(_dal, sdg, _sp, _ntlsUser, sid))
            {
                rescan.ShowDialog();
            }

            StartBcgrnd();
        }

        public void setSnomed()
        {
            if (_AuthorizePopUpForm == null)
            {
                _AuthorizePopUpForm = new AuthorizePopUpForm(_SessionId, _currentUserName, _dal);
            }

        }

        void extra_FormClosed(object sender, FormClosedEventArgs e)
        {
            var extWindow = sender as ExtraRequest;

            extWindow.Title = "---";
            StartBcgrnd();
        }

        private void buttonOpenPortal_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = sdgDetails.CLIENT_NAME;

                if (!string.IsNullOrEmpty(userID))
                {
                    PortalAssuta.openPortal(_dal, userID);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can't find client name.");
            }
        }

        private void radButtonOpenSectra_Click(object sender, EventArgs e)
        {
            PHRASE_HEADER header = _dal.FindBy<PHRASE_HEADER>(ph => ph.NAME.Equals("PacsDigital")).FirstOrDefault();
            var sdg = _dal.FindBy<SDG>(s => s.SDG_ID == sdgDetails.SDG_ID).FirstOrDefault();

            if (header != null && sdg != null)
            {
                if (_ntlsUser != null)
                {

                    PacsDigital.OpenPacsBrowserForWPF.openInWpf(sdg, header, _currentUserName);
                }
                else
                    PacsDigital.OpenPacsBrowserForWPF.openInWpf(sdg, header);
            }
            else
                MessageBox.Show("Can't find header.");
        }

        private void buttonExtraDocuments_Click(object sender, EventArgs e)
        {
            sdgSttachmentsCtrl1.radButton1_Click(null, null);
        }

        private void extraMaterialCtrl1_Load(object sender, EventArgs e)
        {
            var sdg = _dal.FindBy<SDG>(s => s.SDG_ID == sdgDetails.SDG_ID).FirstOrDefault();

            if (sdg != null)
            {
                long sid = 1;
                if (_ntlsCon != null)
                {
                    sid = (long)_ntlsCon.GetSessionId();
                }

                extraMaterialCtrl1.init(_dal, sdg, _sp, _ntlsUser, sid);
            }

        }
        #endregion

        #region PDF

        private void btnLetter_Click(object sender, EventArgs e)
        {
            try
            {
                if (sdgDetails == null) return;

                _bckgrndSaver.Start();
                PreviewLetter = new PreviewLetter.PreviewLetterCls();
                PreviewLetter.runPreviewLetter(sdgDetails.SDG_ID, sdgDetails.U_PDF_PATH, _ntlsCon, _dal);
                _bckgrndSaver.Stop();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error on Load pdf! " + ex.Message, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLogFile(ex);
            }

        }

        public void runPreviewLetter(SDG sdg)
        {
            try
            {
                if (sdg.SDG_USER.U_PDF_PATH != null && File.Exists(sdg.SDG_USER.U_PDF_PATH))
                {
                    var pdf = new PdfViewerFrm(sdg.SDG_USER.U_PDF_PATH);
                    pdf.ShowDialog();
                }
                else
                {
                    RunReport(sdg.SDG_ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on Load pdf! " + ex.Message, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLogFile(ex);
            }

        }

        public void runPreviewLetter(SDG_DETAILS sdgDetails)
        {
            try
            {
                if (sdgDetails.U_PDF_PATH != null && File.Exists(sdgDetails.U_PDF_PATH))
                {
                    var pdf = new PdfViewerFrm(sdgDetails.U_PDF_PATH);
                    pdf.ShowDialog();
                }
                else
                {
                    RunReport(sdgDetails.SDG_ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on Load pdf! " + ex.Message, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLogFile(ex);
            }

        }

        #endregion


        ReportDocument CR;
        bool IsProxy = false;

        public void RunReport(long sdg_id)
        {
            try
            {
                string serverName;
                string nautilusUserName;
                string nautilusPassword;

                serverName = _ntlsCon.GetServerDetails();
                IsProxy = _ntlsCon.GetServerIsProxy();
                if (IsProxy)
                {
                    nautilusUserName = "";
                    nautilusPassword = "";
                }
                else
                {
                    nautilusUserName = _ntlsCon.GetUsername();
                    nautilusPassword = _ntlsCon.GetPassword();
                }


                var reportPath = _dal.FindBy<PHRASE_HEADER>(ph => ph.NAME.Equals("System Parameters")).FirstOrDefault().PHRASE_ENTRY.Where(pe => pe.PHRASE_NAME.Equals("Preview Letter")).FirstOrDefault().PHRASE_DESCRIPTION;

                if (File.Exists(reportPath))
                {
                    //load
                    CR = new ReportDocument();
                    CR.Load(reportPath);
                }
                else
                {
                    MessageBox.Show("Can't find pdf path from phrase.");
                    return;
                }

                CR.SetParameterValue("sdg id", sdg_id);


                Tables crTables;
                var crTableLoginInfo = new TableLogOnInfo();
                var crConnectionInfo = new ConnectionInfo();

                crConnectionInfo.ServerName = serverName;
                if (IsProxy)
                {
                    crConnectionInfo.IntegratedSecurity = true;
                }
                else
                {
                    crConnectionInfo.UserID = nautilusUserName;
                    crConnectionInfo.Password = nautilusPassword;
                }

                crTables = CR.Database.Tables;
                foreach (Table crTable in crTables)
                {
                    crTableLoginInfo = crTable.LogOnInfo;
                    crTableLoginInfo.ConnectionInfo = crConnectionInfo;
                    crTable.ApplyLogOnInfo(crTableLoginInfo);
                }

                CrystalReportsV1.Form1 f = new CrystalReportsV1.Form1(CR);

                f.ShowDialog();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error on RunReport : " + e.Message);
            }
        }

        private void HasRevision()
        {
            string sw = sdgDetails.SDG_NAME.Substring(0, 10);
            bool b = _dal.FindBy<SDG>(s => s.NAME.Contains(sw)).Count() > 1;
            lblRev.Visible = b && sdgDetails.SDG_NAME.Length == 10;
        }

        private void btnMngr_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_bckgrndSaver.Enabled.ToString());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gbClient_Enter(object sender, EventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PathologResultEntryCls_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDB_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewExtraMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlDetails_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class LabelComparer : IComparer<Label>
    {
        public int Compare(Label x, Label y)
        {
            // Remove the parentheses and what's inside
            string xWithoutParentheses = x.Text.Substring(0, x.Text.IndexOf('('));
            string yWithoutParentheses = y.Text.Substring(0, y.Text.IndexOf('('));

            // Split the strings into two parts by the dot
            string[] xParts = xWithoutParentheses.Split('.');
            string[] yParts = yWithoutParentheses.Split('.');

            // Extract the numerical values before and after the dot from each part
            int xBeforeDot = int.Parse(xParts[0]);
            int yBeforeDot = int.Parse(yParts[0]);
            int xAfterDot = int.Parse(xParts[1]);
            int yAfterDot = int.Parse(yParts[1]);

            // Compare the values before the dot
            int beforeDotComparison = xBeforeDot.CompareTo(yBeforeDot);
            if (beforeDotComparison != 0)
            {
                return beforeDotComparison;
            }

            // If the values before the dot are equal, compare the values after the dot
            int afterDotComparison = xAfterDot.CompareTo(yAfterDot);
            return afterDotComparison;
        }

    }

}