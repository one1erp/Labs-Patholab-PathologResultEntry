namespace PathologResultEntry.Controls
{
    partial class HistoryCtl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryCtl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.radListControl1 = new Telerik.WinControls.UI.RadListControl();
            this.lbMedical = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "sdga.ico");
            this.imageList1.Images.SetKeyName(1, "sdgc.ico");
            this.imageList1.Images.SetKeyName(2, "sdgi.ico");
            this.imageList1.Images.SetKeyName(3, "sdgp.ico");
            this.imageList1.Images.SetKeyName(4, "sdgr.ico");
            this.imageList1.Images.SetKeyName(5, "sdgs.ico");
            this.imageList1.Images.SetKeyName(6, "sdgu.ico");
            this.imageList1.Images.SetKeyName(7, "sdgv.ico");
            this.imageList1.Images.SetKeyName(8, "sdgx.ico");
            // 
            // radListControl1
            // 
            this.radListControl1.AutoSizeItems = true;
            this.radListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radListControl1.ItemHeight = 25;
            this.radListControl1.Location = new System.Drawing.Point(3, 123);
            this.radListControl1.Name = "radListControl1";
            this.radListControl1.Size = new System.Drawing.Size(252, 371);
            this.radListControl1.TabIndex = 0;
            this.radListControl1.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radListControl1_SelectedIndexChanged);
            this.radListControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.radListControl1_MouseDoubleClick);
            // 
            // lbMedical
            // 
            this.lbMedical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMedical.FormattingEnabled = true;
            this.lbMedical.ItemHeight = 14;
            this.lbMedical.Location = new System.Drawing.Point(3, 3);
            this.lbMedical.Name = "lbMedical";
            this.lbMedical.Size = new System.Drawing.Size(252, 114);
            this.lbMedical.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbMedical, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radListControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 497);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // HistoryCtl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HistoryCtl";
            this.Size = new System.Drawing.Size(258, 497);
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private Telerik.WinControls.UI.RadListControl radListControl1;
        private System.Windows.Forms.ListBox lbMedical;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
