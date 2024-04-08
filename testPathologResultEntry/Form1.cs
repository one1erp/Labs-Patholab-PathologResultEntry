using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using PathologResultEntry;
using Ex_Req_Worklist;
using Patholab_DAL_V1;
using PathologResultEntry;
//using CreateWorkf;


namespace testPathologResultEntry
{
    public partial class Form1 : Form
    {
        private DataLayer dal = null;

        public Form1()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            activateWorkListWindow();
        }
        private void activateWorkListWindow()
        {
            try
            {
               
                PatholabWorkList.WpfPatholabWorkList pl = new PatholabWorkList.WpfPatholabWorkList();
                pl.initDebug();
                elementHost1.Child = pl;
                dal = new DataLayer();
                dal.MockConnect();


                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Patholab_DAL_V1.DataLayer _dal;
        private void button1_Click(object sender, EventArgs e)
        {
            _dal = new Patholab_DAL_V1.DataLayer();
            _dal.MockConnect();

            SDG sdg = _dal.FindBy<SDG>(x => x.SDG_ID == 1952).FirstOrDefault();

            if (sdg != null) {
                
                int iteration = 1;
                foreach (var samp in sdg.SAMPLEs)
                {
                    foreach (var item in samp.ALIQUOTs)
                    {
                        if (item.ALIQUOT_USER.U_NUM_OF_TISSUES != null)
                        {
                            string contentText = item.NAME.Substring(item.NAME.Length - 3);
                            contentText += $"({item.ALIQUOT_USER.U_NUM_OF_TISSUES})";

                            Label iterationLabel = new Label();
                            iterationLabel.AutoSize = true;
                            iterationLabel.BackColor = Color.Green;
                            iterationLabel.ForeColor = Color.White;
                            iterationLabel.Font = new Font(iterationLabel.Font.FontFamily, 12, FontStyle.Regular);
                            iterationLabel.Text = iteration.ToString();

                            Label contentLabel = new Label();
                            contentLabel.AutoSize = true;
                            contentLabel.BackColor = Color.White;
                            contentLabel.Font = new Font(contentLabel.Font.FontFamily, 12, FontStyle.Regular);
                            contentLabel.Text = contentText;

                            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Add an additional column for contentLabel

                            TableLayoutPanelCellPosition position = new TableLayoutPanelCellPosition(0, iteration - 1);
                            tableLayoutPanel1.Controls.Add(iterationLabel, position.Column, position.Row);
                            tableLayoutPanel1.Controls.Add(contentLabel, position.Column + 1, position.Row); // Place contentLabel in the next column

                            iteration++;
                        }
                    }
                }
            }
            
            

            
           


          



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
