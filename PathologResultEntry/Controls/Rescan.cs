using LSSERVICEPROVIDERLib;
using Patholab_DAL_V1;
using Patholab_DAL_V1.Enums;
using PathologResultEntry.Controls.Extra_req_Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;

namespace PathologResultEntry.Controls
{
    public partial class Rescan : Telerik.WinControls.UI.RadForm
    {
        private INautilusServiceProvider _sp;
        private INautilusUser _ntlsUser;
        private DataLayer _dal;
        private SDG _sdg;
        private long sid;
        private const int TreeItemHeight = 19;
        private Dictionary<string, bool> canRescan;

        #region Initilaize

        public Rescan(DataLayer dal, SDG sdg, INautilusServiceProvider sp, INautilusUser ntlsUser, long sid)
        {
            this._dal = dal;
            this._sdg = sdg;
            this._sp = sp;
            this.sid = sid;
            _ntlsUser = Patholab_Common.Utils.GetNautilusUser(_sp);

            InitializeComponent();
            sdgTree.ItemHeight = TreeItemHeight;
            canRescan = new Dictionary<string, bool>();
            LoadTree();
        }

        //Load sdg
        public void LoadTree()
        {
            //Clear
            sdgTree.Nodes.Clear();
            canRescan.Clear();

            string path = Patholab_Common.Utils.GetResourcePath();
            var samples = _dal.FindBy<SAMPLE>(sm => sm.SDG_ID == _sdg.SDG_ID);
            
            foreach (var sample in samples)
            {
                //Get blocks
                var blocks = sample.ALIQUOTs.Where(x => x.ALIQ_FORMULATION_PARENT.Count < 1).OrderBy(al => al.ALIQUOT_ID);

                foreach (var aliquot in blocks)
                {
                    sdgTree.Nodes.Add(aliquot.NAME);

                    if(!canRescan.ContainsKey(aliquot.NAME))
                        canRescan.Add(aliquot.NAME, aliquot.STATUS != "X");

                    var nd = sdgTree.FindNodes(aliquot.NAME).First();

                    if (nd != null)
                        nd.Image = new Bitmap(Path.Combine(path + "aliquot" + aliquot.STATUS + ".ico"));

                    //Get Slides
                    var children = aliquot.ALIQ_FORMULATION_CHILD.OrderBy(a => a.CHILD_ALIQUOT_ID);

                    foreach (var child in children)
                    {
                        string nodeName = string.Format("{0} ({1})", child.PARENT.NAME, child.PARENT.ALIQUOT_USER.U_COLOR_TYPE);

                        nd.Nodes.Add(nodeName);

                        if (!canRescan.ContainsKey(child.PARENT.NAME))
                            canRescan.Add(child.PARENT.NAME, child.PARENT.STATUS != "X");

                        sdgTree.FindNodes(nodeName).First().Image = new Bitmap(Path.Combine(path + "aliquot" + child.PARENT.STATUS + ".ico"));
                    }
                }
            }

            sdgTree.ExpandAll();
        }


        #endregion

        private void btnAddSynamic_Click(object sender, EventArgs e)
        {
            if (sdgTree.SelectedNode != null)
            {
                string nameOnly = sdgTree.SelectedNode.Text.Split('(')[0].Trim();

                if (canRescan.ContainsKey(nameOnly))
                {
                    if (canRescan[nameOnly])
                    {
                        if (!lbox_entities.Items.Contains(nameOnly))
                            lbox_entities.Items.Add(nameOnly);
                    }
                    else
                    {
                        MessageBox.Show("Can't send canceled slide to rescan.");
                    }
                }
            }

            lblCont4adv.Text = lbox_entities.Items.Count.ToString();
        }

        private void btnRemoveDynamic_Click(object sender, EventArgs e)
        {
            if (lbox_entities.SelectedItem != null)
            {
                lbox_entities.Items.Remove(lbox_entities.SelectedItem);
            }

            lblCont4adv.Text = lbox_entities.Items.Count.ToString();
        }

        private void btnSendRescan_Click(object sender, EventArgs e)
        {
            HideLabels();

            if (lbox_entities.Items.Count < 1)
            {
                MessageBox.Show(" אנא בחר ישות");
                return;
            }

            const string successMsg = "The request was saved successfully.";
            int countAddedRequest = 0;
            lblMsgAdv.Text = string.Empty;

            foreach (var item in lbox_entities.Items)
            {
                var entityName = item.ToString();
       //         EntityType entityType = EntityType.Slide;
                long currentOperator = Convert.ToInt64(_ntlsUser.GetOperatorId());
                var remarks = textBoxDetails.Text;
                


                // check if the request is already exist
                var request = _dal.FindBy<U_EXTRA_REQUEST_DATA_USER>(erdu => erdu.U_SLIDE_NAME.Equals(entityName) && !erdu.U_STATUS.Equals("X") && erdu.U_EXTRA_REQUEST.NAME.Contains("Rescan")).FirstOrDefault();
                if (request != null)
                {
                    lblMsgAdv.Text += Environment.NewLine + entityName + " already has Rescan request.";
                    continue;
                }
                
                _dal.Ex_Req_Logic(_sdg.SDG_ID, entityName, ExtraRequestType.S, currentOperator, "Rescan", remarks);
                setAliquotStationField(entityName);

                lblMsgAdv.Text += Environment.NewLine + entityName + " added successfully.";
                countAddedRequest++;
            }

            LoadTree();
            lblMsgAdv.Text = countAddedRequest == lbox_entities.Items.Count ? successMsg : lblMsgAdv.Text;
            lblMsgAdv.Visible = true;
        }

        private void setAliquotStationField(string aliquotName)
        {
            try
            {
                var aliquotUser = _dal.FindBy<ALIQUOT_USER>(a => a.ALIQUOT.NAME.Equals(aliquotName)).FirstOrDefault();

                if (aliquotUser != null)
                {
                    var currentStation = aliquotUser.U_ALIQUOT_STATION;
                    aliquotUser.U_ALIQUOT_STATION = "131";

                    if (currentStation != null)
                    {
                        aliquotUser.U_OLD_ALIQUOT_STATION += currentStation;
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void HideLabels()
        {
            lblMsgAdv.Visible = false;
        }
    }
}
