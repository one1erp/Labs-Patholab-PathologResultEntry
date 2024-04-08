namespace PathologResultEntry.Controls
{
    partial class Rescan
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
            this.sdgTree = new Telerik.WinControls.UI.RadTreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDetails = new Telerik.WinControls.UI.RadTextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.lbox_entities = new System.Windows.Forms.ListBox();
            this.btnSendRescan = new System.Windows.Forms.Button();
            this.btnAddSynamic = new System.Windows.Forms.Button();
            this.btnRemoveDynamic = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCont4adv = new System.Windows.Forms.Label();
            this.lblMsgAdv = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.sdgTree)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMsgAdv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // sdgTree
            // 
            this.sdgTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.sdgTree.Location = new System.Drawing.Point(0, 0);
            this.sdgTree.Name = "sdgTree";
            this.sdgTree.Size = new System.Drawing.Size(438, 1008);
            this.sdgTree.SpacingBetweenNodes = -1;
            this.sdgTree.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxDetails);
            this.panel2.Controls.Add(this.buttonExit);
            this.panel2.Controls.Add(this.lbox_entities);
            this.panel2.Controls.Add(this.btnSendRescan);
            this.panel2.Controls.Add(this.btnAddSynamic);
            this.panel2.Controls.Add(this.btnRemoveDynamic);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblCont4adv);
            this.panel2.Controls.Add(this.lblMsgAdv);
            this.panel2.Location = new System.Drawing.Point(436, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1096, 995);
            this.panel2.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(723, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 38);
            this.label1.TabIndex = 33;
            this.label1.Text = "הערות";
            // 
            // textBoxDetails
            // 
            this.textBoxDetails.AutoSize = false;
            this.textBoxDetails.Location = new System.Drawing.Point(111, 498);
            this.textBoxDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDetails.Multiline = true;
            this.textBoxDetails.Name = "textBoxDetails";
            this.textBoxDetails.Size = new System.Drawing.Size(714, 144);
            this.textBoxDetails.TabIndex = 32;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.BackgroundImage = global::PathologResultEntry.Properties.Resources.Capture;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExit.Location = new System.Drawing.Point(482, 667);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(128, 109);
            this.buttonExit.TabIndex = 31;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // lbox_entities
            // 
            this.lbox_entities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbox_entities.FormattingEnabled = true;
            this.lbox_entities.ItemHeight = 25;
            this.lbox_entities.Location = new System.Drawing.Point(111, 111);
            this.lbox_entities.Name = "lbox_entities";
            this.lbox_entities.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbox_entities.Size = new System.Drawing.Size(712, 304);
            this.lbox_entities.TabIndex = 8;
            // 
            // btnSendRescan
            // 
            this.btnSendRescan.BackColor = System.Drawing.Color.Transparent;
            this.btnSendRescan.BackgroundImage = global::PathologResultEntry.Properties.Resources.v1;
            this.btnSendRescan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendRescan.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSendRescan.Location = new System.Drawing.Point(312, 667);
            this.btnSendRescan.Name = "btnSendRescan";
            this.btnSendRescan.Size = new System.Drawing.Size(128, 109);
            this.btnSendRescan.TabIndex = 25;
            this.btnSendRescan.UseVisualStyleBackColor = false;
            this.btnSendRescan.Click += new System.EventHandler(this.btnSendRescan_Click);
            // 
            // btnAddSynamic
            // 
            this.btnAddSynamic.BackColor = System.Drawing.Color.Transparent;
            this.btnAddSynamic.BackgroundImage = global::PathologResultEntry.Properties.Resources.AR11;
            this.btnAddSynamic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddSynamic.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddSynamic.Location = new System.Drawing.Point(18, 166);
            this.btnAddSynamic.Name = "btnAddSynamic";
            this.btnAddSynamic.Size = new System.Drawing.Size(84, 75);
            this.btnAddSynamic.TabIndex = 22;
            this.btnAddSynamic.UseVisualStyleBackColor = false;
            this.btnAddSynamic.Click += new System.EventHandler(this.btnAddSynamic_Click);
            // 
            // btnRemoveDynamic
            // 
            this.btnRemoveDynamic.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveDynamic.BackgroundImage = global::PathologResultEntry.Properties.Resources.Cancel;
            this.btnRemoveDynamic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveDynamic.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveDynamic.Location = new System.Drawing.Point(21, 292);
            this.btnRemoveDynamic.Name = "btnRemoveDynamic";
            this.btnRemoveDynamic.Size = new System.Drawing.Size(84, 75);
            this.btnRemoveDynamic.TabIndex = 24;
            this.btnRemoveDynamic.UseVisualStyleBackColor = false;
            this.btnRemoveDynamic.Click += new System.EventHandler(this.btnRemoveDynamic_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(513, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 38);
            this.label4.TabIndex = 17;
            this.label4.Text = "בחירת ישויות דינאמיות";
            // 
            // lblCont4adv
            // 
            this.lblCont4adv.AutoSize = true;
            this.lblCont4adv.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblCont4adv.Location = new System.Drawing.Point(21, 13);
            this.lblCont4adv.Name = "lblCont4adv";
            this.lblCont4adv.Size = new System.Drawing.Size(33, 38);
            this.lblCont4adv.TabIndex = 20;
            this.lblCont4adv.Text = "0";
            // 
            // lblMsgAdv
            // 
            this.lblMsgAdv.AutoSize = false;
            this.lblMsgAdv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMsgAdv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblMsgAdv.Location = new System.Drawing.Point(166, 801);
            this.lblMsgAdv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblMsgAdv.Name = "lblMsgAdv";
            this.lblMsgAdv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMsgAdv.Size = new System.Drawing.Size(616, 179);
            this.lblMsgAdv.TabIndex = 28;
            this.lblMsgAdv.Text = "The request was saved successfully.";
            this.lblMsgAdv.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsgAdv.Visible = false;
            // 
            // Rescan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 1008);
            this.Controls.Add(this.sdgTree);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Rescan";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Rescan";
            ((System.ComponentModel.ISupportInitialize)(this.sdgTree)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMsgAdv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView sdgTree;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListBox lbox_entities;
        private System.Windows.Forms.Button btnSendRescan;
        private System.Windows.Forms.Button btnAddSynamic;
        private System.Windows.Forms.Button btnRemoveDynamic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCont4adv;
        private Telerik.WinControls.UI.RadLabel lblMsgAdv;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadTextBox textBoxDetails;
    }
}
