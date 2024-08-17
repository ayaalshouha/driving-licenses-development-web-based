namespace DVLD___Driving_Licenses_Managment
{
    partial class FrmManageUsers
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
            this.lblRecordNumber = new System.Windows.Forms.Label();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvUsersList = new System.Windows.Forms.DataGridView();
            this.cmUserListOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAddPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbActiveChoices = new System.Windows.Forms.ComboBox();
            this.pbAddUser = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).BeginInit();
            this.cmUserListOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordNumber
            // 
            this.lblRecordNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordNumber.AutoSize = true;
            this.lblRecordNumber.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordNumber.ForeColor = System.Drawing.Color.Black;
            this.lblRecordNumber.Location = new System.Drawing.Point(185, 586);
            this.lblRecordNumber.Name = "lblRecordNumber";
            this.lblRecordNumber.Size = new System.Drawing.Size(87, 38);
            this.lblRecordNumber.TabIndex = 19;
            this.lblRecordNumber.Text = "Number";
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsNum.Location = new System.Drawing.Point(72, 586);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(123, 38);
            this.lblRecordsNum.TabIndex = 18;
            this.lblRecordsNum.Text = "# Records: ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(387, 230);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 26);
            this.textBox1.TabIndex = 17;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 20;
            this.comboBox1.Location = new System.Drawing.Point(167, 230);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 28);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simplified Arabic", 11F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(73, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 38);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filter by:";
            //this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvUsersList
            // 
            this.dgvUsersList.AllowUserToAddRows = false;
            this.dgvUsersList.AllowUserToDeleteRows = false;
            this.dgvUsersList.AllowUserToOrderColumns = true;
            this.dgvUsersList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvUsersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsersList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsersList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersList.ContextMenuStrip = this.cmUserListOptions;
            this.dgvUsersList.Location = new System.Drawing.Point(75, 267);
            this.dgvUsersList.Name = "dgvUsersList";
            this.dgvUsersList.ReadOnly = true;
            this.dgvUsersList.RowHeadersWidth = 50;
            this.dgvUsersList.RowTemplate.Height = 28;
            this.dgvUsersList.Size = new System.Drawing.Size(740, 316);
            this.dgvUsersList.TabIndex = 10;
            // 
            // cmUserListOptions
            // 
            this.cmUserListOptions.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmUserListOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmUserListOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDetails,
            this.toolStripMenuItem1,
            this.tsmAddPerson,
            this.tsmEdit,
            this.tsmDelete,
            this.tsmChangePassword,
            this.toolStripSeparator1,
            this.tsmSendEmail,
            this.tsmPhoneCall});
            this.cmUserListOptions.Name = "cmPeopleListOptions";
            this.cmUserListOptions.Size = new System.Drawing.Size(212, 240);
            // 
            // tsmShowDetails
            // 
            this.tsmShowDetails.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowDetails.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.tsmShowDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmShowDetails.Name = "tsmShowDetails";
            this.tsmShowDetails.Size = new System.Drawing.Size(211, 32);
            this.tsmShowDetails.Text = "Show Details";
            this.tsmShowDetails.Click += new System.EventHandler(this.tsmShowDetails_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmAddPerson
            // 
            this.tsmAddPerson.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAddPerson.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.add;
            this.tsmAddPerson.Name = "tsmAddPerson";
            this.tsmAddPerson.Size = new System.Drawing.Size(211, 32);
            this.tsmAddPerson.Text = "Add New User";
            this.tsmAddPerson.Click += new System.EventHandler(this.tsmAddPerson_Click);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.edit;
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(211, 32);
            this.tsmEdit.Text = "Edit User";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.delete;
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(211, 32);
            this.tsmDelete.Text = "Delete User";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tsmChangePassword
            // 
            this.tsmChangePassword.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.changepass1;
            this.tsmChangePassword.Name = "tsmChangePassword";
            this.tsmChangePassword.Size = new System.Drawing.Size(211, 32);
            this.tsmChangePassword.Text = "Change Password";
            this.tsmChangePassword.Click += new System.EventHandler(this.tsmChangePassword_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmSendEmail
            // 
            this.tsmSendEmail.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.mail_up;
            this.tsmSendEmail.Name = "tsmSendEmail";
            this.tsmSendEmail.Size = new System.Drawing.Size(211, 32);
            this.tsmSendEmail.Text = "Send Email";
            // 
            // tsmPhoneCall
            // 
            this.tsmPhoneCall.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.at_phone;
            this.tsmPhoneCall.Name = "tsmPhoneCall";
            this.tsmPhoneCall.Size = new System.Drawing.Size(211, 32);
            this.tsmPhoneCall.Text = "Phone Call";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(350, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 54);
            this.label1.TabIndex = 12;
            this.label1.Text = "Manage Users";
            // 
            // cbActiveChoices
            // 
            this.cbActiveChoices.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbActiveChoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActiveChoices.FormattingEnabled = true;
            this.cbActiveChoices.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbActiveChoices.Location = new System.Drawing.Point(387, 230);
            this.cbActiveChoices.Name = "cbActiveChoices";
            this.cbActiveChoices.Size = new System.Drawing.Size(117, 28);
            this.cbActiveChoices.TabIndex = 21;
            this.cbActiveChoices.Visible = false;
            this.cbActiveChoices.SelectedIndexChanged += new System.EventHandler(this.cbActiveChoices_SelectedIndexChanged);
            // 
            // pbAddUser
            // 
            this.pbAddUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddUser.ErrorImage = global::DVLD___Driving_Licenses_Managment.Properties.Resources.local_network;
            this.pbAddUser.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.user_add;
            this.pbAddUser.Location = new System.Drawing.Point(758, 213);
            this.pbAddUser.Name = "pbAddUser";
            this.pbAddUser.Size = new System.Drawing.Size(34, 34);
            this.pbAddUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAddUser.TabIndex = 24;
            this.pbAddUser.TabStop = false;
            this.toolTip1.SetToolTip(this.pbAddUser, "Add User");
            this.pbAddUser.Click += new System.EventHandler(this.pbAddUser_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.cross__2_1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(715, 586);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.user_config;
            this.pictureBox1.Location = new System.Drawing.Point(354, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // FrmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(886, 671);
            this.Controls.Add(this.pbAddUser);
            this.Controls.Add(this.cbActiveChoices);
            this.Controls.Add(this.lblRecordNumber);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvUsersList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.FrmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).EndInit();
            this.cmUserListOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecordNumber;
        private System.Windows.Forms.Label lblRecordsNum;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvUsersList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip cmUserListOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmAddPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmPhoneCall;
        private System.Windows.Forms.ToolStripMenuItem tsmChangePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox cbActiveChoices;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pbAddUser;
    }
}