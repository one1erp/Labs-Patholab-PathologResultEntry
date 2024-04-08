namespace PathologResultEntry.Controls
{
    partial class SendToAdvisor
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.sdgTree = new Telerik.WinControls.UI.RadTreeView();
            this.listViewRequests = new System.Windows.Forms.ListView();
            this.CreatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OpenedFor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Remarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreatedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbox_entities = new System.Windows.Forms.ListBox();
            this.btn_adviseRequest = new System.Windows.Forms.Button();
            this.btnAddSynamic = new System.Windows.Forms.Button();
            this.btnRemoveDynamic = new System.Windows.Forms.Button();
            this.lbox_advisers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMsgAdv = new Telerik.WinControls.UI.RadLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sdgTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMsgAdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.sdgTree);
            this.panel2.Controls.Add(this.listViewRequests);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxRemarks);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.lbox_entities);
            this.panel2.Controls.Add(this.btn_adviseRequest);
            this.panel2.Controls.Add(this.btnAddSynamic);
            this.panel2.Controls.Add(this.btnRemoveDynamic);
            this.panel2.Controls.Add(this.lbox_advisers);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblMsgAdv);
            this.panel2.Location = new System.Drawing.Point(-4, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1670, 997);
            this.panel2.TabIndex = 30;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // sdgTree
            // 
            this.sdgTree.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sdgTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.sdgTree.Location = new System.Drawing.Point(0, 0);
            this.sdgTree.Margin = new System.Windows.Forms.Padding(4);
            this.sdgTree.Name = "sdgTree";
            // 
            // 
            // 
            this.sdgTree.RootElement.AccessibleDescription = null;
            this.sdgTree.RootElement.AccessibleName = null;
            this.sdgTree.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 225, 375);
            this.sdgTree.Size = new System.Drawing.Size(450, 997);
            this.sdgTree.SpacingBetweenNodes = -1;
            this.sdgTree.TabIndex = 31;
            // 
            // listViewRequests
            // 
            this.listViewRequests.AllowColumnReorder = true;
            this.listViewRequests.AllowDrop = true;
            this.listViewRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CreatedBy,
            this.OpenedFor,
            this.Status,
            this.Remarks,
            this.CreatedOn});
            this.listViewRequests.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listViewRequests.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listViewRequests.FullRowSelect = true;
            this.listViewRequests.HideSelection = false;
            this.listViewRequests.Location = new System.Drawing.Point(534, 423);
            this.listViewRequests.Margin = new System.Windows.Forms.Padding(4);
            this.listViewRequests.Name = "listViewRequests";
            this.listViewRequests.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listViewRequests.RightToLeftLayout = true;
            this.listViewRequests.Size = new System.Drawing.Size(1050, 335);
            this.listViewRequests.TabIndex = 36;
            this.listViewRequests.UseCompatibleStateImageBehavior = false;
            this.listViewRequests.View = System.Windows.Forms.View.Details;
            // 
            // CreatedBy
            // 
            this.CreatedBy.Tag = "CreatedBy";
            this.CreatedBy.Text = "פתולוג מפנה";
            this.CreatedBy.Width = 120;
            // 
            // OpenedFor
            // 
            this.OpenedFor.Text = "פתולוג מטפל";
            this.OpenedFor.Width = 120;
            // 
            // Status
            // 
            this.Status.DisplayIndex = 3;
            this.Status.Tag = "Status";
            this.Status.Text = "סטטוס";
            this.Status.Width = 90;
            // 
            // Remarks
            // 
            this.Remarks.DisplayIndex = 2;
            this.Remarks.Tag = "Remarks";
            this.Remarks.Text = "הערות";
            this.Remarks.Width = 200;
            // 
            // CreatedOn
            // 
            this.CreatedOn.Tag = "CreatedOn";
            this.CreatedOn.Text = "נפתח בתאריך";
            this.CreatedOn.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(954, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 37);
            this.label1.TabIndex = 35;
            this.label1.Text = "הערות";
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.AllowDrop = true;
            this.textBoxRemarks.Location = new System.Drawing.Point(534, 97);
            this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxRemarks.Size = new System.Drawing.Size(478, 210);
            this.textBoxRemarks.TabIndex = 34;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::PathologResultEntry.Properties.Resources.Capture;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.Location = new System.Drawing.Point(1083, 809);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 121);
            this.button2.TabIndex = 31;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbox_entities
            // 
            this.lbox_entities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbox_entities.FormattingEnabled = true;
            this.lbox_entities.ItemHeight = 25;
            this.lbox_entities.Location = new System.Drawing.Point(100, 904);
            this.lbox_entities.Name = "lbox_entities";
            this.lbox_entities.Size = new System.Drawing.Size(70, 29);
            this.lbox_entities.TabIndex = 8;
            this.lbox_entities.Visible = false;
            // 
            // btn_adviseRequest
            // 
            this.btn_adviseRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_adviseRequest.BackColor = System.Drawing.Color.Transparent;
            this.btn_adviseRequest.BackgroundImage = global::PathologResultEntry.Properties.Resources.v1;
            this.btn_adviseRequest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_adviseRequest.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_adviseRequest.Location = new System.Drawing.Point(922, 809);
            this.btn_adviseRequest.Name = "btn_adviseRequest";
            this.btn_adviseRequest.Size = new System.Drawing.Size(128, 121);
            this.btn_adviseRequest.TabIndex = 25;
            this.btn_adviseRequest.UseVisualStyleBackColor = false;
            this.btn_adviseRequest.Click += new System.EventHandler(this.adviseRequest_Click);
            // 
            // btnAddSynamic
            // 
            this.btnAddSynamic.BackColor = System.Drawing.Color.Transparent;
            this.btnAddSynamic.BackgroundImage = global::PathologResultEntry.Properties.Resources.AR11;
            this.btnAddSynamic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddSynamic.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddSynamic.Location = new System.Drawing.Point(28, 904);
            this.btnAddSynamic.Name = "btnAddSynamic";
            this.btnAddSynamic.Size = new System.Drawing.Size(50, 29);
            this.btnAddSynamic.TabIndex = 22;
            this.btnAddSynamic.UseVisualStyleBackColor = false;
            this.btnAddSynamic.Visible = false;
            // 
            // btnRemoveDynamic
            // 
            this.btnRemoveDynamic.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveDynamic.BackgroundImage = global::PathologResultEntry.Properties.Resources.Cancel;
            this.btnRemoveDynamic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveDynamic.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveDynamic.Location = new System.Drawing.Point(28, 939);
            this.btnRemoveDynamic.Name = "btnRemoveDynamic";
            this.btnRemoveDynamic.Size = new System.Drawing.Size(50, 27);
            this.btnRemoveDynamic.TabIndex = 24;
            this.btnRemoveDynamic.UseVisualStyleBackColor = false;
            this.btnRemoveDynamic.Visible = false;
            // 
            // lbox_advisers
            // 
            this.lbox_advisers.AllowDrop = true;
            this.lbox_advisers.BackColor = System.Drawing.SystemColors.Window;
            this.lbox_advisers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbox_advisers.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbox_advisers.FormattingEnabled = true;
            this.lbox_advisers.ItemHeight = 25;
            this.lbox_advisers.Location = new System.Drawing.Point(1106, 97);
            this.lbox_advisers.Margin = new System.Windows.Forms.Padding(0);
            this.lbox_advisers.Name = "lbox_advisers";
            this.lbox_advisers.Size = new System.Drawing.Size(478, 204);
            this.lbox_advisers.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1424, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 38);
            this.label3.TabIndex = 16;
            this.label3.Text = "בחירת יועץ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1282, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(299, 38);
            this.label4.TabIndex = 17;
            this.label4.Text = "היסטוריית התייעצויות";
            // 
            // lblMsgAdv
            // 
            this.lblMsgAdv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsgAdv.AutoSize = false;
            this.lblMsgAdv.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMsgAdv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMsgAdv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblMsgAdv.Location = new System.Drawing.Point(840, 926);
            this.lblMsgAdv.Margin = new System.Windows.Forms.Padding(4);
            this.lblMsgAdv.Name = "lblMsgAdv";
            this.lblMsgAdv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.lblMsgAdv.RootElement.AccessibleDescription = null;
            this.lblMsgAdv.RootElement.AccessibleName = null;
            this.lblMsgAdv.RootElement.ControlBounds = new System.Drawing.Rectangle(840, 926, 150, 27);
            this.lblMsgAdv.Size = new System.Drawing.Size(616, 63);
            this.lblMsgAdv.TabIndex = 28;
            this.lblMsgAdv.Text = "The request was saved successfully.";
            this.lblMsgAdv.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsgAdv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.lblMsgAdv.Visible = false;
            // 
            // SendToAdvisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1666, 1001);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SendToAdvisor";
            this.Text = "SendToAdvisor";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sdgTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMsgAdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lbox_entities;
        private System.Windows.Forms.Button btn_adviseRequest;
        private System.Windows.Forms.Button btnRemoveDynamic;
        private System.Windows.Forms.ListBox lbox_advisers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadLabel lblMsgAdv;
        private System.Windows.Forms.Button btnAddSynamic;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewRequests;
        private System.Windows.Forms.ColumnHeader CreatedBy;
        private System.Windows.Forms.ColumnHeader OpenedFor;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Remarks;
        private System.Windows.Forms.ColumnHeader CreatedOn;
        private Telerik.WinControls.UI.RadTreeView sdgTree;
    }
}
