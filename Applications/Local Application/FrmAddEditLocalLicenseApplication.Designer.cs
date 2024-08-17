namespace DVLD___Driving_Licenses_Managment
{
    partial class FrmAddEditLocalLicenseApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPeagePersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.cntrlPersonCardWithFilter1 = new DVLD___Driving_Licenses_Managment.cntrlPersonCardWithFilter();
            this.tabPageApplicationInfo = new System.Windows.Forms.TabPage();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblCreatedByUsername = new System.Windows.Forms.Label();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPeagePersonInfo.SuspendLayout();
            this.tabPageApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPeagePersonInfo);
            this.tabControl1.Controls.Add(this.tabPageApplicationInfo);
            this.tabControl1.Location = new System.Drawing.Point(23, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(937, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPeagePersonInfo
            // 
            this.tabPeagePersonInfo.Controls.Add(this.btnNext);
            this.tabPeagePersonInfo.Controls.Add(this.cntrlPersonCardWithFilter1);
            this.tabPeagePersonInfo.Location = new System.Drawing.Point(4, 29);
            this.tabPeagePersonInfo.Name = "tabPeagePersonInfo";
            this.tabPeagePersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPeagePersonInfo.Size = new System.Drawing.Size(929, 527);
            this.tabPeagePersonInfo.TabIndex = 0;
            this.tabPeagePersonInfo.Text = "Personal Info.";
            this.tabPeagePersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.next__2_;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(795, 478);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 37);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next   ";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // cntrlPersonCardWithFilter1
            // 
            this.cntrlPersonCardWithFilter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlPersonCardWithFilter1.FilterEnabeled = true;
            this.cntrlPersonCardWithFilter1.Location = new System.Drawing.Point(6, 22);
            this.cntrlPersonCardWithFilter1.Name = "cntrlPersonCardWithFilter1";
            this.cntrlPersonCardWithFilter1.Size = new System.Drawing.Size(885, 450);
            this.cntrlPersonCardWithFilter1.TabIndex = 0;
            //this.cntrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.cntrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // tabPageApplicationInfo
            // 
            this.tabPageApplicationInfo.Controls.Add(this.pictureBox5);
            this.tabPageApplicationInfo.Controls.Add(this.pictureBox4);
            this.tabPageApplicationInfo.Controls.Add(this.pictureBox3);
            this.tabPageApplicationInfo.Controls.Add(this.pictureBox2);
            this.tabPageApplicationInfo.Controls.Add(this.pictureBox1);
            this.tabPageApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tabPageApplicationInfo.Controls.Add(this.lblApplicationID);
            this.tabPageApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tabPageApplicationInfo.Controls.Add(this.lblCreatedByUsername);
            this.tabPageApplicationInfo.Controls.Add(this.cbLicenseClasses);
            this.tabPageApplicationInfo.Controls.Add(this.label5);
            this.tabPageApplicationInfo.Controls.Add(this.label4);
            this.tabPageApplicationInfo.Controls.Add(this.label3);
            this.tabPageApplicationInfo.Controls.Add(this.label2);
            this.tabPageApplicationInfo.Controls.Add(this.label1);
            this.tabPageApplicationInfo.Location = new System.Drawing.Point(4, 29);
            this.tabPageApplicationInfo.Name = "tabPageApplicationInfo";
            this.tabPageApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageApplicationInfo.Size = new System.Drawing.Size(929, 527);
            this.tabPageApplicationInfo.TabIndex = 1;
            this.tabPageApplicationInfo.Text = "Application Info.";
            this.tabPageApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.user__1_;
            this.pictureBox5.Location = new System.Drawing.Point(296, 315);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.currency_dollar_sign2;
            this.pictureBox4.Location = new System.Drawing.Point(296, 254);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.flooding;
            this.pictureBox3.Location = new System.Drawing.Point(296, 199);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.field_date;
            this.pictureBox2.Location = new System.Drawing.Point(294, 144);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.id;
            this.pictureBox1.Location = new System.Drawing.Point(292, 89);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(361, 150);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(151, 22);
            this.lblApplicationDate.TabIndex = 11;
            this.lblApplicationDate.Text = "ApplicationDate";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(359, 95);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(66, 22);
            this.lblApplicationID.TabIndex = 10;
            this.lblApplicationID.Text = "[????]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(361, 266);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(153, 22);
            this.lblApplicationFees.TabIndex = 9;
            this.lblApplicationFees.Text = "ApplicationFees";
            // 
            // lblCreatedByUsername
            // 
            this.lblCreatedByUsername.AutoSize = true;
            this.lblCreatedByUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUsername.Location = new System.Drawing.Point(361, 321);
            this.lblCreatedByUsername.Name = "lblCreatedByUsername";
            this.lblCreatedByUsername.Size = new System.Drawing.Size(104, 22);
            this.lblCreatedByUsername.TabIndex = 8;
            this.lblCreatedByUsername.Text = "CreatedBy";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(363, 205);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(262, 28);
            this.cbLicenseClasses.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(78, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Created By User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Application Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "License Class:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "D.L Application ID:";
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(233, 13);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(114, 32);
            this.lblHeader.TabIndex = 8;
            this.lblHeader.Text = "Header ";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClose.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.cross__2_1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(704, 639);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.diskette__2_;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(822, 639);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 37);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "    Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmAddEditLocalLicenseApplication
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(995, 688);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAddEditLocalLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update Local Application Form";
            this.Activated += new System.EventHandler(this.FrmAddEditLocalLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.FrmAddEditLocalLicenseApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPeagePersonInfo.ResumeLayout(false);
            this.tabPageApplicationInfo.ResumeLayout(false);
            this.tabPageApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPeagePersonInfo;
        private System.Windows.Forms.TabPage tabPageApplicationInfo;
        private System.Windows.Forms.Label lblHeader;
        private cntrlPersonCardWithFilter cntrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblCreatedByUsername;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}