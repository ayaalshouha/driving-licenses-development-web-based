namespace DVLD___Driving_Licenses_Managment.License
{
    partial class FrmShowLicenseInfo
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
            this.cntrlLicenseInfo1 = new DVLD___Driving_Licenses_Managment.Controls.cntrlLicenseInfo();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cntrlLicenseInfo1
            // 
            this.cntrlLicenseInfo1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlLicenseInfo1.Location = new System.Drawing.Point(12, 12);
            this.cntrlLicenseInfo1.Name = "cntrlLicenseInfo1";
            this.cntrlLicenseInfo1.Size = new System.Drawing.Size(886, 474);
            this.cntrlLicenseInfo1.TabIndex = 0;
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
            this.button1.Location = new System.Drawing.Point(781, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 204;
            this.button1.Text = "   Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(922, 544);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cntrlLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmShowLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show License Info";
            this.Load += new System.EventHandler(this.FrmShowLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.cntrlLicenseInfo cntrlLicenseInfo1;
        private System.Windows.Forms.Button button1;
    }
}