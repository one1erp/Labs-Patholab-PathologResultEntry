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

namespace PathologResultEntry.Controls.PAP
{
    public partial class Adequency : UserControl, IPapResults
    {
        private ListData ld;

        private string testName = "Adequacy";

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }


        public Adequency ( )
        {
            InitializeComponent ( );
        }
        private Dictionary<string, RadControl> _result2Adeq;


        public void LoadResultList ( )
        {
            _result2Adeq = new Dictionary<string, RadControl>
                {
                      { PapConstants.ChooseAdeq,cmdAdequacyst },
                    {PapConstants.LessThanOptimal1,cmbLT1 },
                    {PapConstants.LessThanOptimal2,cmbLT2 },
                    {PapConstants.LessThanOptimal3,cmbLT3 },
                    {PapConstants.LessThanOptimal4,cmbLT4 },

                    { PapConstants.Unsatisfactory1,CmbUns1 },
                    {PapConstants.Unsatisfactory2,CmbUns2 },
                    {PapConstants.Unsatisfactory3,CmbUns3 },
                    {PapConstants.Unsatisfactory4,CmbUns4 }

              

            };
        }
        public void InitilaizeData ( ListData listData )
        {

            this.ld = listData;

            var adeq = ld.SetPhrase2Combo ( cmdAdequacyst, "Adequacy" );


            var ltList = ld
                 .SetPhrase2Combo ( cmbLT1, "Less Than Optimal" );
            ld.SetExistsList2Combo ( cmbLT2, ltList );
            ld.SetExistsList2Combo ( cmbLT3, ltList );
            ld.SetExistsList2Combo ( cmbLT4, ltList );

            var List = ld
                 .SetPhrase2Combo ( CmbUns1, "UnSatisfactory" );
            ld.SetExistsList2Combo ( CmbUns2, List );
            ld.SetExistsList2Combo ( CmbUns3, List );
            ld.SetExistsList2Combo ( CmbUns4, List );






        }
        public Dictionary<string, RadControl> GetReultsControls ( )
        {
            return _result2Adeq;
        }


        private void Adequency_VisibleChanged ( object sender, EventArgs e )
        {
            cmdAdequacyst.Focus ( );
        }

    

    }
}
