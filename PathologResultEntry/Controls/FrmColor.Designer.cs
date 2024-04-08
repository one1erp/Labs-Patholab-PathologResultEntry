namespace PathologResultEntry.Controls
{
    partial class FrmColor
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
        /// <summary> 
        /// Required designer variable.
        /// </summary>


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radLabelFilter = new Telerik.WinControls.UI.RadLabel();
            this.radTextBoxFilter = new Telerik.WinControls.UI.RadTextBox();
            this.radButtonFilter = new Telerik.WinControls.UI.RadButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_addColors = new System.Windows.Forms.Button();
            this.lbox_ColorType = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridColors2 = new Telerik.WinControls.UI.RadGridView();
            this.gridColors = new Telerik.WinControls.UI.RadGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridColors4 = new Telerik.WinControls.UI.RadGridView();
            this.gridColors3 = new Telerik.WinControls.UI.RadGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors2.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors.MasterTemplate)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors4.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors3.MasterTemplate)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.Name = "ColumnHeader";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.radLabelFilter);
            this.panel1.Controls.Add(this.radTextBoxFilter);
            this.panel1.Controls.Add(this.radButtonFilter);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_addColors);
            this.panel1.Controls.Add(this.lbox_ColorType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(966, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 804);
            this.panel1.TabIndex = 9;
            // 
            // radLabelFilter
            // 
            this.radLabelFilter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.radLabelFilter.Location = new System.Drawing.Point(26, 397);
            this.radLabelFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radLabelFilter.Name = "radLabelFilter";
            this.radLabelFilter.Size = new System.Drawing.Size(71, 34);
            this.radLabelFilter.TabIndex = 29;
            this.radLabelFilter.Text = "Filter:";
            // 
            // radTextBoxFilter
            // 
            this.radTextBoxFilter.AutoSize = false;
            this.radTextBoxFilter.Location = new System.Drawing.Point(26, 435);
            this.radTextBoxFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radTextBoxFilter.Multiline = true;
            this.radTextBoxFilter.Name = "radTextBoxFilter";
            this.radTextBoxFilter.Size = new System.Drawing.Size(290, 71);
            this.radTextBoxFilter.TabIndex = 28;
            this.radTextBoxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radTextBoxFilter_KeyDown);
            // 
            // radButtonFilter
            // 
            this.radButtonFilter.Location = new System.Drawing.Point(81, 513);
            this.radButtonFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radButtonFilter.Name = "radButtonFilter";
            this.radButtonFilter.Size = new System.Drawing.Size(165, 33);
            this.radButtonFilter.TabIndex = 27;
            this.radButtonFilter.Text = "Filter";
            this.radButtonFilter.Click += new System.EventHandler(this.radButtonFilter_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackgroundImage = global::PathologResultEntry.Properties.Resources.Capture;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.Location = new System.Drawing.Point(122, 635);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 86);
            this.button1.TabIndex = 25;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_addColors
            // 
            this.btn_addColors.BackgroundImage = global::PathologResultEntry.Properties.Resources.v1;
            this.btn_addColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addColors.Image = global::PathologResultEntry.Properties.Resources.v1;
            this.btn_addColors.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_addColors.Location = new System.Drawing.Point(105, 213);
            this.btn_addColors.Name = "btn_addColors";
            this.btn_addColors.Size = new System.Drawing.Size(130, 93);
            this.btn_addColors.TabIndex = 24;
            this.btn_addColors.UseVisualStyleBackColor = true;
            this.btn_addColors.Click += new System.EventHandler(this.btn_addColors_Click);
            // 
            // lbox_ColorType
            // 
            this.lbox_ColorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbox_ColorType.FormattingEnabled = true;
            this.lbox_ColorType.ItemHeight = 25;
            this.lbox_ColorType.Items.AddRange(new object[] {
            "אימונוהיסטוכימיה",
            "היסטוכימיה ",
            "אחר"});
            this.lbox_ColorType.Location = new System.Drawing.Point(62, 80);
            this.lbox_ColorType.Name = "lbox_ColorType";
            this.lbox_ColorType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbox_ColorType.Size = new System.Drawing.Size(214, 79);
            this.lbox_ColorType.TabIndex = 9;
            this.lbox_ColorType.SelectedIndexChanged += new System.EventHandler(this.lbox_ColorType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(93, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 38);
            this.label2.TabIndex = 15;
            this.label2.Text = "סוג צביעה";
            // 
            // gridColors2
            // 
            this.gridColors2.AutoScroll = true;
            this.gridColors2.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnKeystroke;
            this.gridColors2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColors2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold);
            this.gridColors2.Location = new System.Drawing.Point(487, 3);
            // 
            // 
            // 
            this.gridColors2.MasterTemplate.AllowAddNewRow = false;
            this.gridColors2.MasterTemplate.AllowColumnReorder = false;
            this.gridColors2.MasterTemplate.AllowColumnResize = false;
            this.gridColors2.MasterTemplate.AllowDeleteRow = false;
            this.gridColors2.MasterTemplate.AllowDragToGroup = false;
            this.gridColors2.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gridColors2.MasterTemplate.ShowFilteringRow = false;
            this.gridColors2.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridColors2.Name = "gridColors2";
            this.gridColors2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridColors2.ShowGroupPanel = false;
            this.gridColors2.Size = new System.Drawing.Size(235, 798);
            this.gridColors2.TabIndex = 1;
            this.gridColors2.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.gridColors_DataBindingComplete);
            // 
            // gridColors
            // 
            this.gridColors.AutoScroll = true;
            this.gridColors.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnKeystroke;
            this.gridColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold);
            this.gridColors.Location = new System.Drawing.Point(728, 3);
            // 
            // 
            // 
            this.gridColors.MasterTemplate.AllowAddNewRow = false;
            this.gridColors.MasterTemplate.AllowColumnReorder = false;
            this.gridColors.MasterTemplate.AllowColumnResize = false;
            this.gridColors.MasterTemplate.AllowDeleteRow = false;
            this.gridColors.MasterTemplate.AllowDragToGroup = false;
            this.gridColors.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gridColors.MasterTemplate.ShowFilteringRow = false;
            this.gridColors.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridColors.Name = "gridColors";
            this.gridColors.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridColors.ShowGroupPanel = false;
            this.gridColors.Size = new System.Drawing.Size(235, 798);
            this.gridColors.TabIndex = 0;
            this.gridColors.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.gridColors_DataBindingComplete);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 804);
            this.panel2.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.gridColors4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridColors3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridColors, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridColors2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(966, 804);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gridColors4
            // 
            this.gridColors4.AutoScroll = true;
            this.gridColors4.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnKeystroke;
            this.gridColors4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColors4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold);
            this.gridColors4.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.gridColors4.MasterTemplate.AllowAddNewRow = false;
            this.gridColors4.MasterTemplate.AllowColumnReorder = false;
            this.gridColors4.MasterTemplate.AllowColumnResize = false;
            this.gridColors4.MasterTemplate.AllowDeleteRow = false;
            this.gridColors4.MasterTemplate.AllowDragToGroup = false;
            this.gridColors4.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gridColors4.MasterTemplate.ShowFilteringRow = false;
            this.gridColors4.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gridColors4.Name = "gridColors4";
            this.gridColors4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridColors4.ShowGroupPanel = false;
            this.gridColors4.Size = new System.Drawing.Size(237, 798);
            this.gridColors4.TabIndex = 3;
            this.gridColors4.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.gridColors_DataBindingComplete);
            // 
            // gridColors3
            // 
            this.gridColors3.AutoScroll = true;
            this.gridColors3.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnKeystroke;
            this.gridColors3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColors3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold);
            this.gridColors3.Location = new System.Drawing.Point(246, 3);
            // 
            // 
            // 
            this.gridColors3.MasterTemplate.AllowAddNewRow = false;
            this.gridColors3.MasterTemplate.AllowColumnReorder = false;
            this.gridColors3.MasterTemplate.AllowColumnResize = false;
            this.gridColors3.MasterTemplate.AllowDeleteRow = false;
            this.gridColors3.MasterTemplate.AllowDragToGroup = false;
            this.gridColors3.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gridColors3.MasterTemplate.ShowFilteringRow = false;
            this.gridColors3.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.gridColors3.Name = "gridColors3";
            this.gridColors3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridColors3.ShowGroupPanel = false;
            this.gridColors3.Size = new System.Drawing.Size(235, 798);
            this.gridColors3.TabIndex = 2;
            this.gridColors3.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.gridColors_DataBindingComplete);
            // 
            // FrmColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 804);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmColor";
            // 
            // 
            // 
          //  this.RootElement.ApplyShapeToControl = true;
            this.VisibleChanged += new System.EventHandler(this.FrmColor_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors2.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColors4.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors3.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColors3)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbox_ColorType;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadGridView gridColors2;
        private Telerik.WinControls.UI.RadGridView gridColors;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_addColors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadGridView gridColors3;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.UI.RadGridView gridColors4;
        private Telerik.WinControls.UI.RadLabel radLabelFilter;
        private Telerik.WinControls.UI.RadTextBox radTextBoxFilter;
        private Telerik.WinControls.UI.RadButton radButtonFilter;
    }
}
