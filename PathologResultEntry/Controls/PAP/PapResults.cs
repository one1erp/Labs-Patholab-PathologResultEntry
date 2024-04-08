using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patholab_Common;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Patholab_DAL_V1;

namespace PathologResultEntry.Controls.PAP
{
    public partial class PapResults : UserControl, IPapResults
    {
        private ListData ld;

        public PapResults()
        {
            InitializeComponent();
        }
        private Dictionary<string, RadControl> _result2Test;



        internal Dictionary<string, RadControl> ClinicResults
        {
            get { return _result2Test; }
            set { _result2Test = value; }
        }

        public void LoadResultList()
        {
            _result2Test = new Dictionary<string, RadControl>
                {

                    {PapConstants.ResultNeg1,cmbRN1 },
                    {PapConstants.ResultNeg2,cmbRN2 },
                    {PapConstants.ResultNeg3,cmbRN3 },
                    {PapConstants.ResultNeg4,cmbRN4 },
                    {PapConstants.ResultPos1,CmbRP1 },
                    {PapConstants.ResultPos2,CmbRP2 },
                    {PapConstants.ResultPos3,CmbRP3 },
                    {PapConstants.ResultPos4,CmbRP4 },
                   {PapConstants.Remarks1,cmbRem1 },
                    {PapConstants.Remarks2,cmbRem2 },
                    {PapConstants.Remarks3,cmbRem3 },
                    {PapConstants.Remarks4,cmbRem4 },

            };
        }
        private string testName = "Results";

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }
     
        public Dictionary<string, RadControl> GetReultsControls()
        {
            return _result2Test;
        }
        public void InitilaizeData(ListData listData)
        {

            this.ld = listData;


            var List1 = ld
             .SetPhrase2Combo(CmbRP4, "Paps Result Pos 2");
            ld.SetExistsList2Combo(CmbRP1, List1);
            ld.SetExistsList2Combo(CmbRP3, List1);
            ld.SetExistsList2Combo(CmbRP2, List1);

            var List2 = ld
              .SetPhrase2Combo(cmbRN1, "Paps Result Neg");
            ld.SetExistsList2Combo(cmbRN2, List2);
            ld.SetExistsList2Combo(cmbRN3, List2);
            ld.SetExistsList2Combo(cmbRN4, List2);

            var List = ld
                 .SetPhrase2Combo(cmbRem1, "Paps Remark 2");
            ld.SetExistsList2Combo(cmbRem2, List);
            ld.SetExistsList2Combo(cmbRem3, List);
            ld.SetExistsList2Combo(cmbRem4, List);




        }


     

        private void PapResults_VisibleChanged ( object sender, EventArgs e )
        {
  cmbRN1.Focus ( );
        }
    }
}
