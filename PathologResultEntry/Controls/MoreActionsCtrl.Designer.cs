namespace PathologResultEntry.Controls
{
    partial class MoreActionsCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grid = new Telerik.WinControls.UI.RadGridView();
            this.lblMsgV = new Telerik.WinControls.UI.RadLabel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMsgV)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowDrop = true;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoScroll = true;
            this.grid.AutoSizeRows = true;
            this.grid.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grid.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // 
            // 
            this.grid.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.grid.MasterTemplate.AllowColumnChooser = false;
            this.grid.MasterTemplate.AllowColumnReorder = false;
            this.grid.MasterTemplate.AllowDragToGroup = false;
            this.grid.MasterTemplate.AllowRowReorder = true;
            this.grid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grid.MinimumSize = new System.Drawing.Size(0, 193);
            this.grid.Name = "grid";
            this.grid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.grid.RootElement.AccessibleDescription = null;
            this.grid.RootElement.AccessibleName = null;
            this.grid.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 812, 375);
            this.grid.RootElement.MinSize = new System.Drawing.Size(0, 193);
            this.grid.Size = new System.Drawing.Size(812, 375);
            this.grid.TabIndex = 1;
            this.grid.Text = "gridShipments";
            this.grid.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellEditorInitialized);
            this.grid.UserDeletingRow += new Telerik.WinControls.UI.GridViewRowCancelEventHandler(this.grid_UserDeletingRow);
            this.grid.DefaultValuesNeeded += new Telerik.WinControls.UI.GridViewRowEventHandler(this.grid_DefaultValuesNeeded);
            // 
            // lblMsgV
            // 
            this.lblMsgV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMsgV.AutoSize = false;
            this.lblMsgV.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMsgV.BorderVisible = true;
            this.lblMsgV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMsgV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblMsgV.Location = new System.Drawing.Point(305, 395);
            this.lblMsgV.Name = "lblMsgV";
            this.lblMsgV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.lblMsgV.RootElement.AccessibleDescription = null;
            this.lblMsgV.RootElement.AccessibleName = null;
            this.lblMsgV.RootElement.ControlBounds = new System.Drawing.Rectangle(305, 395, 166, 40);
            this.lblMsgV.Size = new System.Drawing.Size(166, 40);
            this.lblMsgV.TabIndex = 29;
            this.lblMsgV.Text = "The request was saved successfully.";
            this.lblMsgV.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsgV.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_cancel.BackgroundImage = global::PathologResultEntry.Properties.Resources.Cancel;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cancel.Location = new System.Drawing.Point(177, 385);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(86, 58);
            this.btn_cancel.TabIndex = 25;
            this.btn_cancel.Text = "בטל שינויים";
            this.btn_cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_save.BackgroundImage = global::PathologResultEntry.Properties.Resources.v1;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_save.Location = new System.Drawing.Point(504, 385);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(92, 58);
            this.btn_save.TabIndex = 24;
            this.btn_save.Text = "שמירה";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // MoreActionsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMsgV);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.grid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MoreActionsCtrl";
            this.Size = new System.Drawing.Size(812, 483);
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMsgV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grid;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private Telerik.WinControls.UI.RadLabel lblMsgV;


    }
}
