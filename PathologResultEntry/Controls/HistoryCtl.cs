using Patholab_DAL_V1;
using PreviewLetter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Timer = System.Windows.Forms.Timer;




namespace PathologResultEntry.Controls
{
    public partial class HistoryCtl : UserControl
    {
        const string Medical_Title="אין הסטוריה במדיקל";
        public event Action<string> ItemSelected;


        public HistoryCtl()
        {
            InitializeComponent();
        }

        public void ClearList()
        {
            lbMedical.Items.Clear();
            radListControl1.Items.Clear();
        }

        public void LoadData(string Cusdg, IQueryable<SDG_USER> Historylist)
        {
            radListControl1.Items.Clear();

            foreach (var item in Historylist)
            {
                if (item.SDG.NAME != Cusdg)
                {

                    RadListDataItem descriptionItem = new RadListDataItem();
                    descriptionItem.Text = item.U_PATHOLAB_NUMBER + "     " + item.SDG.CREATED_ON.Value.ToString("dd/MM/yyyy");
                    string imgN = string.Format("sdg{0}.ico", item.SDG.STATUS);
                    descriptionItem.Image = new Bitmap(imageList1.Images[imgN]);


                    this.radListControl1.Items.Add(descriptionItem);

                }
            }

            var client = Historylist.First().CLIENT.CLIENT_USER;

            List<string> split = new List<string>();
            if (client.U_VISIT_1 != null)
            {
                split.AddRange(client.U_VISIT_1.Split(','));
            }
            if (client.U_VISIT_2 != null)
            {
                split.AddRange(client.U_VISIT_2.Split(','));

            }

            lbMedical.Items.Clear();
            foreach (var row in split)
            {
                lbMedical.Items.Add(row);
            }
        }

     



        private void radListControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var sdg = (((Telerik.WinControls.UI.RadListControl)(sender)).SelectedItem).Text;

                //Split sdg name from string
                var INDX = sdg.IndexOf(' ');
                var sdgName = sdg.Substring(0, INDX);
                ItemSelected(sdgName);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on Load pdf! " + ex.Message, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void radListControl1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

      
    }
}
