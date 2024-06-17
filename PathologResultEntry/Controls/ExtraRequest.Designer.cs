using PathologResultEntry.Controls.Extra_req_Entities;

namespace PathologResultEntry.Controls
{
    partial class ExtraRequest
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.sdgTree = new Telerik.WinControls.UI.RadTreeView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBoxRemarks = new Telerik.WinControls.UI.RadTextBox();
            this.lblMessage = new Telerik.WinControls.UI.RadLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_addColors = new System.Windows.Forms.Button();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.gridBlocks = new Telerik.WinControls.UI.RadGridView();
            this.lblOpName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sdgTree)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxRemarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBlocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBlocks.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // sdgTree
            // 
            this.sdgTree.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sdgTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.sdgTree.Location = new System.Drawing.Point(0, 0);
            this.sdgTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sdgTree.Name = "sdgTree";
            // 
            // 
            // 
            this.sdgTree.RootElement.AccessibleDescription = null;
            this.sdgTree.RootElement.AccessibleName = null;
            this.sdgTree.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 187, 312);
            this.sdgTree.Size = new System.Drawing.Size(332, 810);
            this.sdgTree.SpacingBetweenNodes = -1;
            this.sdgTree.TabIndex = 2;
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.Name = "ColumnHeader";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblOpName);
            this.panel1.Controls.Add(this.radLabel2);
            this.panel1.Controls.Add(this.radTextBoxRemarks);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_addColors);
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1679, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 810);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(79, 154);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.AccessibleDescription = null;
            this.radLabel2.RootElement.AccessibleName = null;
            this.radLabel2.RootElement.ControlBounds = new System.Drawing.Rectangle(79, 154, 125, 22);
            this.radLabel2.Size = new System.Drawing.Size(87, 33);
            this.radLabel2.TabIndex = 30;
            this.radLabel2.Text = "הערות";
            // 
            // radTextBoxRemarks
            // 
            this.radTextBoxRemarks.AutoSize = false;
            this.radTextBoxRemarks.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radTextBoxRemarks.Location = new System.Drawing.Point(19, 199);
            this.radTextBoxRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.radTextBoxRemarks.Multiline = true;
            this.radTextBoxRemarks.Name = "radTextBoxRemarks";
            // 
            // 
            // 
            this.radTextBoxRemarks.RootElement.AccessibleDescription = null;
            this.radTextBoxRemarks.RootElement.AccessibleName = null;
            this.radTextBoxRemarks.RootElement.ControlBounds = new System.Drawing.Rectangle(19, 199, 125, 25);
            this.radTextBoxRemarks.Size = new System.Drawing.Size(209, 142);
            this.radTextBoxRemarks.TabIndex = 29;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = false;
            this.lblMessage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblMessage.Location = new System.Drawing.Point(19, 513);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.lblMessage.RootElement.AccessibleDescription = null;
            this.lblMessage.RootElement.AccessibleName = null;
            this.lblMessage.RootElement.ControlBounds = new System.Drawing.Rectangle(19, 513, 125, 22);
            this.lblMessage.Size = new System.Drawing.Size(221, 57);
            this.lblMessage.TabIndex = 27;
            this.lblMessage.Text = "The request was saved successfully.";
            this.lblMessage.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::PathologResultEntry.Properties.Resources.Capture;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.Location = new System.Drawing.Point(92, 702);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 76);
            this.button1.TabIndex = 24;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_addColors
            // 
            this.btn_addColors.BackgroundImage = global::PathologResultEntry.Properties.Resources.v1;
            this.btn_addColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addColors.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_addColors.Location = new System.Drawing.Point(39, 383);
            this.btn_addColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_addColors.Name = "btn_addColors";
            this.btn_addColors.Size = new System.Drawing.Size(171, 124);
            this.btn_addColors.TabIndex = 23;
            this.btn_addColors.UseVisualStyleBackColor = true;
            this.btn_addColors.Click += new System.EventHandler(this.btnAddSlideColor_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(52, 32);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.AccessibleDescription = null;
            this.radLabel1.RootElement.AccessibleName = null;
            this.radLabel1.RootElement.ControlBounds = new System.Drawing.Rectangle(52, 32, 125, 22);
            this.radLabel1.Size = new System.Drawing.Size(144, 33);
            this.radLabel1.TabIndex = 11;
            this.radLabel1.Text = "הזמנה עבור";
            // 
            // gridBlocks
            // 
            this.gridBlocks.AutoScroll = true;
            this.gridBlocks.AutoSizeRows = true;
            this.gridBlocks.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridBlocks.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnKeystroke;
            this.gridBlocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBlocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBlocks.Location = new System.Drawing.Point(332, 0);
            this.gridBlocks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // 
            // 
            this.gridBlocks.MasterTemplate.AllowAddNewRow = false;
            this.gridBlocks.MasterTemplate.AllowColumnReorder = false;
            this.gridBlocks.MasterTemplate.AllowColumnResize = false;
            this.gridBlocks.MasterTemplate.AllowDeleteRow = false;
            this.gridBlocks.MasterTemplate.AllowDragToGroup = false;
            this.gridBlocks.MasterTemplate.AllowEditRow = false;
            this.gridBlocks.MasterTemplate.AutoGenerateColumns = false;
            this.gridBlocks.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn4.HeaderText = "צנצנת";
            gridViewTextBoxColumn4.Name = "SampleCol";
            gridViewTextBoxColumn4.Width = 144;
            gridViewTextBoxColumn5.HeaderText = "בלוק";
            gridViewTextBoxColumn5.Name = "BlockCol";
            gridViewTextBoxColumn5.Width = 144;
            gridViewCommandColumn3.DefaultText = "בחר צביעה";
            gridViewCommandColumn3.HeaderText = "בחר צביעה";
            gridViewCommandColumn3.Name = "cmdopen";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 194;
            gridViewTextBoxColumn6.HeaderText = "צביעות שנבחרו";
            gridViewTextBoxColumn6.Name = "SelectedColorCol";
            gridViewTextBoxColumn6.Width = 687;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewCommandColumn4.HeaderText = "איפוס";
            gridViewCommandColumn4.Image = global::PathologResultEntry.Properties.Resources.Cancel;
            gridViewCommandColumn4.ImageLayout = System.Windows.Forms.ImageLayout.Tile;
            gridViewCommandColumn4.Name = "cmd_zero";
            gridViewCommandColumn4.UseDefaultText = true;
            gridViewCommandColumn4.Width = 162;
            this.gridBlocks.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn3,
            gridViewTextBoxColumn6,
            gridViewCommandColumn4});
            this.gridBlocks.MasterTemplate.ShowFilteringRow = false;
            this.gridBlocks.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridBlocks.Name = "gridBlocks";
            this.gridBlocks.ReadOnly = true;
            // 
            // 
            // 
            this.gridBlocks.RootElement.AccessibleDescription = null;
            this.gridBlocks.RootElement.AccessibleName = null;
            this.gridBlocks.RootElement.ControlBounds = new System.Drawing.Rectangle(332, 0, 300, 187);
            this.gridBlocks.ShowGroupPanel = false;
            this.gridBlocks.Size = new System.Drawing.Size(1347, 810);
            this.gridBlocks.TabIndex = 25;
            this.gridBlocks.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gridBlocks_CommandCellClick);
            // 
            // lblOpName
            // 
            this.lblOpName.AutoSize = true;
            this.lblOpName.BackColor = System.Drawing.Color.White;
            this.lblOpName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOpName.Location = new System.Drawing.Point(76, 80);
            this.lblOpName.Name = "lblOpName";
            this.lblOpName.Size = new System.Drawing.Size(101, 25);
            this.lblOpName.TabIndex = 31;
            this.lblOpName.Text = "שם דוקטור";
            // 
            // ExtraRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 810);
            this.Controls.Add(this.gridBlocks);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sdgTree);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExtraRequest";
            ((System.ComponentModel.ISupportInitialize)(this.sdgTree)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxRemarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBlocks.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBlocks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView sdgTree;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.Button btn_addColors;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.UI.RadLabel lblMessage;
        private Telerik.WinControls.UI.RadGridView gridBlocks;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox radTextBoxRemarks;
        private System.Windows.Forms.Label lblOpName;
    }
}
