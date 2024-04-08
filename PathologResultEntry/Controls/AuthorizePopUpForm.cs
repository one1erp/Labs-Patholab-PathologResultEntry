using LSSERVICEPROVIDERLib;
using PathologResultEntry.Controls.Extra_req_Entities;
using Patholab_Common;
using Patholab_DAL_V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Control = System.Windows.Forms.Control;

namespace PathologResultEntry.Controls
{
    public partial class AuthorizePopUpForm : Form
    {


        private Dictionary<string, RadControl> _result2Snomed;
        public List<PHRASE_ENTRY> _sMList { get; set; }
        public List<PHRASE_ENTRY> _sTList { get; set; }
        public List<PHRASE_ENTRY> _signByList { get; set; }
        private List<DigitPatholog> doctors;
        private DataLayer _dal;

        SDG _sdg;

        public bool saveSnomed = true;
        private string malignantMessage = string.Empty;
        public string userResult = string.Empty;
        private string _currentUserName;
        private long _SessionId;
        public string WeekNbrStatus = string.Empty;
        public bool _snomedVisible { get; set; }

        public AuthorizePopUpForm(long SessionId, string UserName, DataLayer d)
        {
            InitializeComponent();
            this._SessionId = SessionId;
            this._currentUserName = UserName;
            this._dal = d;
            grp_snomedT.BackColor = Color.LightYellow;
            grp_snomedM.BackColor = Color.LightYellow;

            _result2Snomed = new Dictionary<string, RadControl>
                {
                    {Constants.SnomedT, cmbST1},
                    {Constants.SnomedM, cmbSM1},
                    {Constants.Sign1St, radTextBoxSignBy1},
                    {Constants.Sign2Nd, radTextBoxSignBy2},
                    {Constants.Malignant, cbMalig}     
                };
            LoadSnomedData();
        }

