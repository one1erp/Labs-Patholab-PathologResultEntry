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
using Patholab_DAL_V1;
using Telerik.WinControls;

namespace PathologResultEntry.Controls.PAP
{
    public partial class Clinical : UserControl, IPapResults
    {
        private ListData ld;
        private Dictionary<string, RadControl> _result2Clinical;
        private List<PHRASE_ENTRY> _clinicPhrase { get; set; }


        //internal Dictionary<string, RadControl> ClinicResults
        //{
        //    get { return _result2Clinical; }
        //    set { _result2Clinical = value; }
        //}
     
 
                
        private string testName = "Clinical info";

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }
      
        public Clinical()
        {
            InitializeComponent();

        }
        public Dictionary<string, RadControl> GetReultsControls()
        {
            return _result2Clinical;
        }
        public void LoadResultList()
        {
            _result2Clinical = new Dictionary<string, RadControl>
                {

                    {PapConstants.ClinicalInformation1,cmbcli1 },
                    {PapConstants.ClinicalInformation2,cmbcli2 },
                    {PapConstants.ClinicalInformation3,cmbcli3 },
                    {PapConstants.ClinicalInformation4,cmbcli4 },
                    {PapConstants.ClinicalInformation5,cmbcli5 },
            
                    {PapConstants.Clinical_PapSpecimenType,cmdChoType },

            };
        }




        public void InitilaizeData(ListData listData)
        {

            this.ld = listData;

            _clinicPhrase = ld
            .SetPhrase2Combo(cmbcli1, "Clinical Information");
            ld.SetExistsList2Combo(cmbcli2, _clinicPhrase);
            ld.SetExistsList2Combo(cmbcli3, _clinicPhrase);
            ld.SetExistsList2Combo(cmbcli4, _clinicPhrase);
            ld.SetExistsList2Combo(cmbcli5, _clinicPhrase);
            //   ld.SetExistsList2Combo(cmbcli6, _clinicPhrase);

            var spec = ld.SetPhrase2Combo(cmdChoType, "Pap specimen type");



        }









        #region IPapResults Members



        #endregion

        private void cmbcli1_VisibleChanged ( object sender, EventArgs e )
        {
            
            cmbcli1.Focus ( );

        }
    }


}
