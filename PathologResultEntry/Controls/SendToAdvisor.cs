using LSSERVICEPROVIDERLib;
using Patholab_DAL_V1;
using Patholab_DAL_V1.Enums;
using PathologResultEntry.Controls.Extra_req_Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using Patholab_Common;
using static System.Net.Mime.MediaTypeNames;

namespace PathologResultEntry.Controls
{
    public partial class SendToAdvisor : Form
    {
        private INautilusServiceProvider _sp;
        private INautilusUser _ntlsUser;
        private DataLayer _dal;
        private SDG _sdg;
        private string _userName;
        public List<OPERATOR> Operators;
        private const int TreeItemHeight = 19;
        private Dictionary<string, bool> canSendToAdvisor;
        private Dictionary<string, string> exrqstatusList;
        public List<AdviseRequest> ListAdviseRequests;
        public SDG_DETAILS sdgDetails;
        long _SessionId;
        private INautilusDBConnection _ntlsCon;



        #region Initilaize

        public SendToAdvisor(DataLayer dal, SDG sdg, INautilusServiceProvider sp, INautilusUser ntlsUser, long sid, ListData ld, string userName)
        {
            this.Text = sdg.NAME;
            this._dal = dal;
            this._sdg = sdg;
            this._sp = sp;
            this._userName = userName;

            _ntlsUser = ntlsUser;


            _ntlsCon = Utils.GetNtlsCon(_sp);
            _SessionId = (long)_ntlsCon.GetSessionId();



            InitializeComponent();
            //sdgTree.ItemHeight = TreeItemHeight;
            canSendToAdvisor = new Dictionary<string, bool>();
            Operators = dal.GetAll<OPERATOR>().Include(a => a.OPERATOR_USER).ToList();
            exrqstatusList = dal.GetPhraseByName("Extra Request Status").PhraseEntriesDictonary;

            LoadAdvisor();


            //oriyat 12/16/22
            LoadTree();
            loadListAdviseRequests();

        }
        
        private void LoadAdvisor()
        {

            var AdvisorQuery = from item in _dal.FindBy<LIMS_ROLE>(OPE => OPE.NAME == "External Advisor Digital")
                               select item.OPERATORs1;

            foreach (var DD in AdvisorQuery.ToList())
            {
                foreach (var op in DD)
                {
                    if (op.NAME != _userName)
                    {
                        Advisor adv = new Advisor(op);
                        this.lbox_advisers.Items.Add(adv);
                    }

                }

                lbox_advisers.DisplayMember = "operatorName";
            }

        }

        private void loadListAdviseRequests()
        {

            listViewRequests.Items.Clear();
            ListAdviseRequests = (from ru in _sdg.U_EXTRA_REQUEST_USER
                                  from rdu in ru.U_EXTRA_REQUEST.U_EXTRA_REQUEST_DATA_USER
                                  where rdu.U_REQ_TYPE == "T"
                                  orderby ru.U_CREATED_ON descending
                                  select new AdviseRequest
                                  {
                                      ID = rdu.U_EXTRA_REQUEST_DATA_ID,
                                      CreatedBy = Operators.FirstOrDefault(x => x.OPERATOR_ID == ru.U_CREATED_BY.Value).FULL_NAME,
                                      OpenedFor = rdu.U_REQUEST_DETAILS,//Operators.FirstOrDefault(x => x.NAME == rdu.U_REQUEST_DETAILS).FULL_NAME, 
                                      Status = rdu.U_STATUS,
                                      CreatedOn = ru.U_CREATED_ON,
                                      Remarks = rdu.U_REMARKS

                                  }).ToList();

            foreach (var adviseReq in ListAdviseRequests)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Name = adviseReq.ID.ToString();
                lvi.Text = adviseReq.CreatedBy != null ? adviseReq.CreatedBy : "";
                lvi.SubItems.Add(adviseReq.OpenedFor != null ? adviseReq.OpenedFor : "");
                lvi.SubItems.Add(adviseReq.Status == null || !exrqstatusList.ContainsKey(adviseReq.Status) ? "" : exrqstatusList[adviseReq.Status]);
                lvi.SubItems.Add(adviseReq.Remarks != null ? adviseReq.Remarks : "");
                lvi.SubItems.Add(adviseReq.CreatedOn.Value != null ? adviseReq.CreatedOn.Value.ToShortDateString() : "");
                listViewRequests.Items.Add(lvi);
            }
        }

