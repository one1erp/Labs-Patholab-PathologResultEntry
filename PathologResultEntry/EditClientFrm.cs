using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using LSSERVICEPROVIDERLib;
using Patholab_DAL_V1;
using Patholab_XmlService;
using Telerik.WinControls;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PathologResultEntry
{
    public partial class EditClientFrm :Form
    {

        private INautilusServiceProvider _sp;
        private Dictionary<string, string> _genderDic;
        private CLIENT client;
        public event Action<CLIENT> PatientEdited;

        public EditClientFrm(CLIENT client, Dictionary<string, string> genderDic, INautilusServiceProvider sp)
        {
            InitializeComponent();
            _genderDic = genderDic;
            _sp = sp;
            var cu = client.CLIENT_USER;
            TxtIdent.Text = client.NAME;
            txtFN.Text = cu.U_FIRST_NAME;
            txtLN.Text = cu.U_LAST_NAME;
            txtPrevLN.Text = cu.U_PREV_LAST_NAME;

            if (cu.U_DATE_OF_BIRTH != null)
                radDateTimePicker1.Value = cu.U_DATE_OF_BIRTH.Value;

            this.client = client;

            cmbGender.DataSource = new BindingSource(genderDic, null);
            cmbGender.ValueMember = "Key";
            cmbGender.DisplayMember = "Value";
            cmbGender.SelectedValue = cu.U_GENDER;
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            var axc = ((System.Collections.Generic.KeyValuePair<string, string>)
                (cmbGender.SelectedItem.DataBoundItem)).Key;

            UpdateStaticEntity upcl = new UpdateStaticEntity(_sp);
            upcl.Login("CLIENT", "Client", FindBy.Name, TxtIdent.Text.Trim());
            upcl.AddProperties("U_FIRST_NAME", txtFN.Text);
            upcl.AddProperties("U_LAST_NAME", txtLN.Text);
            upcl.AddProperties("U_PREV_LAST_NAME", txtPrevLN.Text);

            upcl.AddProperties("U_DATE_OF_BIRTH", radDateTimePicker1.Value.ToString());
            upcl.AddProperties("U_GENDER", axc);

            var s = upcl.ProcssXml();
            if (!s)
            {
                MessageBox.Show(string.Format("Error on Edit Patient  {0}", upcl.ErrorResponse), "Edit Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("הפציינט עודכן במערכת.");

                var cu = client.CLIENT_USER;

                cu.U_FIRST_NAME = upcl.GetValueByTagName("U_FIRST_NAME");
                cu.U_LAST_NAME = upcl.GetValueByTagName("U_LAST_NAME");
                cu.U_PREV_LAST_NAME = upcl.GetValueByTagName("U_PREV_LAST_NAME");
                cu.U_GENDER = upcl.GetValueByTagName("U_GENDER");
                cu.U_DATE_OF_BIRTH = radDateTimePicker1.Value.Date;

                if (PatientEdited != null)
                    PatientEdited(client);

                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("האם אתה בטוח שברצונך לצאת?", "Nautilus - עדכון פציינט", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}





