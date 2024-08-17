namespace DVLD___Driving_Licenses_Managment.Applications.International_Application
{
    partial class FrmManageInternationalLicenses
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmsApplicationOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordNumber = new System.Windows.Forms.Label();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalApplicationsList = new System.Windows.Forms.DataGridView();
            this.pbAddNewApplication = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmsApplicationOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalApplicationsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(334, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(551, 54);
            this.label1.TabIndex = 25;
            this.label1.Text = "International Driving License Applications";
            // 
            // cmsApplicationOptions
            // 
            this.cmsApplicationOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsApplicationOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonHistoryToolStripMenuItem});
            this.cmsApplicationOptions.Name = "contextMenuStrip1";
            this.cmsApplicationOptions.Size = new System.Drawing.Size(326, 100);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(325, 32);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.flooding;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(325, 32);
            this.showLicenseToolStripMenuItem.Text = "Show License Details";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonHistoryToolStripMenuItem
            // 
            this.showPersonHistoryToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.isdn;
            this.showPersonHistoryToolStripMenuItem.Name = "showPersonHistoryToolStripMenuItem";
            this.showPersonHistoryToolStripMenuItem.Size = new System.Drawing.Size(325, 32);
            this.showPersonHistoryToolStripMenuItem.Text = "Show Person Licenses History";
            this.showPersonHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonHistoryToolStripMenuItem_Click);
            // 
            // lblRecordNumber
            // 
            this.lblRecordNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordNumber.AutoSize = true;
            this.lblRecordNumber.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordNumber.ForeColor = System.Drawing.Color.Black;
            this.lblRecordNumber.Location = new System.Drawing.Point(130, 593);
            this.lblRecordNumber.Name = "lblRecordNumber";
            this.lblRecordNumber.Size = new System.Drawing.Size(87, 38);
            this.lblRecordNumber.TabIndex = 31;
            this.lblRecordNumber.Text = "Number";
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsNum.Location = new System.Drawing.Point(22, 593);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(123, 38);
            this.lblRecordsNum.TabIndex = 30;
            this.lblRecordsNum.Text = "# Records: ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(357, 235);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 26);
            this.textBox1.TabIndex = 29;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 20;
            this.comboBox1.Location = new System.Drawing.Point(126, 235);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 28);
            this.comboBox1.TabIndex = 28;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(22, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 38);
            this.label2.TabIndex = 27;
            this.label2.Text = "Filter by:";
            // 
            // dgvInternationalApplicationsList
            // 
            this.dgvInternationalApplicationsList.AllowUserToAddRows = false;
            this.dgvInternationalApplicationsList.AllowUserToDeleteRows = false;
            this.dgvInternationalApplicationsList.AllowUserToOrderColumns = true;
            this.dgvInternationalApplicationsList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvInternationalApplicationsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInternationalApplicationsList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInternationalApplicationsList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvInternationalApplicationsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalApplicationsList.ContextMenuStrip = this.cmsApplicationOptions;
            this.dgvInternationalApplicationsList.Location = new System.Drawing.Point(29, 274);
            this.dgvInternationalApplicationsList.Name = "dgvInternationalApplicationsList";
            this.dgvInternationalApplicationsList.ReadOnly = true;
            this.dgvInternationalApplicationsList.RowHeadersWidth = 50;
            this.dgvInternationalApplicationsList.RowTemplate.Height = 28;
            this.dgvInternationalApplicationsList.Size = new System.Drawing.Size(1167, 316);
            this.dgvInternationalApplicationsList.TabIndex = 24;
            // 
            // pbAddNewApplication
            // 
            this.pbAddNewApplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAddNewApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddNewApplication.ErrorImage = global::DVLD___Driving_Licenses_Managment.Properties.Resources.local_network;
            this.pbAddNewApplication.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.horizontal_line;
            this.pbAddNewApplication.Location = new System.Drawing.Point(1094, 215);
            this.pbAddNewApplication.Name = "pbAddNewApplication";
            this.pbAddNewApplication.Size = new System.Drawing.Size(34, 34);
            this.pbAddNewApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAddNewApplication.TabIndex = 35;
            this.pbAddNewApplication.TabStop = false;
            this.toolTip1.SetToolTip(this.pbAddNewApplication, "Add");
            this.pbAddNewApplication.Click += new System.EventHandler(this.pbAddNewApplication_Click);
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
            this.btnClose.Location = new System.Drawing.Point(1096, 607);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.compare_documents__1_;
            this.pictureBox1.Location = new System.Drawing.Point(520, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = global::DVLD___Driving_Licenses_Managment.Properties.Resources.local_network;
            this.pictureBox2.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.world;
            this.pictureBox2.Location = new System.Drawing.Point(895, 168);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // FrmManageInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1219, 662);
            this.Controls.Add(this.pbAddNewApplication);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecordNumber);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvInternationalApplicationsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmManageInternationalLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International Licenses";
            this.Load += new System.EventHandler(this.FrmManageInternationalLicenses_Load);
            this.cmsApplicationOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalApplicationsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAddNewApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem showPersonHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsApplicationOptions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRecordNumber;
        private System.Windows.Forms.Label lblRecordsNum;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInternationalApplicationsList;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}