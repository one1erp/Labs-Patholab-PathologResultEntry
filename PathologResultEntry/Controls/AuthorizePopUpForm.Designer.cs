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
            this.radDropDownListSecondSign = new Telerik.WinControls.UI.RadDropDownList();
            this.radRadioButtonDistribute = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButtonSendToSecondSign = new Telerik.WinControls.UI.RadRadioButton();
            this.radTextBoxSignBy2 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBoxSignBy1 = new Telerik.WinControls.UI.RadTextBox();
            this.grp_snomedT = new System.Windows.Forms.GroupBox();
            this.cmbST2 = new Telerik.WinControls.UI.RadDropDownList();
            this.cmbST1 = new Telerik.WinControls.UI.RadDropDownList();
            this.grp_snomedM = new System.Windows.Forms.GroupBox();
            this.cmbSM2 = new Telerik.WinControls.UI.RadDropDownList();
            this.cmbSM1 = new Telerik.WinControls.UI.RadDropDownList();
            this.cbMalig = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListSecondSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonDistribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonSendToSecondSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxSignBy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxSignBy1)).BeginInit();
            this.grp_snomedT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbST2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbST1)).BeginInit();
            this.grp_snomedM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSM1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMalig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            this.SuspendLayout();
            // 
            // radDropDownListSecondSign
            // 
            this.radDropDownListSecondSign.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.radDropDownListSecondSign.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radDropDownListSecondSign.Location = new System.Drawing.Point(507, 408);
            this.radDropDownListSecondSign.Margin = new System.Windows.Forms.Padding(4);
            this.radDropDownListSecondSign.Name = "radDropDownListSecondSign";
            this.radDropDownListSecondSign.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radDropDownListSecondSign.Size = new System.Drawing.Size(131, 27);
            this.radDropDownListSecondSign.TabIndex = 47;
            // 
            // radRadioButtonDistribute
            // 
            this.radRadioButtonDistribute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radRadioButtonDistribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radRadioButtonDistribute.Location = new System.Drawing.Point(703, 451);
            this.radRadioButtonDistribute.Name = "radRadioButtonDistribute";
            this.radRadioButtonDistribute.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radRadioButtonDistribute.Size = new System.Drawing.Size(104, 21);
            this.radRadioButtonDistribute.TabIndex = 46;
            this.radRadioButtonDistribute.Text = "העבר להפצה";
            this.radRadioButtonDistribute.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radRadioButtonDistribute.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButtonDistribute_ToggleStateChanged);
            // 
            // radRadioButtonSendToSecondSign
            // 
            this.radRadioButtonSendToSecondSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radRadioButtonSendToSecondSign.Location = new System.Drawing.Point(657, 412);
            this.radRadioButtonSendToSecondSign.Name = "radRadioButtonSendToSecondSign";
            this.radRadioButtonSendToSecondSign.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radRadioButtonSendToSecondSign.Size = new System.Drawing.Size(150, 21);
            this.radRadioButtonSendToSecondSign.TabIndex = 45;
            this.radRadioButtonSendToSecondSign.TabStop = false;
            this.radRadioButtonSendToSecondSign.Text = "העבר לחתימה שנייה";
            this.radRadioButtonSendToSecondSign.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButtonSendToSecondSign_ToggleStateChanged);
            // 
            // radTextBoxSignBy2
            // 
            this.radTextBoxSignBy2.AutoSize = false;
            this.radTextBoxSignBy2.Enabled = false;
            this.radTextBoxSignBy2.Location = new System.Drawing.Point(192, 364);
            this.radTextBoxSignBy2.Multiline = true;
            this.radTextBoxSignBy2.Name = "radTextBoxSignBy2";
            this.radTextBoxSignBy2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radTextBoxSignBy2.Size = new System.Drawing.Size(615, 27);
            this.radTextBoxSignBy2.TabIndex = 44;
            // 
            // radTextBoxSignBy1
            // 
            this.radTextBoxSignBy1.AutoSize = false;
            this.radTextBoxSignBy1.Enabled = false;
            this.radTextBoxSignBy1.Location = new System.Drawing.Point(192, 324);
            this.radTextBoxSignBy1.Multiline = true;
            this.radTextBoxSignBy1.Name = "radTextBoxSignBy1";
            this.radTextBoxSignBy1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radTextBoxSignBy1.Size = new System.Drawing.Size(615, 27);
            this.radTextBoxSignBy1.TabIndex = 43;
            // 
            // grp_snomedT
            // 
            this.grp_snomedT.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grp_snomedT.BackColor = System.Drawing.SystemColors.Control;
            this.grp_snomedT.Controls.Add(this.cmbST2);
            this.grp_snomedT.Controls.Add(this.cmbST1);
            this.grp_snomedT.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.grp_snomedT.Location = new System.Drawing.Point(25, 82);
            this.grp_snomedT.Margin = new System.Windows.Forms.Padding(4);
            this.grp_snomedT.Name = "grp_snomedT";
            this.grp_snomedT.Padding = new System.Windows.Forms.Padding(4);
            this.grp_snomedT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grp_snomedT.Size = new System.Drawing.Size(809, 94);
            this.grp_snomedT.TabIndex = 41;
            this.grp_snomedT.TabStop = false;
            this.grp_snomedT.Text = "SNOMED T";
            // 
            // cmbST2
            // 
            this.cmbST2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbST2.BackColor = System.Drawing.SystemColors.Control;
            this.cmbST2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbST2.Location = new System.Drawing.Point(167, 58);
            this.cmbST2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbST2.Name = "cmbST2";
            this.cmbST2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbST2.Size = new System.Drawing.Size(615, 27);
            this.cmbST2.TabIndex = 1;
            // 
            // cmbST1
            // 
            this.cmbST1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbST1.BackColor = System.Drawing.SystemColors.Control;
            this.cmbST1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbST1.Location = new System.Drawing.Point(167, 21);
            this.cmbST1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbST1.Name = "cmbST1";
            this.cmbST1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbST1.Size = new System.Drawing.Size(615, 27);
            this.cmbST1.TabIndex = 0;
            // 
            // grp_snomedM
            // 
            this.grp_snomedM.Controls.Add(this.cmbSM2);
            this.grp_snomedM.Controls.Add(this.cmbSM1);
            this.grp_snomedM.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.grp_snomedM.Location = new System.Drawing.Point(25, 202);
            this.grp_snomedM.Margin = new System.Windows.Forms.Padding(4);
            this.grp_snomedM.Name = "grp_snomedM";
            this.grp_snomedM.Padding = new System.Windows.Forms.Padding(4);
            this.grp_snomedM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grp_snomedM.Size = new System.Drawing.Size(809, 94);
            this.grp_snomedM.TabIndex = 42;
            this.grp_snomedM.TabStop = false;
            this.grp_snomedM.Text = "SNOMED M";
            // 
            // cmbSM2
            // 
            this.cmbSM2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSM2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbSM2.Location = new System.Drawing.Point(167, 58);
            this.cmbSM2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSM2.Name = "cmbSM2";
            this.cmbSM2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSM2.Size = new System.Drawing.Size(615, 27);
            this.cmbSM2.TabIndex = 1;
            // 
            // cmbSM1
            // 
            this.cmbSM1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSM1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbSM1.Location = new System.Drawing.Point(167, 21);
            this.cmbSM1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSM1.Name = "cmbSM1";
            this.cmbSM1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSM1.Size = new System.Drawing.Size(615, 27);
            this.cmbSM1.TabIndex = 0;
            this.cmbSM1.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmbSM1_SelectedIndexChanged);
            // 
            // cbMalig
            // 
            this.cbMalig.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.cbMalig.Location = new System.Drawing.Point(25, 31);
            this.cbMalig.Margin = new System.Windows.Forms.Padding(4);
            this.cbMalig.Name = "cbMalig";
            this.cbMalig.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbMalig.Size = new System.Drawing.Size(262, 29);
            this.cbMalig.TabIndex = 40;
            this.cbMalig.Text = "Should report to physician";
            this.cbMalig.Visible = false;
            this.cbMalig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cbMalig_MouseUp);
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.radLabel7.Location = new System.Drawing.Point(25, 322);
            this.radLabel7.Margin = new System.Windows.Forms.Padding(4);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radLabel7.Size = new System.Drawing.Size(114, 29);
            this.radLabel7.TabIndex = 38;
            this.radLabel7.Text = "Sign by 1st.";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.radLabel8.Location = new System.Drawing.Point(25, 362);
            this.radLabel8.Margin = new System.Windows.Forms.Padding(4);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radLabel8.Size = new System.Drawing.Size(121, 29);
            this.radLabel8.TabIndex = 39;
            this.radLabel8.Text = "Sign by 2nd.";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.BackgroundImage = global::PathologResultEntry.Properties.Resources.Capture;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(485, 517);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(104, 100);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.BackgroundImage = global::PathologResultEntry.Properties.Resources.v1;
            this.buttonOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOK.Location = new System.Drawing.Point(324, 517);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(104, 100);
            this.buttonOK.TabIndex = 15;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // AuthorizePopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 665);
            this.Controls.Add(this.radDropDownListSecondSign);
            this.Controls.Add(this.radRadioButtonDistribute);
            this.Controls.Add(this.radRadioButtonSendToSecondSign);
            this.Controls.Add(this.radTextBoxSignBy2);
            this.Controls.Add(this.radTextBoxSignBy1);
            this.Controls.Add(this.grp_snomedT);
            this.Controls.Add(this.grp_snomedM);
            this.Controls.Add(this.cbMalig);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonOK);
            this.Name = "AuthorizePopUpForm";
            this.Text = "AuthorizePopUpForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthorizePopUpForm_FormClosing);
            this.Load += new System.EventHandler(this.AuthorizePopUpForm_Load);
            this.Shown += new System.EventHandler(this.AuthorizePopUpForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListSecondSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonDistribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonSendToSecondSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxSignBy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxSignBy1)).EndInit();
            this.grp_snomedT.ResumeLayout(false);
            this.grp_snomedT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbST2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbST1)).EndInit();
            this.grp_snomedM.ResumeLayout(false);
            this.grp_snomedM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSM1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMalig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOK;
        private Telerik.WinControls.UI.RadDropDownList radDropDownListSecondSign;
        private Telerik.WinControls.UI.RadRadioButton radRadioButtonDistribute;
        private Telerik.WinControls.UI.RadRadioButton radRadioButtonSendToSecondSign;
        private Telerik.WinControls.UI.RadTextBox radTextBoxSignBy2;
        private Telerik.WinControls.UI.RadTextBox radTextBoxSignBy1;
        private System.Windows.Forms.GroupBox grp_snomedT;
        private Telerik.WinControls.UI.RadDropDownList cmbST2;
        private Telerik.WinControls.UI.RadDropDownList cmbST1;
        private System.Windows.Forms.GroupBox grp_snomedM;
        private Telerik.WinControls.UI.RadDropDownList cmbSM2;
        private Telerik.WinControls.UI.RadDropDownList cmbSM1;
        private Telerik.WinControls.UI.RadCheckBox cbMalig;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel8;
    }
}