        //Load sdg
        private void LoadTree()
        {
            //Clear
            canSendToAdvisor.Clear();

            sdgTree.Nodes.Clear();
            string path = Patholab_Common.Utils.GetResourcePath();
            sdgTree.Nodes.Add(_sdg.NAME);
            var icon = new Bitmap(Path.Combine(path, "sdg" + _sdg.STATUS + ".ico"));
            sdgTree.Nodes[_sdg.NAME].Image = icon;

            if (!canSendToAdvisor.ContainsKey(_sdg.NAME))
                canSendToAdvisor.Add(_sdg.NAME, _sdg.STATUS != "X");



            var samples = _dal.FindBy<SAMPLE>(sm => sm.SDG_ID == _sdg.SDG_ID);

            foreach (var sample in samples)
            {
                sdgTree.FindNodes(_sdg.NAME).First().Nodes.Add(sample.NAME);
                sdgTree.FindNodes(sample.NAME).First().Image = new Bitmap(Path.Combine(path + "sample" + sample.STATUS + ".ico"));

                if (!canSendToAdvisor.ContainsKey(sample.NAME))
                    canSendToAdvisor.Add(sample.NAME, sample.STATUS != "X");

                //Get blocks
                var blocks = sample.ALIQUOTs.Where(x => x.ALIQ_FORMULATION_PARENT.Count < 1).OrderBy(al => al.ALIQUOT_ID);


                foreach (var aliquot in blocks)
                {
                    int e11 = 11;
                    var bw = (new BlockWrapper()
                    {
                        sample =
                        aliquot.NAME.Substring(e11, 1),// aliquot.NAME.Length - 3, 1 ),
                        block =
                        aliquot.NAME.Substring(e11, aliquot.NAME.Length - e11)
                        ,
                        AliquotStatus = aliquot.STATUS
                    });


                    sdgTree.FindNodes(sample.NAME).First().Nodes.Add(aliquot.NAME);
                    var nd = sdgTree.FindNodes(aliquot.NAME).First();
                    if (nd != null)
                    {

                        nd.Image = new Bitmap(Path.Combine(path + "aliquot" + aliquot.STATUS + ".ico"));
                    }

                    if (!canSendToAdvisor.ContainsKey(aliquot.NAME))
                        canSendToAdvisor.Add(aliquot.NAME, aliquot.STATUS != "X");

                    //Get Slides
                    var children = aliquot.ALIQ_FORMULATION_CHILD.OrderBy(a => a.CHILD_ALIQUOT_ID);
                    foreach (var child in children)
                    {
                        string nodeName = string.Format("{0} ({1})"
                            , child.PARENT.NAME,
                            child.PARENT.ALIQUOT_USER.U_COLOR_TYPE);

                        nd.Nodes.Add(nodeName);
                        sdgTree.FindNodes(nodeName).First().Image = new Bitmap
                            (Path.Combine(path + "aliquot" + child.PARENT.STATUS + ".ico"));

                        if (!canSendToAdvisor.ContainsKey(child.PARENT.NAME))
                            canSendToAdvisor.Add(child.PARENT.NAME, child.PARENT.STATUS != "X");

                    }

                }
            }
            sdgTree.ExpandAll();
        }


        #endregion

        //private void btnAddSynamic_Click(object sender, EventArgs e)
        //{
        //    if (sdgTree.SelectedNode != null)
        //    {
        //        string nameOnly = sdgTree.SelectedNode.Text.Split('(')[0].Trim();

        //        if (canSendToAdvisor.ContainsKey(nameOnly))
        //        {
        //            if (canSendToAdvisor[nameOnly])
        //            {
        //                if (!lbox_entities.Items.Contains(nameOnly))
        //                    lbox_entities.Items.Add(nameOnly);
        //            }
        //            else
        //            {
        //                int dots = 0;
        //                foreach (char c in nameOnly)
        //                {
        //                    if (c == '.')
        //                        dots++;
        //                }