        internal void LoadSignatures(DataLayer dal, List<RESULT> signatures)
        {

            try
            {
                radTextBoxSignBy1.Text = string.Empty;
                radTextBoxSignBy2.Text = string.Empty;



                foreach (RESULT result in signatures)
                {
                    long operatorId = Convert.ToInt64(result.FORMATTED_RESULT);
                    if (result != null && result.NAME.Contains('1') && result.FORMATTED_RESULT != null)
                    {
                        OPERATOR signedOperator = dal.FindBy<OPERATOR>(op => op.OPERATOR_ID.Equals(operatorId)).FirstOrDefault();
                        if (signedOperator != null)
                            radTextBoxSignBy1.Text = string.Format("Signed By: {0}", signedOperator.NAME);
                    }

                    if (result != null && result.NAME.Contains('2') && result.FORMATTED_RESULT != null)
                    {
                        OPERATOR signedOperator = dal.FindBy<OPERATOR>(op => op.OPERATOR_ID.Equals(operatorId)).FirstOrDefault();
                        if (signedOperator != null)
                            radTextBoxSignBy2.Text = string.Format("Signed By: {0}", signedOperator.NAME);
                    }
                }
            }
            // }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadSnomedData()
        {
            if (_sMList == null || _sTList == null)
            {
                InitilaizeData1();
            }
            else
            {
                InitilaizeData2();
            }
        }

        private Task InitilaizeData1()
        {
            InitCombo();

            _sMList = SetSnomedPhrase2Combo(cmbSM1, "SNOMED M");
            SetSnomedPhrase2Combo(cmbSM2, "SNOMED M");

            _sTList = SetSnomedPhrase2Combo(cmbST1, "SNOMED T");
            SetSnomedPhrase2Combo(cmbST2, "SNOMED T");

            cmbSM1.ItemsSortComparer = new CustomComparer();
            cmbSM2.ItemsSortComparer = new CustomComparer();
            cmbST1.ItemsSortComparer = new CustomComparer();
            cmbST2.ItemsSortComparer = new CustomComparer();

            //     loggedInUserName = userName;

            doctors = SetSecondSignCombo(_currentUserName);
            radDropDownListSecondSign.BindingContext = new BindingContext();
            radDropDownListSecondSign.DisplayMember = "operatorName";
            radDropDownListSecondSign.ValueMember = "operatorId";

            radDropDownListSecondSign.DataSource = doctors;
            radDropDownListSecondSign.SelectedIndex = -1;

            radRadioButtonDistribute.IsChecked = true;

            return Task.FromResult(0);
        }

        private Task InitilaizeData2()
        {
            radRadioButtonDistribute.IsChecked = true;

            return Task.FromResult(0);
        }

        private List<PHRASE_ENTRY> SetSnomedPhrase2Combo(RadDropDownList comboBox, string phraseName)
        {
            try
            {
                List<PHRASE_ENTRY> list = _dal.GetPhraseEntries(phraseName).Where(pe => pe.PHRASE_NAME != null && !pe.PHRASE_NAME.Substring(0, 1).Equals("D")).ToList();

                SetExistsSnomedList2Combo(comboBox, list);
                return list;
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e); MessageBox.Show("Error in load " + phraseName + " Phrase " + e.Message, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private void SetExistsSnomedList2Combo(RadDropDownList comboBox, List<PHRASE_ENTRY> list)
        {
            if (list == null)
                return;

            comboBox.DisplayMember = "PHRASE_DESCRIPTION";
            comboBox.ValueMember = "PHRASE_NAME";

            comboBox.DataSource = list;
        }

        private List<DigitPatholog> SetSecondSignCombo(string userName)
        {
            //return dal.FindBy<PHRASE_HEADER>(ph => ph.NAME.ToLower().Equals("sign by")).FirstOrDefault().PHRASE_ENTRY.Where(pe => pe.PHRASE_DESCRIPTION != userName).ToList();

            var q = from op in _dal.GetAll<OPERATOR_USER>()
                    where op.U_IS_DIGITAL_PATHOLOG == "T" && op.OPERATOR.NAME != userName
                    select new DigitPatholog { operatorId = op.OPERATOR_ID, operatorName = op.OPERATOR.FULL_NAME };//op.U_DEGREE + " " + op.OPERATOR.FULL_NAME, Degree = op.U_DEGREE

            return q.ToList();
            //     return dal.FindBy<OPERATOR_USER>(op => op.U_IS_DIGITAL_PATHOLOG == "T" & op.OPERATOR.NAME != userName).ToList();
        }

        void InitCombo()
        {
            foreach (var item in this.Controls)
            {
                GroupBox grp = item as GroupBox;
                if (grp == null) continue;

                foreach (var rd in grp.Controls.OfType<RadDropDownList>())
                {

                    AutoCompleteModE(rd);
                    rd.GotFocus += (s, e) => zLang.English();
                }
            }
        }
        private void AutoCompleteModE(RadDropDownList rd)
        {
            rd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            rd.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(rd.DropDownListElement);
            rd.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
        }

        public void init(bool firstSignExists, bool IsReadyForDistribute)
        {
            radRadioButtonSendToSecondSign.Visible = firstSignExists == false;
            radDropDownListSecondSign.Visible = firstSignExists == false && radRadioButtonSendToSecondSign.IsChecked;

            radRadioButtonDistribute.Visible = !IsReadyForDistribute;

            grp_snomedT.Enabled = firstSignExists == false;
            grp_snomedM.Enabled = firstSignExists == false;


            if (firstSignExists == false && IsReadyForDistribute)
                WeekNbrStatus = string.Empty;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //cmbST1.SelectedValue = null;
            //cmbST2.SelectedValue = null;
            //cmbSM1.SelectedValue = null;
            //cmbSM2.SelectedValue = null;
            //radTextBoxSignBy1.Text = null;
            //radTextBoxSignBy2.Text = null;
            //radRadioButtonSendToSecondSign.IsChecked = false;
            //radRadioButtonDistribute.IsChecked = true;
            //cbMalig.IsChecked = false;
            //radDropDownListSecondSign.SelectedValue = null;
            this.Close();

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Logger.WriteLogFile("radRadioButtonSendToSecondSign.IsChecked: " + radRadioButtonSendToSecondSign.IsChecked.ToString());
            Logger.WriteLogFile("radRadioButtonDistribute.IsChecked: " + radRadioButtonDistribute.IsChecked.ToString());
            string msg = CanAuthorise();

            if (string.IsNullOrEmpty(msg))
            {
                userResult = WeekNbrStatus;

                this.DialogResult = DialogResult.OK;
                buttonExit_Click(null, null);
            }
            else
            {
                MessageBox.Show(msg, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }


        private string CanAuthorise()
        {
            string errMsg = string.Empty;
            canAuthoriseSnomedT(ref errMsg);
            canAuthoriseSnomedM(ref errMsg);
            candAuthoriseStatus(ref errMsg);

            return errMsg;
        }

        private void canAuthoriseSnomedT(ref string errMsg)
        {
            var ds = cmbST1.DataSource as List<PHRASE_ENTRY>;
            PHRASE_ENTRY pe = ds.FirstOrDefault(x => x.PHRASE_DESCRIPTION == cmbST1.Text);

            if (pe == null)
            {
                errMsg += "First snomed T is mandatory field." + Environment.NewLine;
            }
        }

        private void canAuthoriseSnomedM(ref string errMsg)
        {
            var ds = cmbSM1.DataSource as List<PHRASE_ENTRY>;
            PHRASE_ENTRY pe = ds.FirstOrDefault(x => x.PHRASE_DESCRIPTION == cmbSM1.Text);

            if (pe == null)
            {
                errMsg += "First snomed M is mandatory field.";
            }
        }

        private void candAuthoriseStatus(ref string errMsg)
        {
            errMsg += (radRadioButtonSendToSecondSign.IsChecked && radDropDownListSecondSign.SelectedIndex >= 0) || radRadioButtonDistribute.IsChecked ? string.Empty
                : "Second patholog is mandatory." + Environment.NewLine;
        }

        private void AuthorizePopUpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                saveSnomed = false;
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                saveSnomed = true;
            }

        }

        private void AuthorizePopUpForm_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(malignantMessage))
            {
                MessageBox.Show(malignantMessage, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        internal bool CheckIfOperatorSigned(List<RESULT> signatures, string loggedInOperatorId)
        {
            return signatures.Any(signature => signature.FORMATTED_RESULT == loggedInOperatorId);
        }

        internal void snomedVisible(bool v)
        {
            saveSnomed = v;

        }

        internal void SaveSnomedTab(SDG_DETAILS sdgDetails, List<WrapperRtf> currentResults, RESULT resultToSign,
            INautilusUser ntlsUser, DataLayer dal, bool loggedInOperatorSigned)
        {

            if (saveSnomed)
            {
                SDG_USER sdgUser = dal.FindBy<SDG_USER>(s => s.SDG_ID == sdgDetails.SDG_ID).FirstOrDefault();
                if (sdgUser != null)
                {
                    foreach (var res in currentResults)
                    {
                        string val = "";
                        if (_result2Snomed.ContainsKey(res.Name) && !res.Name.Contains(Constants.Sign1St) && !res.Name.Contains(Constants.Sign2Nd))
                        {
                            RadCheckBox r = _result2Snomed[res.Name] as RadCheckBox;

                            if (r != null) //is check box
                            {
                                val = r.IsChecked ? "T" : "F";
                            }
                            else if (_result2Snomed[res.Name] as RadSpinEditor != null)
                            {
                                var spinEditor = _result2Snomed[res.Name] as RadSpinEditor;
                                val = spinEditor.Value.ToString();
                            }
                            else if (res.Name == Constants.SnomedM)
                            {
                                var list_M = GetSnomedM_value(cmbSM1);

                                foreach (string entry in list_M)
                                    val = val + (entry + ";");
                            }
                            else if (res.Name == Constants.SnomedT)
                            {
                                var list_T = GetSnomedT_value();

                                foreach (string entry in list_T)
                                    val = val + (entry + ";");
                            }
                            else //is not check box
                            {
                                RadDropDownList cmb = _result2Snomed[res.Name] as RadDropDownList;
                                if (cmb != null)
                                {
                                    var bilbi = cmb.DataSource as List<PHRASE_ENTRY>;
                                    if (bilbi != null)
                                    {
                                        PHRASE_ENTRY cmbVal = bilbi.FirstOrDefault(x => x.PHRASE_DESCRIPTION == cmb.Text);

                                        if (cmbVal != null)
                                            val = cmbVal.PHRASE_NAME;
                                        else
                                        {
                                            val = cmb.Text;
                                        }
                                    }
                                }

                                else
                                {
                                    MessageBox.Show("Error");
                                    break;
                                }
                            }

                            RESULT res2Update = currentResults.Select(x => x.Result_).SingleOrDefault(x => x.RESULT_ID == res.ResultId);
                            if (res2Update != null)
                            {
                                res2Update.FORMATTED_RESULT = val;
                                res2Update.ORIGINAL_RESULT = val;
                            }
                        }
                    }
                }

                try
                {
                    Set_WeekNbrStatus();

                    sdgUser.U_WEEK_NBR = Convert.ToDecimal(WeekNbrStatus);
                    Logger.WriteLogFile("U_WEEK_NBR: " + sdgUser.U_WEEK_NBR.ToString());

                    if (resultToSign != null && loggedInOperatorSigned == false)//5/10/22 אם המשתמש המחובר כבר חתום על הדרישה ,לא תעשה חתימה נוספת
                    {
                        if (resultToSign.FORMATTED_RESULT == null)
                        {
                            var OPID = ntlsUser.GetOperatorId().ToString();
                            resultToSign.FORMATTED_RESULT = OPID;
                            resultToSign.ORIGINAL_RESULT = OPID;
                        }

                        if (WeekNbrStatus.Equals("707"))
                            sdgUser.U_PATHOLOG = Convert.ToInt64(radDropDownListSecondSign.SelectedValue);


                    }
                    dal.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Set_WeekNbrStatus()
        {
            Logger.WriteLogFile("status in - set statusWeekNbr..........");
            Logger.WriteLogFile("radRadioButtonSendToSecondSign.IsChecked: " + radRadioButtonSendToSecondSign.IsChecked.ToString());
            Logger.WriteLogFile("radRadioButtonDistribute.IsChecked: " + radRadioButtonDistribute.IsChecked.ToString());
            if (radRadioButtonSendToSecondSign.IsChecked)
            {
                _dal.InsertToSdgLog(_sdg.SDG_ID, "RE.UPDATE", _SessionId, "707 מסך פתולוג - העברה לחתימה שניה");
                WeekNbrStatus = "707";
                Logger.WriteLogFile("change week_nbr to 707 SDG_ID: " + _sdg.SDG_ID.ToString() + " U_PATHOLAB_NUMBER: " + _sdg.SDG_USER.U_PATHOLAB_NUMBER.ToString());
            }
            else if (radRadioButtonDistribute.IsChecked)
            {
                _dal.InsertToSdgLog(_sdg.SDG_ID, "RE.UPDATE", _SessionId, "מסך פתולוג - העברה להפצה 907");
                WeekNbrStatus = "907";
                Logger.WriteLogFile("change week_nbr to 907 SDG_ID: " + _sdg.SDG_ID.ToString() + " U_PATHOLAB_NUMBER: " + _sdg.SDG_USER.U_PATHOLAB_NUMBER.ToString());
            }
            else
            {
                WeekNbrStatus = string.Empty;
                Logger.WriteLogFile("week_nbr not change: " + _sdg.SDG_USER.U_WEEK_NBR.ToString());
            }
        }

        private List<string> GetSnomedT_value()
        {
            List<string> ST_list = new List<string>();
            ST_list.AddRange(new List<string>
            { GetSnmdVal(cmbST1),
                GetSnmdVal(cmbST2)
            });
            return ST_list;
        }

        private List<string> GetSnomedM_value(RadDropDownList cmb)
        {
            List<string> SM_list = new List<string>();
            SM_list.AddRange(new List<string>
                {
                    GetSnmdVal(cmbSM1),
                    GetSnmdVal(cmbSM2),
                });
            return SM_list;

        }

        private string GetSnmdVal(RadDropDownList cmb)
        {
            if (cmb.SelectedItem != null)
            {
                PHRASE_ENTRY snmd = cmb.SelectedItem.DataBoundItem as PHRASE_ENTRY;
                if (snmd != null)
                {
                    if (snmd.PHRASE_DESCRIPTION != cmb.Text)
                    {
                        return (cmb.Text);

                    }
                    return (snmd.PHRASE_NAME);
                }
            }
            else
            {
                return (cmb.Text);
            }
            return "";
        }

        internal void ClearScreen()
        {
            cmbST1.SelectedValue = null;
            cmbST2.SelectedValue = null;
            cmbSM1.SelectedValue = null;
            cmbSM2.SelectedValue = null;
            radTextBoxSignBy1.Text = null;
            radTextBoxSignBy2.Text = null;
            radRadioButtonSendToSecondSign.IsChecked = false;
            radRadioButtonDistribute.IsChecked = true;
            cbMalig.IsChecked = false;
            radDropDownListSecondSign.SelectedValue = null;
        }

        internal bool ContainsResult(string rn)
        {
            return _result2Snomed.ContainsKey(rn);
        }

        internal void EmptyAllCombos()
        {
            cmbST1.Text = string.Empty;
            cmbST2.Text = string.Empty;
            cmbSM1.Text = string.Empty;
            cmbSM2.Text = string.Empty;
        }

        internal void LoadSnomedResults(List<WrapperRtf> currentResults)
        {
            var snomedResults1 = from res in currentResults where res.TestName == "SNOMED" select res;

            //LOADS     snomed TO LIST
            foreach (var res in snomedResults1)
            {
                var rr = currentResults.FirstOrDefault(x => x.ResultId == res.ResultId);
                if (rr != null)
                {
                    if (_result2Snomed.ContainsKey(res.Name))
                    {
                        var ctl = _result2Snomed[res.Name];
                        RadCheckBox r = ctl as RadCheckBox;
                        if (r != null)
                        {
                            r.IsChecked = (res.Result_.FORMATTED_RESULT == "True" || res.Result_.FORMATTED_RESULT == "T");
                            continue;
                        }

                        RadSpinEditor spinEditor = ctl as RadSpinEditor;
                        if (spinEditor != null && res.Result_.FORMATTED_RESULT != null)
                        {
                            spinEditor.Value = decimal.Parse(res.Result_.FORMATTED_RESULT);

                        }

                        else //is combo box
                        {
                            PHRASE_ENTRY pe_res = null;
                            RadDropDownList CMB = ctl as RadDropDownList;
                            if (res.Name == Constants.SnomedM)
                            {
                                LoadSnomedM(res);
                            }
                            else if (res.Name == Constants.SnomedT)
                            {
                                LoadSnomedT(res);
                            }
                        }
                    }
                }
            }

        }

        private void LoadSnomedM(WrapperRtf res)
        {
            var typ = res.Result_.FORMATTED_RESULT;
            if (typ != null)
            {
                var split = typ.Split(new char[] { ';' }, 2);
                if (split.Length > 0)
                    LoadSnmdInner(_sMList, cmbSM1, split[0]);

                if (split.Length > 1)
                    LoadSnmdInner(_sMList, cmbSM2, split[1].Replace(";", ""));
            }
        }

        private void LoadSnomedT(WrapperRtf res)
        {
            var typ = res.Result_.FORMATTED_RESULT;
            if (typ != null)
            {
                var split = typ.Split(new char[] { ';' }, 2);
                if (split.Length > 0)
                    LoadSnmdInner(_sTList, cmbST1, split[0]);

                if (split.Length > 1)
                    LoadSnmdInner(_sTList, cmbST2, split[1].Replace(";", ""));
            }
        }

        private void LoadSnmdInner(List<PHRASE_ENTRY> snmdList, RadDropDownList cmb, string existsVal)
        {
            var p = (snmdList.FirstOrDefault(x => x.PHRASE_NAME == existsVal));
            if (p != null)
            {
                cmb.SelectedValue = existsVal;
            }
            else
            {
                cmb.Text = existsVal;
            }

        }

        internal void LoadSdgDetails(SDG sdg)
        {
            this._sdg = sdg;

        }

        internal void EnableControls(bool p)
        {
            this.Controls.OfType<RadDropDownList>().Foreach(x => x.Enabled = p);
            grp_snomedM.Controls.OfType<RadDropDownList>().Foreach(x => x.Enabled = p);
            grp_snomedT.Controls.OfType<RadDropDownList>().Foreach(x => x.Enabled = p);

            cbMalig.Enabled = p;

        }


        private void snomedCtrl_Load(object sender, EventArgs e)
        {

        }

        private void AuthorizePopUpForm_Load(object sender, EventArgs e)
        {
            //snomedCtrl.ClearScreen();
        }

        public class CustomComparer : IComparer<RadListDataItem>
        {
            public int Compare(RadListDataItem first, RadListDataItem second)
            {
                try
                {
                    var item1 = Regex.Match(first.Text, @"[1-9]{1}\d*");
                    var item2 = Regex.Match(second.Text, @"[1-9]{1}\d*");

                    if (!item1.Success)
                        return 1;

                    if (!item2.Success)
                        return -1;

                    int a;
                    int b;

                    if (item1.Value.Length > item2.Value.Length)
                    {
                        a = Convert.ToInt32(item1.Value.Substring(0, item2.Value.Length));
                        b = Convert.ToInt32(item2.Value);
                    }
                    else
                    {
                        b = Convert.ToInt32(item2.Value.Substring(0, item1.Value.Length));
                        a = Convert.ToInt32(item1.Value);
                    }

                    return a - b;
                }
                catch
                {
                    return 0;
                }
            }
        }

        private void radRadioButtonSendToSecondSign_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            radDropDownListSecondSign.Visible = radRadioButtonSendToSecondSign.IsChecked;

            //if (!radRadioButtonSendToSecondSign.IsChecked)
            //{
            //    radDropDownListSecondSign.SelectedIndex = -1;

            //    if (!string.IsNullOrEmpty(malignantMessage) && radRadioButtonSendToSecondSign.Visible && saveSnomed)
            //    {
            //        var result = MessageBox.Show("העבר להפצה ללא חתימה שנייה?", "העבר להפצה", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            //        if (result == DialogResult.No)
            //        {
            //            radRadioButtonSendToSecondSign.IsChecked = true;
            //        }
            //    }
            //}
        }

        private void cmbSM1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            var selected = cmbSM1.SelectedItem;

            if (selected != null)
            {
                Logger.WriteLogFile(" selected != null ");

                var res = selected.DataBoundItem as PHRASE_ENTRY;
                if (res != null)
                {
                    this.cbMalig.Checked = res.PHRASE_INFO.Trim().Equals("y") ? true : false;
                    if (res.PHRASE_INFO.Trim().Equals("y"))
                    {
                        Logger.WriteLogFile(_sdg.SDG_USER.U_PATHOLAB_NUMBER + " ממאיר ");
                        malignantMessage = string.Format("{0}{1}ממאיר!", res.PHRASE_DESCRIPTION, Environment.NewLine);
                        if (_sdg != null)
                        {
                            Logger.WriteLogFile(_sdg.SDG_USER.U_PATHOLAB_NUMBER + " doesnt null ");
                            if (_sdg.SDG_USER.U_WEEK_NBR != 707)
                            {
                                Logger.WriteLogFile(_sdg.SDG_USER.U_PATHOLAB_NUMBER + " weekNbr: " + _sdg.SDG_USER.U_WEEK_NBR);
                            }
                        }
                        radRadioButtonSendToSecondSign.IsChecked = (_sdg != null && _sdg.SDG_USER.U_WEEK_NBR != 707) ? true : false;
                    }
                    else
                    {
                        malignantMessage = string.Empty;
                    }
                }
            }
            else
            {
                Logger.WriteLogFile(" selected == null ");
                malignantMessage = string.Empty;
            }
        }

        private void cbMalig_MouseUp(object sender, MouseEventArgs e)
        {
            //Value changed by user
            if (cbMalig.IsChecked == false)
            {
                //Doesn't allow user to set false if value is y
                var SM_list = GetSnomedM_valueObj();
                var malignantValue = SM_list.Any(sn => sn.PHRASE_INFO == "y");
                cbMalig.IsChecked = malignantValue;
            }
        }

        private List<PHRASE_ENTRY> GetSnomedM_valueObj()
        {

            List<PHRASE_ENTRY> SM_list = new List<PHRASE_ENTRY>();
            if (cmbSM1.SelectedItem != null)
            {
                PHRASE_ENTRY snomedM = cmbSM1.SelectedItem.DataBoundItem as PHRASE_ENTRY;
                if (snomedM != null)
                {
                    SM_list.Add(snomedM);
                }
            }

            if (cmbSM2.SelectedItem != null)
            {
                PHRASE_ENTRY snomedM = cmbSM2.SelectedItem.DataBoundItem as PHRASE_ENTRY;
                if (snomedM != null)
                {
                    SM_list.Add(snomedM);
                }
            }

            return SM_list;
        }

        private void radRadioButtonDistribute_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            radDropDownListSecondSign.Visible = radRadioButtonSendToSecondSign.IsChecked;

            if (!radRadioButtonSendToSecondSign.IsChecked)
            {
                radDropDownListSecondSign.SelectedIndex = -1;
                Logger.WriteLogFile("malignantMessage: " + malignantMessage + " ; radRadioButtonSendToSecondSign.Visible: " + radRadioButtonSendToSecondSign.Visible + " ; saveSnomed: " + saveSnomed);

                if (!string.IsNullOrEmpty(malignantMessage) && radRadioButtonSendToSecondSign.Visible && saveSnomed)
                {
                    var result = MessageBox.Show("העבר להפצה ללא חתימה שנייה?", "העבר להפצה", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                    if (result == DialogResult.No)
                    {
                        radRadioButtonSendToSecondSign.IsChecked = true;
                    }
                }
            }
        }


    }
}
