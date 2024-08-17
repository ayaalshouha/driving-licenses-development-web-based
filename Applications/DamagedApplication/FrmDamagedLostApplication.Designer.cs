namespace DVLD___Driving_Licenses_Managment.Applications.DamagedApplication
{
    partial class FrmDamagedLostApplication
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
            this.cntrlLicenseInfoWithFilter1 = new DVLD___Driving_Licenses_Managment.Controls.cntrlLicenseInfoWithFilter();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblOl = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIssueLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReplacementApplicationID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpApplicationInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.rdLost = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lnkShowPersonHistory = new System.Windows.Forms.LinkLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lnkShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.gpApplicationInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // cntrlLicenseInfoWithFilter1
            // 
            this.cntrlLicenseInfoWithFilter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlLicenseInfoWithFilter1.FilterEnabled = true;
            this.cntrlLicenseInfoWithFilter1.ID = -1;
            this.cntrlLicenseInfoWithFilter1.Location = new System.Drawing.Point(11, 49);
            this.cntrlLicenseInfoWithFilter1.Name = "cntrlLicenseInfoWithFilter1";
            this.cntrlLicenseInfoWithFilter1.Size = new System.Drawing.Size(898, 558);
            this.cntrlLicenseInfoWithFilter1.TabIndex = 180;
            this.cntrlLicenseInfoWithFilter1.OnLicenseSelected += new System.EventHandler<DVLD___Driving_Licenses_Managment.Controls.cntrlLicenseInfoWithFilter.LicensesSelectedEventArgs>(this.cntrlLicenseInfoWithFilter1_OnLicenseSelected);
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
            // lblOl
            // 
            this.lblOl.AutoSize = true;
            this.lblOl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblOl.Location = new System.Drawing.Point(410, 72);
            this.lblOl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOl.Name = "lblOl";
            this.lblOl.Size = new System.Drawing.Size(147, 22);
            this.lblOl.TabIndex = 193;
            this.lblOl.Text = "Old License ID:";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(619, 40);
            this.lblReplacedLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(55, 22);
            this.lblReplacedLicenseID.TabIndex = 191;
            this.lblReplacedLicenseID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(410, 40);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 22);
            this.label10.TabIndex = 190;
            this.label10.Text = "Replaced L.ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(410, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 22);
            this.label3.TabIndex = 181;
            this.label3.Text = "Created By:";
            // 
            // btnIssueLicense
            // 
            this.btnIssueLicense.Enabled = false;
            this.btnIssueLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueLicense.Location = new System.Drawing.Point(904, 790);
            this.btnIssueLicense.Name = "btnIssueLicense";
            this.btnIssueLicense.Size = new System.Drawing.Size(175, 37);
            this.btnIssueLicense.TabIndex = 184;
            this.btnIssueLicense.Text = "Issue Replacement";
            this.btnIssueLicense.UseVisualStyleBackColor = true;
            this.btnIssueLicense.Click += new System.EventHandler(this.btnIssueLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(770, 790);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 183;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(619, 110);
            this.lblCreatedByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(66, 22);
            this.lblCreatedByUser.TabIndex = 180;
            this.lblCreatedByUser.Text = "[????]";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(223, 110);
            this.lblFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(55, 22);
            this.lblFees.TabIndex = 179;
            this.lblFees.Text = "[$$$]";
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
            // lblReplacementApplicationID
            // 
            this.lblReplacementApplicationID.AutoSize = true;
            this.lblReplacementApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacementApplicationID.Location = new System.Drawing.Point(225, 40);
            this.lblReplacementApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplacementApplicationID.Name = "lblReplacementApplicationID";
            this.lblReplacementApplicationID.Size = new System.Drawing.Size(55, 22);
            this.lblReplacementApplicationID.TabIndex = 173;
            this.lblReplacementApplicationID.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 22);
            this.label4.TabIndex = 172;
            this.label4.Text = "L.R.Application ID:";
            // 
            // gpApplicationInfo
            // 
            this.gpApplicationInfo.Controls.Add(this.lblOldLicenseID);
            this.gpApplicationInfo.Controls.Add(this.lblOl);
            this.gpApplicationInfo.Controls.Add(this.lblReplacedLicenseID);
            this.gpApplicationInfo.Controls.Add(this.label10);
            this.gpApplicationInfo.Controls.Add(this.label3);
            this.gpApplicationInfo.Controls.Add(this.lblCreatedByUser);
            this.gpApplicationInfo.Controls.Add(this.lblFees);
            this.gpApplicationInfo.Controls.Add(this.label2);
            this.gpApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gpApplicationInfo.Controls.Add(this.label5);
            this.gpApplicationInfo.Controls.Add(this.lblReplacementApplicationID);
            this.gpApplicationInfo.Controls.Add(this.label4);
            this.gpApplicationInfo.Location = new System.Drawing.Point(22, 613);
            this.gpApplicationInfo.Name = "gpApplicationInfo";
            this.gpApplicationInfo.Size = new System.Drawing.Size(1080, 165);
            this.gpApplicationInfo.TabIndex = 182;
            this.gpApplicationInfo.TabStop = false;
            this.gpApplicationInfo.Text = "Replacement Application Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 22);
            this.label2.TabIndex = 177;
            this.label2.Text = "Application Fees:";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(334, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(458, 32);
            this.lblHeader.TabIndex = 181;
            this.lblHeader.Text = "Replacement for Damaged License";
            this.lblHeader.Click += new System.EventHandler(this.label1_Click);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Checked = true;
            this.rbDamaged.Location = new System.Drawing.Point(12, 34);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(104, 24);
            this.rbDamaged.TabIndex = 187;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // rdLost
            // 
            this.rdLost.AutoSize = true;
            this.rdLost.Location = new System.Drawing.Point(12, 64);
            this.rdLost.Name = "rdLost";
            this.rdLost.Size = new System.Drawing.Size(65, 24);
            this.rdLost.TabIndex = 188;
            this.rdLost.Text = "Lost";
            this.rdLost.UseVisualStyleBackColor = true;
            this.rdLost.CheckedChanged += new System.EventHandler(this.rdLost_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(474, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 189;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDamaged);
            this.groupBox1.Controls.Add(this.rdLost);
            this.groupBox1.Location = new System.Drawing.Point(904, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 101);
            this.groupBox1.TabIndex = 190;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement for:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.pictureBox1.Location = new System.Drawing.Point(295, 786);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 194;
            this.pictureBox1.TabStop = false;
            // 
            // lnkShowPersonHistory
            // 
            this.lnkShowPersonHistory.AutoSize = true;
            this.lnkShowPersonHistory.Enabled = false;
            this.lnkShowPersonHistory.Location = new System.Drawing.Point(337, 790);
            this.lnkShowPersonHistory.Name = "lnkShowPersonHistory";
            this.lnkShowPersonHistory.Size = new System.Drawing.Size(223, 20);
            this.lnkShowPersonHistory.TabIndex = 193;
            this.lnkShowPersonHistory.TabStop = true;
            this.lnkShowPersonHistory.Text = "Show Perosn Licenses History";
            this.lnkShowPersonHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowPersonHistory_LinkClicked);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.pictureBox4.Location = new System.Drawing.Point(51, 786);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 192;
            this.pictureBox4.TabStop = false;
            // 
            // lnkShowNewLicenseInfo
            // 
            this.lnkShowNewLicenseInfo.AutoSize = true;
            this.lnkShowNewLicenseInfo.Enabled = false;
            this.lnkShowNewLicenseInfo.Location = new System.Drawing.Point(93, 790);
            this.lnkShowNewLicenseInfo.Name = "lnkShowNewLicenseInfo";
            this.lnkShowNewLicenseInfo.Size = new System.Drawing.Size(175, 20);
            this.lnkShowNewLicenseInfo.TabIndex = 191;
            this.lnkShowNewLicenseInfo.TabStop = true;
            this.lnkShowNewLicenseInfo.Text = "Show New License Info";
            this.lnkShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowNewLicenseInfo_LinkClicked);
            // 
            // FrmDamagedLostApplication
            // 
            this.AcceptButton = this.btnIssueLicense;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1126, 854);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lnkShowPersonHistory);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lnkShowNewLicenseInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cntrlLicenseInfoWithFilter1);
            this.Controls.Add(this.btnIssueLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpApplicationInfo);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDamagedLostApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDamagedLostApplication";
            this.Load += new System.EventHandler(this.FrmDamagedLostApplication_Load);
            this.gpApplicationInfo.ResumeLayout(false);
            this.gpApplicationInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.cntrlLicenseInfoWithFilter cntrlLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblOl;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIssueLicense;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReplacementApplicationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gpApplicationInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.RadioButton rbDamaged;
        private System.Windows.Forms.RadioButton rdLost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkShowPersonHistory;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.LinkLabel lnkShowNewLicenseInfo;
    }
}