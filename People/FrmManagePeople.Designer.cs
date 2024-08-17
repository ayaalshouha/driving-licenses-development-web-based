namespace DVLD___Driving_Licenses_Managment
{
    partial class FrmManagePeople
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
            this.dgvPersonList = new System.Windows.Forms.DataGridView();
            this.cmPeopleListOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAddPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmPersonLicensesHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.lblRecordNumber = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbAddPerson = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonList)).BeginInit();
            this.cmPeopleListOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersonList
            // 
            this.dgvPersonList.AllowUserToAddRows = false;
            this.dgvPersonList.AllowUserToDeleteRows = false;
            this.dgvPersonList.AllowUserToOrderColumns = true;
            this.dgvPersonList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPersonList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPersonList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPersonList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonList.ContextMenuStrip = this.cmPeopleListOptions;
            this.dgvPersonList.Location = new System.Drawing.Point(21, 267);
            this.dgvPersonList.Name = "dgvPersonList";
            this.dgvPersonList.ReadOnly = true;
            this.dgvPersonList.RowHeadersWidth = 50;
            this.dgvPersonList.RowTemplate.Height = 28;
            this.dgvPersonList.Size = new System.Drawing.Size(1234, 316);
            this.dgvPersonList.TabIndex = 0;
            // 
            // cmPeopleListOptions
            // 
            this.cmPeopleListOptions.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmPeopleListOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmPeopleListOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDetails,
            this.toolStripMenuItem1,
            this.tsmAddPerson,
            this.tsmEdit,
            this.tsmDelete,
            this.toolStripMenuItem2,
            this.tsmPersonLicensesHistory});
            this.cmPeopleListOptions.Name = "cmPeopleListOptions";
            this.cmPeopleListOptions.Size = new System.Drawing.Size(295, 209);
            // 
            // tsmShowDetails
            // 
            this.tsmShowDetails.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowDetails.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.tsmShowDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmShowDetails.Name = "tsmShowDetails";
            this.tsmShowDetails.Size = new System.Drawing.Size(294, 32);
            this.tsmShowDetails.Text = "Show Details";
            this.tsmShowDetails.Click += new System.EventHandler(this.tsmShowDetails_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(291, 6);
            // 
            // tsmAddPerson
            // 
            this.tsmAddPerson.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAddPerson.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.add;
            this.tsmAddPerson.Name = "tsmAddPerson";
            this.tsmAddPerson.Size = new System.Drawing.Size(294, 32);
            this.tsmAddPerson.Text = "Add New Person";
            this.tsmAddPerson.Click += new System.EventHandler(this.tsmAddPerson_Click);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.edit;
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(294, 32);
            this.tsmEdit.Text = "Edit Person";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.delete;
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(294, 32);
            this.tsmDelete.Text = "Delete Person";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(291, 6);
            // 
            // tsmPersonLicensesHistory
            // 
            this.tsmPersonLicensesHistory.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.gpl;
            this.tsmPersonLicensesHistory.Name = "tsmPersonLicensesHistory";
            this.tsmPersonLicensesHistory.Size = new System.Drawing.Size(294, 32);
            this.tsmPersonLicensesHistory.Text = "Show Person Licenses History";
            this.tsmPersonLicensesHistory.Click += new System.EventHandler(this.tsmPhoneCall_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(533, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manage People";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 38);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter by:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 20;
            this.comboBox1.Location = new System.Drawing.Point(106, 228);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 28);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(327, 228);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 26);
            this.textBox1.TabIndex = 7;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsNum.Location = new System.Drawing.Point(14, 586);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(123, 38);
            this.lblRecordsNum.TabIndex = 8;
            this.lblRecordsNum.Text = "# Records: ";
            // 
            // lblRecordNumber
            // 
            this.lblRecordNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordNumber.AutoSize = true;
            this.lblRecordNumber.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordNumber.ForeColor = System.Drawing.Color.Black;
            this.lblRecordNumber.Location = new System.Drawing.Point(122, 586);
            this.lblRecordNumber.Name = "lblRecordNumber";
            this.lblRecordNumber.Size = new System.Drawing.Size(87, 38);
            this.lblRecordNumber.TabIndex = 9;
            this.lblRecordNumber.Text = "Number";
            // 
            // pbAddPerson
            // 
            this.pbAddPerson.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbAddPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddPerson.ErrorImage = global::DVLD___Driving_Licenses_Managment.Properties.Resources.local_network;
            this.pbAddPerson.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.user_add;
            this.pbAddPerson.Location = new System.Drawing.Point(1192, 207);
            this.pbAddPerson.Name = "pbAddPerson";
            this.pbAddPerson.Size = new System.Drawing.Size(34, 34);
            this.pbAddPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAddPerson.TabIndex = 25;
            this.pbAddPerson.TabStop = false;
            this.toolTip1.SetToolTip(this.pbAddPerson, "Add");
            this.pbAddPerson.Click += new System.EventHandler(this.pbAddUser_Click);
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
            this.btnClose.Location = new System.Drawing.Point(1155, 598);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.group__2_;
            this.pictureBox1.Location = new System.Drawing.Point(557, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1292, 670);
            this.Controls.Add(this.pbAddPerson);
            this.Controls.Add(this.lblRecordNumber);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPersonList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.FrmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonList)).EndInit();
            this.cmPeopleListOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPersonList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblRecordsNum;
        private System.Windows.Forms.Label lblRecordNumber;
        private System.Windows.Forms.ContextMenuStrip cmPeopleListOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmAddPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmPersonLicensesHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbAddPerson;
    }
}