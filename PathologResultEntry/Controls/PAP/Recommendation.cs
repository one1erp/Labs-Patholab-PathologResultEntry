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
    public partial class Recommendation : UserControl, IPapResults
    {
        private ListData ld;
        private Dictionary<string, RadControl> _result2Recom;

        public Recommendation()
        {
            InitializeComponent();
            cmbHpvSignBy.Tag = PapConstants.HPV_TAG;
        }
        public Dictionary<string, RadControl> GetReultsControls()
        {
            return _result2Recom;
        }
        public void LoadResultList()
        {
            _result2Recom = new Dictionary<string, RadControl>
                {

                    {PapConstants.Malignant,cbMalig },
                    {PapConstants.Recommendation1,cmbRecom1 },
                    {PapConstants.Recommendation2,cmbRecom2 },
                    {PapConstants.Sign_by_1_screener,cmbSc1st },
                    {PapConstants.Sign_by_2_screener,cmbSc2nd },
                    {PapConstants.SignbyPatholog,cmbSignPatholog },
                    {PapConstants.HpvSignBy,cmbHpvSignBy }

            };

        }

       

        public void InitilaizeData(ListData listData)
        {

            this.ld = listData;

            var recList = ld.SetPhrase2Combo(cmbRecom1, "Paps Recommendation 2");
            ld.SetExistsList2Combo(cmbRecom2, recList);

            var PatList = ld.SetPhrase2Combo(cmbSignPatholog, "Sign By");
            ld.SetExistsList2Combo ( cmbHpvSignBy, PatList );


            var scList = ld.SetPhrase2Combo(cmbSc1st, "Sign By Screener");
            ld.SetExistsList2Combo(cmbSc2nd, scList);

        }





        private string testName = "Recommendations";

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }
     

        private void Recommendation_VisibleChanged ( object sender, EventArgs e )
        {
       cmbRecom1.Focus ( );
        }

    }
}
