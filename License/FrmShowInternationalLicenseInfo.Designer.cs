namespace DVLD___Driving_Licenses_Managment.License
{
    partial class FrmShowInternationalLicenseInfo
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
            this.button1 = new System.Windows.Forms.Button();
            this.cntrlInternationalLicenseInfo1 = new DVLD___Driving_Licenses_Managment.Controls.cntrlInternationalLicenseInfo();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.cross__2_1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(770, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 207;
            this.button1.Text = "   Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cntrlInternationalLicenseInfo1
            // 
            this.cntrlInternationalLicenseInfo1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlInternationalLicenseInfo1.Location = new System.Drawing.Point(12, 12);
            this.cntrlInternationalLicenseInfo1.Name = "cntrlInternationalLicenseInfo1";
            this.cntrlInternationalLicenseInfo1.Size = new System.Drawing.Size(879, 418);
            this.cntrlInternationalLicenseInfo1.TabIndex = 0;
            // 
            // FrmShowInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(905, 493);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cntrlInternationalLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmShowInternationalLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International License Info";
            this.Load += new System.EventHandler(this.FrmShowInternationalLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.cntrlInternationalLicenseInfo cntrlInternationalLicenseInfo1;
        private System.Windows.Forms.Button button1;
    }
}