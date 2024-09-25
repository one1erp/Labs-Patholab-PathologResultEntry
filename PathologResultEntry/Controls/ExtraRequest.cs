using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Patholab_DAL_V1;
using System.IO;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using LSSERVICEPROVIDERLib;
using System.Text.RegularExpressions;
using PathologResultEntry.Controls.Extra_req_Entities;
using Patholab_Common;
using Patholab_DAL_V1.Enums;
using System.Diagnostics;
using Patholab_XmlService;

namespace PathologResultEntry.Controls
{
    public partial class ExtraRequest : Form
    {

        #region Fields

        public bool HasReq { get; set; }
        public List<OPERATOR> Operators;
        List<BlockWrapper> blockWrappers;
        private DataLayer _dal;
        private SDG _sdg;
        private INautilusServiceProvider _sp;
        private INautilusUser _ntlsUser;
        private INautilusDBConnection _ntlsCon;
        const string ADD_SLIDE = "Add Slide";
        private long sid;
        public List<int> QuantityColList { get; set; }
        private Dictionary<string, string> exrqstatusList;
        private FrmColor colormin;
        private const int TreeItemHeight = 19;

        private string title;
        BlockWrapper selectedBlock;
        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        #endregion  private

        #region Initilaize
        public ExtraRequest(DataLayer dal, SDG sdg, LSSERVICEPROVIDERLib.INautilusServiceProvider sp, INautilusUser ntlsUser, long sid, ListData ld)
        {
            blockWrappers = new List<BlockWrapper>();

            QuantityColList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this._dal = dal;
            this._sdg = sdg;
            this._sp = sp;
            this.sid = sid;
            this._ntlsUser = ntlsUser;
            _ntlsUser = Patholab_Common.Utils.GetNautilusUser(_sp);

            InitializeComponent();
            sdgTree.ItemHeight = TreeItemHeight;

            var userID = Convert.ToInt64(ntlsUser.GetOperatorId());
            var userName = dal.FindBy<OPERATOR>(op => op.OPERATOR_ID == userID).FirstOrDefault().FULL_NAME;

            //AE CODE
            FindCurrentAdvisor();
            if (existsOpenConsultation)
            {
                lblOpName.Text = currentAdvisorName;
            }
            else
            {
                lblOpName.Text = _sdg.SDG_USER.U_PATHOLOG == null ? userName : _sdg.SDG_USER.PATHOLOG.NAME;
            }

            exrqstatusList = dal.GetPhraseByName("Extra Request Status").PhraseEntriesDictonary;
            Operators = dal.GetAll<OPERATOR>().Include(a => a.OPERATOR_USER).ToList();

            LoadTree();
        }

