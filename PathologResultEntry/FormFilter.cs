using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathologResultEntry
{
    public partial class FormFilter : Form
    {
    
        public string filterSentence;

        public FormFilter()
        {
            InitializeComponent();
            this.Text = "Filter";
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            filterSentence = textBoxFilter.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonFilter_Click(null, null);
            }
        }
    }
}
