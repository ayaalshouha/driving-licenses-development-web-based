namespace DVLD___Driving_Licenses_Managment.Controls
{
    partial class cntrlDriver_sLicensesInfo
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbLocalLicenses = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblLocalRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalHistory = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblInternationalRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInternationalHistory = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tbLocalLicenses.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalHistory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalHistory)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLocalLicenses);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1105, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tbLocalLicenses
            // 
            this.tbLocalLicenses.Controls.Add(this.tabPage1);
            this.tbLocalLicenses.Controls.Add(this.tabPage2);
            this.tbLocalLicenses.Location = new System.Drawing.Point(6, 27);
            this.tbLocalLicenses.Name = "tbLocalLicenses";
            this.tbLocalLicenses.SelectedIndex = 0;
            this.tbLocalLicenses.Size = new System.Drawing.Size(1082, 330);
            this.tbLocalLicenses.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblLocalRecords);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvLocalHistory);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1074, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblLocalRecords
            // 
            this.lblLocalRecords.AutoSize = true;
            this.lblLocalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalRecords.Location = new System.Drawing.Point(140, 255);
            this.lblLocalRecords.Name = "lblLocalRecords";
            this.lblLocalRecords.Size = new System.Drawing.Size(66, 22);
            this.lblLocalRecords.TabIndex = 6;
            this.lblLocalRecords.Text = "[????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Records: ";
            // 
            // dgvLocalHistory
            // 
            this.dgvLocalHistory.AllowUserToAddRows = false;
            this.dgvLocalHistory.AllowUserToDeleteRows = false;
            this.dgvLocalHistory.AllowUserToResizeColumns = false;
            this.dgvLocalHistory.AllowUserToResizeRows = false;
            this.dgvLocalHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLocalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalHistory.Location = new System.Drawing.Point(25, 44);
            this.dgvLocalHistory.Name = "dgvLocalHistory";
            this.dgvLocalHistory.ReadOnly = true;
            this.dgvLocalHistory.RowHeadersWidth = 62;
            this.dgvLocalHistory.RowTemplate.Height = 28;
            this.dgvLocalHistory.Size = new System.Drawing.Size(1033, 208);
            this.dgvLocalHistory.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(235, 36);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(234, 32);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Licenses History:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblInternationalRecords);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dgvInternationalHistory);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1074, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblInternationalRecords
            // 
            this.lblInternationalRecords.AutoSize = true;
            this.lblInternationalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalRecords.Location = new System.Drawing.Point(138, 255);
            this.lblInternationalRecords.Name = "lblInternationalRecords";
            this.lblInternationalRecords.Size = new System.Drawing.Size(66, 22);
            this.lblInternationalRecords.TabIndex = 6;
            this.lblInternationalRecords.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "# Records: ";
            // 
            // dgvInternationalHistory
            // 
            this.dgvInternationalHistory.AllowUserToAddRows = false;
            this.dgvInternationalHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalHistory.AllowUserToOrderColumns = true;
            this.dgvInternationalHistory.AllowUserToResizeColumns = false;
            this.dgvInternationalHistory.AllowUserToResizeRows = false;
            this.dgvInternationalHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInternationalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalHistory.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvInternationalHistory.Location = new System.Drawing.Point(23, 44);
            this.dgvInternationalHistory.Name = "dgvInternationalHistory";
            this.dgvInternationalHistory.ReadOnly = true;
            this.dgvInternationalHistory.RowHeadersWidth = 62;
            this.dgvInternationalHistory.RowTemplate.Height = 28;
            this.dgvInternationalHistory.Size = new System.Drawing.Size(1033, 208);
            this.dgvInternationalHistory.TabIndex = 4;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(235, 36);
            // 
            // showLicenseInfoToolStripMenuItem1
            // 
            this.showLicenseInfoToolStripMenuItem1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.preview;
            this.showLicenseInfoToolStripMenuItem1.Name = "showLicenseInfoToolStripMenuItem1";
            this.showLicenseInfoToolStripMenuItem1.Size = new System.Drawing.Size(234, 32);
            this.showLicenseInfoToolStripMenuItem1.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "International Licenses History:";
            // 
            // cntrlDriver_sLicensesInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Name = "cntrlDriver_sLicensesInfo";
            this.Size = new System.Drawing.Size(1118, 394);
            //this.Load += new System.EventHandler(this.cntrlDriver_sLicensesInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.tbLocalLicenses.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalHistory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalHistory)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tbLocalLicenses;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocalRecords;
        private System.Windows.Forms.Label lblInternationalRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInternationalHistory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem1;
    }
}
