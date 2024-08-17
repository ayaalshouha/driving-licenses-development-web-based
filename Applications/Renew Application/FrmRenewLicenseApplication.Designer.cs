namespace DVLD___Driving_Licenses_Managment.Applications.Renew_Application
{
    partial class FrmRenewLicenseApplication
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
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lnkShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnIssueLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gpApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblRenewlLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRenewApplicationID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lnkShowPersonHistory = new System.Windows.Forms.LinkLabel();
            this.cntrlLicenseInfoWithFilter1 = new DVLD___Driving_Licenses_Managment.Controls.cntrlLicenseInfoWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.gpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.pictureBox4.Location = new System.Drawing.Point(25, 939);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 184;
            this.pictureBox4.TabStop = false;
            // 
            // lnkShowNewLicenseInfo
            // 
            this.lnkShowNewLicenseInfo.AutoSize = true;
            this.lnkShowNewLicenseInfo.Enabled = false;
            this.lnkShowNewLicenseInfo.Location = new System.Drawing.Point(67, 943);
            this.lnkShowNewLicenseInfo.Name = "lnkShowNewLicenseInfo";
            this.lnkShowNewLicenseInfo.Size = new System.Drawing.Size(175, 20);
            this.lnkShowNewLicenseInfo.TabIndex = 183;
            this.lnkShowNewLicenseInfo.TabStop = true;
            this.lnkShowNewLicenseInfo.Text = "Show New License Info";
            this.lnkShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowInternationalLicenseInfo_LinkClicked);
            // 
            // btnIssueLicense
            // 
            this.btnIssueLicense.Enabled = false;
            this.btnIssueLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueLicense.Location = new System.Drawing.Point(770, 943);
            this.btnIssueLicense.Name = "btnIssueLicense";
            this.btnIssueLicense.Size = new System.Drawing.Size(126, 37);
            this.btnIssueLicense.TabIndex = 182;
            this.btnIssueLicense.Text = "Renew";
            this.btnIssueLicense.UseVisualStyleBackColor = true;
            this.btnIssueLicense.Click += new System.EventHandler(this.btnIssueLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(636, 943);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 181;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gpApplicationInfo
            // 
            this.gpApplicationInfo.Controls.Add(this.lblTotalFees);
            this.gpApplicationInfo.Controls.Add(this.label13);
            this.gpApplicationInfo.Controls.Add(this.txtNotes);
            this.gpApplicationInfo.Controls.Add(this.label7);
            this.gpApplicationInfo.Controls.Add(this.lblLicenseFees);
            this.gpApplicationInfo.Controls.Add(this.label9);
            this.gpApplicationInfo.Controls.Add(this.lblOldLicenseID);
            this.gpApplicationInfo.Controls.Add(this.label12);
            this.gpApplicationInfo.Controls.Add(this.lblRenewlLicenseID);
            this.gpApplicationInfo.Controls.Add(this.label10);
            this.gpApplicationInfo.Controls.Add(this.lblExpirationDate);
            this.gpApplicationInfo.Controls.Add(this.label8);
            this.gpApplicationInfo.Controls.Add(this.lblIssueDate);
            this.gpApplicationInfo.Controls.Add(this.label6);
            this.gpApplicationInfo.Controls.Add(this.label3);
            this.gpApplicationInfo.Controls.Add(this.lblCreatedByUser);
            this.gpApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gpApplicationInfo.Controls.Add(this.label2);
            this.gpApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gpApplicationInfo.Controls.Add(this.label5);
            this.gpApplicationInfo.Controls.Add(this.lblRenewApplicationID);
            this.gpApplicationInfo.Controls.Add(this.label4);
            this.gpApplicationInfo.Location = new System.Drawing.Point(12, 624);
            this.gpApplicationInfo.Name = "gpApplicationInfo";
            this.gpApplicationInfo.Size = new System.Drawing.Size(887, 286);
            this.gpApplicationInfo.TabIndex = 180;
            this.gpApplicationInfo.TabStop = false;
            this.gpApplicationInfo.Text = "Application Info";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(619, 170);
            this.lblTotalFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(55, 22);
            this.lblTotalFees.TabIndex = 200;
            this.lblTotalFees.Text = "[$$$]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(410, 170);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 22);
            this.label13.TabIndex = 199;
            this.label13.Text = "Total Fees:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(136, 206);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(581, 64);
            this.txtNotes.TabIndex = 198;
            this.txtNotes.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 207);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 22);
            this.label7.TabIndex = 197;
            this.label7.Text = "NOTES:";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseFees.Location = new System.Drawing.Point(225, 170);
            this.lblLicenseFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(55, 22);
            this.lblLicenseFees.TabIndex = 196;
            this.lblLicenseFees.Text = "[$$$]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 170);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 22);
            this.label9.TabIndex = 195;
            this.label9.Text = "License Fees:";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(619, 72);
            this.lblOldLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(55, 22);
            this.lblOldLicenseID.TabIndex = 194;
            this.lblOldLicenseID.Text = "[???]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(410, 72);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 22);
            this.label12.TabIndex = 193;
            this.label12.Text = "Old License ID:";
            // 
            // lblRenewlLicenseID
            // 
            this.lblRenewlLicenseID.AutoSize = true;
            this.lblRenewlLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewlLicenseID.Location = new System.Drawing.Point(619, 40);
            this.lblRenewlLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRenewlLicenseID.Name = "lblRenewlLicenseID";
            this.lblRenewlLicenseID.Size = new System.Drawing.Size(55, 22);
            this.lblRenewlLicenseID.TabIndex = 191;
            this.lblRenewlLicenseID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(410, 40);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 22);
            this.label10.TabIndex = 190;
            this.label10.Text = "Renewed License ID:";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDate.Location = new System.Drawing.Point(619, 104);
            this.lblExpirationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(122, 22);
            this.lblExpirationDate.TabIndex = 189;
            this.lblExpirationDate.Text = "[??/??/????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(410, 104);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 22);
            this.label8.TabIndex = 187;
            this.label8.Text = "Expiration Date:";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(225, 104);
            this.lblIssueDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(122, 22);
            this.lblIssueDate.TabIndex = 186;
            this.lblIssueDate.Text = "[??/??/????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 104);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 22);
            this.label6.TabIndex = 184;
            this.label6.Text = "Issue Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(410, 136);
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
            this.lblCreatedByUser.Location = new System.Drawing.Point(619, 136);
            this.lblCreatedByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(66, 22);
            this.lblCreatedByUser.TabIndex = 180;
            this.lblCreatedByUser.Text = "[????]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(225, 136);
            this.lblApplicationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(55, 22);
            this.lblApplicationFees.TabIndex = 179;
            this.lblApplicationFees.Text = "[$$$]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 22);
            this.label2.TabIndex = 177;
            this.label2.Text = "Application Fees:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(225, 72);
            this.lblApplicationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(122, 22);
            this.lblApplicationDate.TabIndex = 176;
            this.lblApplicationDate.Text = "[??/??/????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 22);
            this.label5.TabIndex = 174;
            this.label5.Text = "Application Date:";
            // 
            // lblRenewApplicationID
            // 
            this.lblRenewApplicationID.AutoSize = true;
            this.lblRenewApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewApplicationID.Location = new System.Drawing.Point(225, 40);
            this.lblRenewApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRenewApplicationID.Name = "lblRenewApplicationID";
            this.lblRenewApplicationID.Size = new System.Drawing.Size(55, 22);
            this.lblRenewApplicationID.TabIndex = 173;
            this.lblRenewApplicationID.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 22);
            this.label4.TabIndex = 172;
            this.label4.Text = "Renew.L.App.ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(284, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 32);
            this.label1.TabIndex = 185;
            this.label1.Text = "Renew License Application";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.pictureBox1.Location = new System.Drawing.Point(269, 939);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 187;
            this.pictureBox1.TabStop = false;
            // 
            // lnkShowPersonHistory
            // 
            this.lnkShowPersonHistory.AutoSize = true;
            this.lnkShowPersonHistory.Enabled = false;
            this.lnkShowPersonHistory.Location = new System.Drawing.Point(311, 943);
            this.lnkShowPersonHistory.Name = "lnkShowPersonHistory";
            this.lnkShowPersonHistory.Size = new System.Drawing.Size(223, 20);
            this.lnkShowPersonHistory.TabIndex = 186;
            this.lnkShowPersonHistory.TabStop = true;
            this.lnkShowPersonHistory.Text = "Show Perosn Licenses History";
            this.lnkShowPersonHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ShowPersonHistory_LinkClicked);
            // 
            // cntrlLicenseInfoWithFilter1
            // 
            this.cntrlLicenseInfoWithFilter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlLicenseInfoWithFilter1.FilterEnabled = true;
            this.cntrlLicenseInfoWithFilter1.ID = -1;
            this.cntrlLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 49);
            this.cntrlLicenseInfoWithFilter1.Name = "cntrlLicenseInfoWithFilter1";
            this.cntrlLicenseInfoWithFilter1.Size = new System.Drawing.Size(898, 558);
            this.cntrlLicenseInfoWithFilter1.TabIndex = 0;
            this.cntrlLicenseInfoWithFilter1.OnLicenseSelected += new System.EventHandler<DVLD___Driving_Licenses_Managment.Controls.cntrlLicenseInfoWithFilter.LicensesSelectedEventArgs>(this.cntrlLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // FrmRenewLicenseApplication
            // 
            this.AcceptButton = this.btnIssueLicense;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(924, 1014);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lnkShowPersonHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lnkShowNewLicenseInfo);
            this.Controls.Add(this.btnIssueLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpApplicationInfo);
            this.Controls.Add(this.cntrlLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRenewLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew License Application";
            this.Load += new System.EventHandler(this.FrmRenewLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.gpApplicationInfo.ResumeLayout(false);
            this.gpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.cntrlLicenseInfoWithFilter cntrlLicenseInfoWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.LinkLabel lnkShowNewLicenseInfo;
        private System.Windows.Forms.Button btnIssueLicense;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gpApplicationInfo;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblRenewlLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRenewApplicationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkShowPersonHistory;
    }
}