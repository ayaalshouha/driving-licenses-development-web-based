namespace DVLD___Driving_Licenses_Managment.Controls
{
    partial class cntrlScheduleTest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.pbTestTypeImage = new System.Windows.Forms.PictureBox();
            this.gbTestType = new System.Windows.Forms.GroupBox();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbRetakeTest = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRetakeTestID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRetakeFees = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblApplicantName = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).BeginInit();
            this.gbTestType.SuspendLayout();
            this.gbRetakeTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Simplified Arabic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(101, 160);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(208, 54);
            this.lblHeader.TabIndex = 18;
            this.lblHeader.Text = "Schedule Test";
            // 
            // pbTestTypeImage
            // 
            this.pbTestTypeImage.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.street_racing_config;
            this.pbTestTypeImage.Location = new System.Drawing.Point(134, 20);
            this.pbTestTypeImage.Name = "pbTestTypeImage";
            this.pbTestTypeImage.Size = new System.Drawing.Size(182, 134);
            this.pbTestTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestTypeImage.TabIndex = 17;
            this.pbTestTypeImage.TabStop = false;
            // 
            // gbTestType
            // 
            this.gbTestType.Controls.Add(this.lblUserMessage);
            this.gbTestType.Controls.Add(this.btnSave);
            this.gbTestType.Controls.Add(this.gbRetakeTest);
            this.gbTestType.Controls.Add(this.datePicker);
            this.gbTestType.Controls.Add(this.label2);
            this.gbTestType.Controls.Add(this.lblLicenseID);
            this.gbTestType.Controls.Add(this.label7);
            this.gbTestType.Controls.Add(this.lblFullName);
            this.gbTestType.Controls.Add(this.lblApplicantName);
            this.gbTestType.Controls.Add(this.lblFees);
            this.gbTestType.Controls.Add(this.label11);
            this.gbTestType.Controls.Add(this.label1);
            this.gbTestType.Controls.Add(this.lblClassName);
            this.gbTestType.Controls.Add(this.pbTestTypeImage);
            this.gbTestType.Location = new System.Drawing.Point(9, 3);
            this.gbTestType.Name = "gbTestType";
            this.gbTestType.Size = new System.Drawing.Size(451, 682);
            this.gbTestType.TabIndex = 19;
            this.gbTestType.TabStop = false;
            this.gbTestType.Text = "Test Type";
            //this.gbTestType.Enter += new System.EventHandler(this.gbTestType_Enter);
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.AutoSize = true;
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Brown;
            this.lblUserMessage.Location = new System.Drawing.Point(34, 211);
            this.lblUserMessage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(333, 26);
            this.lblUserMessage.TabIndex = 189;
            this.lblUserMessage.Text = "This Appointment is LOCKED!";
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUserMessage.Visible = false;
            //this.lblUserMessage.Click += new System.EventHandler(this.lblUserMessage_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.diskette__2_;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(304, 625);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 37);
            this.btnSave.TabIndex = 59;
            this.btnSave.Text = "    Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbRetakeTest
            // 
            this.gbRetakeTest.Controls.Add(this.lblTotalFees);
            this.gbRetakeTest.Controls.Add(this.label4);
            this.gbRetakeTest.Controls.Add(this.lblRetakeTestID);
            this.gbRetakeTest.Controls.Add(this.label6);
            this.gbRetakeTest.Controls.Add(this.label8);
            this.gbRetakeTest.Controls.Add(this.lblRetakeFees);
            this.gbRetakeTest.Enabled = false;
            this.gbRetakeTest.Location = new System.Drawing.Point(6, 473);
            this.gbRetakeTest.Name = "gbRetakeTest";
            this.gbRetakeTest.Size = new System.Drawing.Size(439, 146);
            this.gbRetakeTest.TabIndex = 58;
            this.gbRetakeTest.TabStop = false;
            this.gbRetakeTest.Text = "Retake Test Info";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(227, 101);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(59, 20);
            this.lblTotalFees.TabIndex = 57;
            this.lblTotalFees.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 20);
            this.label4.TabIndex = 58;
            this.label4.Text = "Retake App.Fees:";
            // 
            // lblRetakeTestID
            // 
            this.lblRetakeTestID.AutoSize = true;
            this.lblRetakeTestID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeTestID.ForeColor = System.Drawing.Color.Maroon;
            this.lblRetakeTestID.Location = new System.Drawing.Point(227, 39);
            this.lblRetakeTestID.Name = "lblRetakeTestID";
            this.lblRetakeTestID.Size = new System.Drawing.Size(59, 20);
            this.lblRetakeTestID.TabIndex = 60;
            this.lblRetakeTestID.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 59;
            this.label6.Text = "Total Fees:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 20);
            this.label8.TabIndex = 56;
            this.label8.Text = "Retake ApplicationID:";
            // 
            // lblRetakeFees
            // 
            this.lblRetakeFees.AutoSize = true;
            this.lblRetakeFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeFees.Location = new System.Drawing.Point(227, 70);
            this.lblRetakeFees.Name = "lblRetakeFees";
            this.lblRetakeFees.Size = new System.Drawing.Size(59, 20);
            this.lblRetakeFees.TabIndex = 61;
            this.lblRetakeFees.Text = "[????]";
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(196, 389);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(147, 26);
            this.datePicker.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Appointment Date:";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(196, 263);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(59, 20);
            this.lblLicenseID.TabIndex = 49;
            this.lblLicenseID.Text = "[????]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "D.L Class:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.Maroon;
            this.lblFullName.Location = new System.Drawing.Point(196, 347);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(59, 20);
            this.lblFullName.TabIndex = 54;
            this.lblFullName.Text = "[????]";
            // 
            // lblApplicantName
            // 
            this.lblApplicantName.AutoSize = true;
            this.lblApplicantName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicantName.Location = new System.Drawing.Point(35, 347);
            this.lblApplicantName.Name = "lblApplicantName";
            this.lblApplicantName.Size = new System.Drawing.Size(140, 20);
            this.lblApplicantName.TabIndex = 53;
            this.lblApplicantName.Text = "Applicant Name:";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(196, 431);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(59, 20);
            this.lblFees.TabIndex = 52;
            this.lblFees.Text = "[????]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(122, 431);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 51;
            this.label11.Text = "Fees:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "D.L Application ID:";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.Location = new System.Drawing.Point(110, 303);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(59, 20);
            this.lblClassName.TabIndex = 55;
            this.lblClassName.Text = "[????]";
            // 
            // cntrlScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.gbTestType);
            this.Name = "cntrlScheduleTest";
            this.Size = new System.Drawing.Size(468, 699);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).EndInit();
            this.gbTestType.ResumeLayout(false);
            this.gbTestType.PerformLayout();
            this.gbRetakeTest.ResumeLayout(false);
            this.gbRetakeTest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestTypeImage;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox gbTestType;
        private System.Windows.Forms.GroupBox gbRetakeTest;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRetakeTestID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRetakeFees;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUserMessage;
    }
}
