using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;

namespace PathologResultEntry
{
    public partial class PdfViewerFrm : Telerik.WinControls.UI.RadForm
    {
        public string path { get; set; }
        public PdfViewerFrm(string uAtfilenm)
        {
            InitializeComponent();

            path = uAtfilenm;
        }

        private void PdfViewerFrm_Shown(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                this.axAcroPDF1.LoadFile(path + "#toolbar=0");
                this.axAcroPDF1.src = path + "#toolbar=0";
                this.axAcroPDF1.setShowToolbar(false);
                this.axAcroPDF1.setLayoutMode("SinglePage");
                this.axAcroPDF1.setPageMode("none");
            }
            else
            {
                MessageBox.Show(path + " doesn't exists", "Nautilus");
            }
        }

        private void PdfViewerFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.axAcroPDF1.Dispose();
        }
    }
}
