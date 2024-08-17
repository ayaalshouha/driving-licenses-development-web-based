namespace DVLD___Driving_Licenses_Managment.Applications.Local_Application
{
    partial class FrmShpwApplicationInfo
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
            this.cntrl1 = new DVLD___Driving_Licenses_Managment.Controls.cntrlDrivingLicenseAndApplicationBasicInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cntrl1
            // 
            this.cntrl1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrl1.Location = new System.Drawing.Point(12, 12);
            this.cntrl1.Name = "cntrl1";
            this.cntrl1.Size = new System.Drawing.Size(1046, 479);
            this.cntrl1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.cross__2_1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(935, 497);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmShpwApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1065, 550);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cntrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmShpwApplicationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Info";
            this.Load += new System.EventHandler(this.FrmShpwApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.cntrlDrivingLicenseAndApplicationBasicInfo cntrl1;
        private System.Windows.Forms.Button btnClose;
    }
}