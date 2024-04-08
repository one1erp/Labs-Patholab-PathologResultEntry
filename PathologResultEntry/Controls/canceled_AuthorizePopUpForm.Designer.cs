namespace PathologResultEntry.Controls
{
    partial class AuthorizePopUpForm
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.snomedCtrl = new PathologResultEntry.Controls.SnomedCtrl();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.BackgroundImage = global::PathologResultEntry.Properties.Resources.Capture;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(483, 542);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(87, 91);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.BackgroundImage = global::PathologResultEntry.Properties.Resources.v1;
            this.buttonOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOK.Location = new System.Drawing.Point(322, 542);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(87, 91);
            this.buttonOK.TabIndex = 15;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // snomedCtrl
            // 
            this.snomedCtrl._signByList = null;
            this.snomedCtrl._sMList = null;
            this.snomedCtrl._sTList = null;
            this.snomedCtrl.AutoScroll = true;
            this.snomedCtrl.AutoSize = true;
            this.snomedCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.snomedCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.snomedCtrl.Location = new System.Drawing.Point(0, 0);
            this.snomedCtrl.Name = "snomedCtrl";
            this.snomedCtrl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.snomedCtrl.Size = new System.Drawing.Size(933, 457);
            this.snomedCtrl.snomedVisible = true;
            this.snomedCtrl.TabIndex = 17;
            this.snomedCtrl.Load += new System.EventHandler(this.snomedCtrl_Load);
            // 
            // AuthorizePopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 656);
            this.Controls.Add(this.snomedCtrl);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonOK);
            this.Name = "AuthorizePopUpForm";
            this.Text = "AuthorizePopUpForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthorizePopUpForm_FormClosing);
            this.Load += new System.EventHandler(this.AuthorizePopUpForm_Load);
            this.Shown += new System.EventHandler(this.AuthorizePopUpForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOK;
        private SnomedCtrl snomedCtrl;
    }
}