        //                string entityType;
        //                if (dots == 1) entityType = "Sample";
        //                else if (dots == 2) entityType = "Block";
        //                else entityType = "Slide";


        //                MessageBox.Show(string.Format("Can't send canceled {0} to advisor.", entityType));
        //            }
        //        }
        //    }

        //    lblCont4adv.Text = lbox_entities.Items.Count.ToString();
        //}

        //private void btnRemoveDynamic_Click(object sender, EventArgs e)
        //{
        //    if (lbox_entities.SelectedItem != null)
        //    {
        //        lbox_entities.Items.Remove(lbox_entities.SelectedItem);
        //    }
        //    lblCont4adv.Text = lbox_entities.Items.Count.ToString();
        //}

        //AE notice
        
        
        
        bool DEBUG = false;
        private void adviseRequest_Click(object sender, EventArgs e)
        {
            HideLabels();

            if (lbox_advisers.SelectedItem == null)
            {
                MessageBox.Show(" אנא בחר יועץ");
                return;
            }
            //if (lbox_entities.Items.Count < 1)
            //{
            //    MessageBox.Show(" אנא בחר ישות");
            //    return;
            //}


            //const string successMsg = "The request was saved successfully.";
            int countAddedRequest = 0;
            lblMsgAdv.Text = string.Empty;

            List<AdviseRequest> OpenAdvise = ListAdviseRequests.Where(x => x.Status == "V").ToList();

            //Get selected operator from list
            Advisor selectedAdv = lbox_advisers.SelectedItem as Advisor;
            if (selectedAdv == null) return;
            long opid = selectedAdv.opAdv.OPERATOR_ID;
            var entityName = _sdg.NAME;

            //error to check
            long currentOperatorId = Convert.ToInt64(_ntlsUser.GetOperatorId());
            if (OpenAdvise.Count()>0)
            {
                if (OpenAdvise.Where(x => x.OpenedFor == selectedAdv.opAdv.FULL_NAME).FirstOrDefault() != null)
                {
                    MessageBox.Show("קיימת התייעצות פתוחה ליועץ זה, לא ניתן לפתוח התייעצות חדשה", "Nautilus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    var dg = MessageBox.Show("קיימת התייעצות פתוחה למקרה, האם ברצונך לסגור אותה?", "Nautilus - סגירת התייעצות פתוחה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        //_dal.InsertToSdgLog(_sdg.SDG_ID, "PTG.CC", _SessionId, "מסך פתולוג - סיום התייעצות");
                        foreach (U_EXTRA_REQUEST_USER ru in _sdg.U_EXTRA_REQUEST_USER)
                        {
                            foreach (U_EXTRA_REQUEST_DATA_USER rdu in ru.U_EXTRA_REQUEST.U_EXTRA_REQUEST_DATA_USER.Where(x=>x.U_REQ_TYPE == "T").Where(y=> y.U_STATUS == "V"))
                            {
                                rdu.U_STATUS = "L";
                                
                                _dal.InsertToSdgLog(_sdg.SDG_ID, "PTG.CC", _SessionId, "מסך פתולוג - סיום התייעצות");
                            }
                        }


                    }
                    else
                    {
                        return;
                    }
                }

            }

            _dal.InsertToSdgLog(_sdg.SDG_ID, "PTG.NC", _SessionId, "פתיחת התייעצות");
            string req_detailes = selectedAdv.opAdv.FULL_NAME ;
            _dal.Ex_Req_Logic(_sdg.SDG_ID, entityName, ExtraRequestType.T, currentOperatorId, req_detailes, textBoxRemarks.Text);
            _dal.SaveChanges();
            lblMsgAdv.Text += Environment.NewLine + entityName + " added successfully.";
            countAddedRequest++;
            lblMsgAdv.Visible = true;
            textBoxRemarks.Text = null;
            loadListAdviseRequests();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void HideLabels()
        {
            lblMsgAdv.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
