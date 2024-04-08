using LSSERVICEPROVIDERLib;
using Patholab_DAL_V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathologResultEntry.Controls
{
    public partial class canceled_AuthorizePopUpForm : Form
    {
        public string userResult = string.Empty;


        private string _currentUserName;
        private long _SessionId;
        private DataLayer _dal;


        public canceled_AuthorizePopUpForm(long SessionId, string UserName, DataLayer d)
        {
            InitializeComponent();
            this._SessionId = SessionId;
            this._currentUserName = UserName;
            this._dal = d;
            LoadSnomedData();
        }

        internal void LoadSignatures(DataLayer dal, List<RESULT> signatures)
        {
            this.snomedCtrl.LoadSignatures(dal, signatures);

        }

        private void LoadSnomedData()
        {



            if (snomedCtrl._sMList == null || snomedCtrl._sTList == null)
            {
                snomedCtrl.InitilaizeData(_SessionId,_dal, _currentUserName);
            }
            else
            {
                snomedCtrl.InitilaizeData();
            }
        }

        public void init(bool firstSignExists, bool IsReadyForDistribute)
        {
            snomedCtrl.setRadioButtonsVisibility(firstSignExists, IsReadyForDistribute);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
            snomedCtrl.ClearScreen();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string msg = CanAuthorise();

            if (string.IsNullOrEmpty(msg))
            {
                userResult = snomedCtrl.WeekNbrStatus;

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
            string msg = string.Empty;

            msg += snomedCtrl.CanAuthorise();

            return msg;
        }

        private void AuthorizePopUpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                snomedCtrl.saveSnomed = false;
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                snomedCtrl.saveSnomed = true;
            }

        }

        private void AuthorizePopUpForm_Shown(object sender, EventArgs e)
        {
            snomedCtrl.showMalignantMessage();
        }

        internal bool CheckIfOperatorSigned(List<RESULT> signatures, string v)
        {
            return
                  snomedCtrl.CheckIfOperatorSigned(signatures, v);
        }

        internal void snomedVisible(bool v)
        {
            snomedCtrl.saveSnomed = v;

        }

        internal void SaveSnomedTab(SDG_DETAILS sdgDetails, List<WrapperRtf> currentResults, RESULT resultToSign,
            INautilusUser ntlsUser, DataLayer dal, bool loggedInOperatorSigned)
        {
            snomedCtrl.SaveSnomedTab(sdgDetails, currentResults, resultToSign, ntlsUser,  loggedInOperatorSigned);
        }

        internal void ClearScreen()
        {
            snomedCtrl.ClearScreen();
        }

        internal bool ContainsResult(string rn)
        {
            return snomedCtrl.ContainsResult(rn);
        }

        internal void EmptyAllCombos()
        {
            snomedCtrl.EmptyAllCombos();
        }

        internal void LoadSnomedResults(List<WrapperRtf> currentResults)
        {
            snomedCtrl.LoadSnomedResults(currentResults);

        }

        internal void LoadSdgDetails(SDG sdg)
        {
            snomedCtrl.LoadSdgDetails(sdg);

        }

        internal void EnableControls(bool p)
        {
            snomedCtrl.EnableControls(p);

        }

        private void snomedCtrl_Load(object sender, EventArgs e)
        {

        }

        private void AuthorizePopUpForm_Load(object sender, EventArgs e)
        {
            //snomedCtrl.ClearScreen();
        }
    }
}
