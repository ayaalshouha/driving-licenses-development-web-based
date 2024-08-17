namespace DVLD___Driving_Licenses_Managment.Applications.Detain_License
{
    partial class FrmDetainLicenseApplication
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
            this.components = new System.ComponentModel.Container();
            this.lnkShowPersonHistory = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFineFees = new System.Windows.Forms.RichTextBox();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnIDetainLicense = new System.Windows.Forms.Button();
            this.gpApplicationInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.cntrlLicenseInfoWithFilter1 = new DVLD___Driving_Licenses_Managment.Controls.cntrlLicenseInfoWithFilter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkShowPersonHistory
            // 
            this.lnkShowPersonHistory.AutoSize = true;
            this.lnkShowPersonHistory.Enabled = false;
            this.lnkShowPersonHistory.Location = new System.Drawing.Point(333, 795);
            this.lnkShowPersonHistory.Name = "lnkShowPersonHistory";
            this.lnkShowPersonHistory.Size = new System.Drawing.Size(223, 20);
            this.lnkShowPersonHistory.TabIndex = 195;
            this.lnkShowPersonHistory.TabStop = true;
            this.lnkShowPersonHistory.Text = "Show Perosn Licenses History";
            this.lnkShowPersonHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowPersonHistory_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(367, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 32);
            this.label1.TabIndex = 194;
            this.label1.Text = "Detain License";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFineFees.Location = new System.Drawing.Point(227, 102);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(77, 35);
            this.txtFineFees.TabIndex = 198;
            this.txtFineFees.Text = "";
            this.txtFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtFineFees_Validating);
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(617, 36);
            this.lblLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(55, 22);
            this.lblLicenseID.TabIndex = 191;
            this.lblLicenseID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(408, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 22);
            this.label10.TabIndex = 190;
            this.label10.Text = "License ID:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(658, 795);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 190;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(408, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 22);
            this.label3.TabIndex = 181;
            this.label3.Text = "Created By:";
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(617, 68);
            this.lblCreatedByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(66, 22);
            this.lblCreatedByUser.TabIndex = 180;
            this.lblCreatedByUser.Text = "[????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 22);
            this.label2.TabIndex = 177;
            this.label2.Text = "Fine Fees:";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(223, 68);
            this.lblDetainDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(122, 22);
            this.lblDetainDate.TabIndex = 176;
            this.lblDetainDate.Text = "[??/??/????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 22);
            this.label5.TabIndex = 174;
            this.label5.Text = "Detain Date:";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(223, 36);
            this.lblDetainID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(55, 22);
            this.lblDetainID.TabIndex = 173;
            this.lblDetainID.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 22);
            this.label4.TabIndex = 172;
            this.label4.Text = "Detain ID:";
            // 
            // lnkShowLicenseInfo
            // 
            this.lnkShowLicenseInfo.AutoSize = true;
            this.lnkShowLicenseInfo.Enabled = false;
            this.lnkShowLicenseInfo.Location = new System.Drawing.Point(89, 795);
            this.lnkShowLicenseInfo.Name = "lnkShowLicenseInfo";
            this.lnkShowLicenseInfo.Size = new System.Drawing.Size(140, 20);
            this.lnkShowLicenseInfo.TabIndex = 192;
            this.lnkShowLicenseInfo.TabStop = true;
            this.lnkShowLicenseInfo.Text = "Show License Info";
            this.lnkShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseInfo_LinkClicked);
            // 
            // btnIDetainLicense
            // 
            this.btnIDetainLicense.Enabled = false;
            this.btnIDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIDetainLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIDetainLicense.Location = new System.Drawing.Point(792, 795);
            this.btnIDetainLicense.Name = "btnIDetainLicense";
            this.btnIDetainLicense.Size = new System.Drawing.Size(126, 37);
            this.btnIDetainLicense.TabIndex = 191;
            this.btnIDetainLicense.Text = "Detain";
            this.btnIDetainLicense.UseVisualStyleBackColor = true;
            this.btnIDetainLicense.Click += new System.EventHandler(this.btnIDetainLicense_Click);
            // 
            // gpApplicationInfo
            // 
            this.gpApplicationInfo.Controls.Add(this.txtFineFees);
            this.gpApplicationInfo.Controls.Add(this.lblLicenseID);
            this.gpApplicationInfo.Controls.Add(this.label10);
            this.gpApplicationInfo.Controls.Add(this.label3);
            this.gpApplicationInfo.Controls.Add(this.lblCreatedByUser);
            this.gpApplicationInfo.Controls.Add(this.label2);
            this.gpApplicationInfo.Controls.Add(this.lblDetainDate);
            this.gpApplicationInfo.Controls.Add(this.label5);
            this.gpApplicationInfo.Controls.Add(this.lblDetainID);
            this.gpApplicationInfo.Controls.Add(this.label4);
            this.gpApplicationInfo.Location = new System.Drawing.Point(31, 619);
            this.gpApplicationInfo.Name = "gpApplicationInfo";
            this.gpApplicationInfo.Size = new System.Drawing.Size(887, 148);
            this.gpApplicationInfo.TabIndex = 189;
            this.gpApplicationInfo.TabStop = false;
            this.gpApplicationInfo.Text = "Detain Info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.pictureBox1.Location = new System.Drawing.Point(291, 791);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 196;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.pictureBox4.Location = new System.Drawing.Point(47, 791);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 193;
            this.pictureBox4.TabStop = false;
            // 
            // cntrlLicenseInfoWithFilter1
            // 
            this.cntrlLicenseInfoWithFilter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlLicenseInfoWithFilter1.FilterEnabled = true;
            this.cntrlLicenseInfoWithFilter1.ID = -1;
            this.cntrlLicenseInfoWithFilter1.Location = new System.Drawing.Point(31, 44);
            this.cntrlLicenseInfoWithFilter1.Name = "cntrlLicenseInfoWithFilter1";
            this.cntrlLicenseInfoWithFilter1.Size = new System.Drawing.Size(898, 558);
            this.cntrlLicenseInfoWithFilter1.TabIndex = 188;
            this.cntrlLicenseInfoWithFilter1.OnLicenseSelected += new System.EventHandler<DVLD___Driving_Licenses_Managment.Controls.cntrlLicenseInfoWithFilter.LicensesSelectedEventArgs>(this.cntrlLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmDetainLicenseApplication
            // 
            this.AcceptButton = this.btnIDetainLicense;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(937, 868);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lnkShowPersonHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cntrlLicenseInfoWithFilter1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lnkShowLicenseInfo);
            this.Controls.Add(this.btnIDetainLicense);
            this.Controls.Add(this.gpApplicationInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDetainLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detain License Form";
            this.gpApplicationInfo.ResumeLayout(false);
            this.gpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkShowPersonHistory;
        private System.Windows.Forms.Label label1;
        private Controls.cntrlLicenseInfoWithFilter cntrlLicenseInfoWithFilter1;
        private System.Windows.Forms.RichTextBox txtFineFees;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.LinkLabel lnkShowLicenseInfo;
        private System.Windows.Forms.Button btnIDetainLicense;
        private System.Windows.Forms.GroupBox gpApplicationInfo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}