        //Load sdg
        public void LoadTree()
        {

            //Clear
            blockWrappers.Clear();

            sdgTree.Nodes.Clear();
            string path = Patholab_Common.Utils.GetResourcePath();
            sdgTree.Nodes.Add(_sdg.NAME);
            var icon = new Bitmap(Path.Combine(path, "sdg" + _sdg.STATUS + ".ico"));
            sdgTree.Nodes[_sdg.NAME].Image = icon;

            _sdg = _dal.FindBy<SDG>(x => x.NAME == _sdg.NAME).FirstOrDefault();

            var samples = _dal.FindBy<SAMPLE>(sm => sm.SDG_ID == _sdg.SDG_ID).OrderBy(s => s.SAMPLE_ID);

            foreach (var sample in samples)
            {
                sdgTree.FindNodes(_sdg.NAME).First().Nodes.Add(sample.NAME);
                sdgTree.FindNodes(sample.NAME).First().Image = new Bitmap(Path.Combine(path + "sample" + sample.STATUS + ".ico"));

                //Get blocks
                var blocks = sample.ALIQUOTs.Where(x => x.ALIQ_FORMULATION_PARENT.Count < 1).OrderBy(al => al.ALIQUOT_ID);


                foreach (var aliquot in blocks)
                {
                    int e11 = 11;
                    var bw = (new BlockWrapper()
                    {
                        sample =
                           aliquot.NAME.Substring(e11, 1),
                        block =
                           aliquot.NAME.Substring(e11, aliquot.NAME.Length - e11)
                           ,
                        AliquotStatus = aliquot.STATUS
                    });
                    blockWrappers.Add(bw);

                    sdgTree.FindNodes(sample.NAME).First().Nodes.Add(aliquot.NAME);
                    var nd = sdgTree.FindNodes(aliquot.NAME).First();
                    if (nd != null)
                    {
                        nd.Image = new Bitmap(Path.Combine(path + "aliquot" + aliquot.STATUS + ".ico"));
                    }

                    //Get Slides

                    var aliquotChildren =_dal.FindBy<ALIQUOT_FORMULATION>(x => x.PARENT_ALIQUOT_ID == aliquot.ALIQUOT_ID).ToList().OrderBy(a => a.CHILD_ALIQUOT_ID);

                    var a_count = aliquotChildren.Count();


                    foreach (var child in aliquotChildren)
                    {
                        string nodeName = string.Format("{0} ({1})"
                            , child.PARENT.NAME,
                            child.PARENT.ALIQUOT_USER.U_COLOR_TYPE);

                        nd.Nodes.Add(nodeName);
                        sdgTree.FindNodes(nodeName).First().Image = new Bitmap
                            (Path.Combine(path + "aliquot" + child.PARENT.STATUS + ".ico"));
                    }
                }
            }

            FillGrid(blockWrappers);

            sdgTree.ExpandAll();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillGrid(List<BlockWrapper> blockWrappers)
        {
            gridBlocks.Rows.Clear();
            foreach (BlockWrapper wrapper in blockWrappers.Where(bl => !"XS".Contains(bl.AliquotStatus)))
            {
                var row = gridBlocks.Rows.AddNew();
                row.Cells[0].Value = wrapper.sample;
                row.Cells[1].Value = wrapper.block;
            }

            if (_sdg.SdgType == SdgType.Pap)
            {
                gridBlocks.Columns["cmdopen"].IsVisible = false;
            }
        }


        #endregion

        //Add slide
        private void btnAddSlideColor_Click(object sender, EventArgs e)
        {

            if (_ntlsCon == null)
            { _ntlsCon = Patholab_Common.Utils.GetNtlsCon(_sp); }
            _dal = new DataLayer();
            _dal.Connect(_ntlsCon);

            _sdg = _dal.FindBy<SDG>(x => x.SDG_ID == _sdg.SDG_ID).Include(x => x.SDG_USER).SingleOrDefault();

            HideLabels();

            if (blockWrappers.TrueForAll(x => x.Colors4add == null || x.Colors4add.Count == 0))
                return;

            foreach (BlockWrapper blockWrapper in blockWrappers)
            {

                if (blockWrapper.Colors4add == null)
                    continue;


                var selectedAliq = _sdg.NAME + "." + blockWrapper.block;

                ALIQUOT blockAliqParent = GetParentId(selectedAliq);


                foreach (var item in blockWrapper.Colors4add)
                {
                    for (int i = 0; i < item.Value; i++)
                    {
                        AddSlide(blockAliqParent, item.Key, blockWrapper.colors4addType[item.Key]);
                    }
                }

            }



            HideLabels();
            lblMessage.Visible = true;
            LoadTree();
        }

        private void AddSlide(ALIQUOT blockAliqParent, string color, string ColorsType)
        {
            //Create new slide by xml
            var addsildexml = new FireEventXmlHandler(_sp, ADD_SLIDE);
            addsildexml.CreateFireEventXml("ALIQUOT", blockAliqParent.ALIQUOT_ID, "Add Slide");
            var success = addsildexml.ProcssXml();
            if (!success)
            {
                MessageBox.Show("Error on add slide " + addsildexml.ErrorResponse);
                return;
            }
            else
            {
                try
                {
                    _dal.InsertToSdgLog(_sdg.SDG_ID, "EXTRA.CREATED", sid, "Add slide " + color);
                }
                catch (Exception e)
                {

                    Logger.WriteLogFile(e);
                    MessageBox.Show("Error on InsertToSdgLog" + e.Message);
                }

                var parentId = addsildexml.GetValueByTagName("ALIQUOT_ID");


                #region Leave this here maybe for production environment

                //Get block's children 
                var children = _dal.FindBy<ALIQUOT_FORMULATION>(x => x.PARENT_ALIQUOT_ID == blockAliqParent.ALIQUOT_ID)
                    .OrderByDescending(a => a.CHILD_ALIQUOT_ID);
                var asda = children.Count();

                //Update new slide name(override also the old aliquots)
                int cnt = 0;
                foreach (var child in children.OrderBy(a => a.CHILD_ALIQUOT_ID))
                {
                    cnt++;
                    child.PARENT.NAME = blockAliqParent.NAME + "." + cnt;
                }


                #endregion

                //Update the new slide color
                var new_aliq = children.OrderByDescending(a => a.CHILD_ALIQUOT_ID).First().PARENT;

                if (new_aliq == null)
                {
                    MessageBox.Show("New child is null??");
                    return;
                }

                new_aliq.ALIQUOT_USER.U_COLOR_TYPE = color;

                DateTime currentTime = DateTime.Now;
                long currentOperatorId = Convert.ToInt64(_ntlsUser.GetOperatorId());


                //AE CODE


                if (existsOpenConsultation)
                {
                    created_by_field = currentAdvisorID;
                    _dal.Ex_Req_Logic(_sdg.SDG_ID, new_aliq.NAME, ExtraRequestType.H, created_by_field, color, radTextBoxRemarks.Text);
                }
                else
                {
                    if (_sdg.SDG_USER.U_PATHOLOG == null)
                    {
                        created_by_field = currentOperatorId;
                        _dal.Ex_Req_Logic(_sdg.SDG_ID, new_aliq.NAME, ExtraRequestType.H, created_by_field, color, radTextBoxRemarks.Text);
                    }
                    else
                    {
                        created_by_field = _sdg.SDG_USER.U_PATHOLOG.Value;
                        _dal.Ex_Req_Logic(_sdg.SDG_ID, new_aliq.NAME, ExtraRequestType.H, created_by_field, color, radTextBoxRemarks.Text);

                    }

                }

                //DON'T CHANGE THE logDesc, IT'S BEEING USEDIN EXTRA_SLIDES VIEW
                string logDesc = $"block: {blockAliqParent.NAME} color type: {_dal.GetPartType(color)} Extra request for {created_by_field}";
                _dal.InsertToSdgLog(_sdg.SDG_ID, "Extra Request", sid, logDesc);
                _dal.SaveChanges();
            }
        }

        //AE CODE

        U_EXTRA_REQUEST_DATA_USER currentOpenConsultation = null;
        long currentAdvisorID;
        string currentAdvisorName;
        long created_by_field;
        bool existsOpenConsultation = false;

        private void FindCurrentAdvisor()
        {
            List<U_EXTRA_REQUEST_DATA_USER> currentSdgReqDataList = new List<U_EXTRA_REQUEST_DATA_USER>();
            try
            {

                var currentSdgReqList = _dal.FindBy<U_EXTRA_REQUEST_USER>(x => x.U_SDG_ID == _sdg.SDG_ID);

                foreach (U_EXTRA_REQUEST_USER a in currentSdgReqList)
                {
                    var currentSdgReqData = _dal.FindBy<U_EXTRA_REQUEST_DATA_USER>(x => x.U_EXTRA_REQUEST_ID == a.U_EXTRA_REQUEST_ID).FirstOrDefault();
                    currentSdgReqDataList.Add(currentSdgReqData);
                }

                currentOpenConsultation = currentSdgReqDataList.Find(a => a.U_REQ_TYPE.Equals("T") && a.U_STATUS.Equals("V"));

                if (currentOpenConsultation != null)
                {
                    existsOpenConsultation = true;
                    currentAdvisorName = _dal.FindBy<U_EXTRA_REQUEST_DATA_USER>(b => b.U_REQUEST_DETAILS.Equals(currentOpenConsultation.U_REQUEST_DETAILS)).FirstOrDefault().U_REQUEST_DETAILS;
                    currentAdvisorID = _dal.FindBy<OPERATOR>(a => a.FULL_NAME.Equals(currentAdvisorName)).FirstOrDefault().OPERATOR_ID;
                    created_by_field = currentAdvisorID;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error: " + ex.Message);
                Logger.WriteLogFile(ex);

            }
        }


        private ALIQUOT GetParentId(string selectedAliq)
        {
            foreach (var sample in _sdg.SAMPLEs)
            {
                foreach (var item in sample.ALIQUOTs)
                {
                    if (item.NAME == selectedAliq && item.ALIQ_FORMULATION_PARENT.Count < 1)

                    { return item; }
                }
            }
            return null;
        }

        #region Grid events

        private void gridExtraReq_UserDeletingRow(object sender, GridViewRowCancelEventArgs e)
        {
            ExWrapper exrq = (e.Rows[0]).DataBoundItem as ExWrapper;


            var b = _dal.FindBy<ALIQUOT>(al => al.NAME == exrq.Entity_NAME && al.STATUS == "V");
            if (b != null)
            {
                e.Cancel = true;
            }
            else
            {
                _dal.FindBy<U_EXTRA_REQUEST_DATA_USER>(x => x.U_EXTRA_REQUEST_DATA_ID == exrq.ID)
                               .FirstOrDefault().U_STATUS = "X";
                _dal.SaveChanges();
            }
        }

        #endregion



        void HideLabels()
        {
            lblMessage.Visible = false;
        }

        private void gridBlocks_CommandCellClick(object sender, EventArgs e)
        {
            if (this._sdg.SdgType == SdgType.Pap)
            {
                return;
            }

            HideLabels();

            var tx = ((Telerik.WinControls.UI.GridViewCellEventArgsBase)(e));
            var ali = tx.Row.Cells[1].Value;
            selectedBlock = blockWrappers.FirstOrDefault(x => x.block == (string)ali);
            if (selectedBlock == null) return;
            if (tx.ColumnIndex == 2)
            {

                if (colormin == null)
                {
                    colormin = new FrmColor(_dal, _sdg);

                }
                else
                {
                    colormin.LoadBlockData(selectedBlock.Colors4add);
                }
                colormin.ShowDialog();
                if (colormin.approved)
                {
                    selectedBlock.AddColors(colormin.SelectedColors);
                    tx.Row.Cells[3].Value = selectedBlock.Colostr;
                }
            }
            else if (tx.ColumnIndex == 4)
            {
                if (selectedBlock.Colors4add != null)
                {
                    selectedBlock.Colors4add.Clear();
                    tx.Row.Cells[3].Value = null;
                    tx.Row.Cells[3].Value = selectedBlock.Colostr;
                }
            }
        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}