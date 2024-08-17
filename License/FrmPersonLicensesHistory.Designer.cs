namespace DVLD___Driving_Licenses_Managment.License
{
    partial class FrmPersonLicensesHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cntrlPersonCardWithFilter1 = new DVLD___Driving_Licenses_Managment.cntrlPersonCardWithFilter();
            this.cntrlDriver_sLicensesInfo1 = new DVLD___Driving_Licenses_Managment.Controls.cntrlDriver_sLicensesInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(914, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 38);
            this.label1.TabIndex = 207;
            this.label1.Text = "Driver Licenses History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.gpl;
            this.pictureBox1.Location = new System.Drawing.Point(921, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 208;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.cross__2_1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(997, 865);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 47);
            this.button1.TabIndex = 204;
            this.button1.Text = "   Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cntrlPersonCardWithFilter1
            // 
            this.cntrlPersonCardWithFilter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlPersonCardWithFilter1.FilterEnabeled = true;
            this.cntrlPersonCardWithFilter1.Location = new System.Drawing.Point(13, 9);
            this.cntrlPersonCardWithFilter1.Name = "cntrlPersonCardWithFilter1";
            this.cntrlPersonCardWithFilter1.Size = new System.Drawing.Size(905, 466);
            this.cntrlPersonCardWithFilter1.TabIndex = 209;
            this.cntrlPersonCardWithFilter1.onPersonSelected += new System.EventHandler<DVLD___Driving_Licenses_Managment.cntrlPersonCardWithFilter.PersonEventArgs>(this.cntrlPersonCardWithFilter1_onPersonSelected);
            // 
            // cntrlDriver_sLicensesInfo1
            // 
            this.cntrlDriver_sLicensesInfo1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlDriver_sLicensesInfo1.Location = new System.Drawing.Point(13, 468);
            this.cntrlDriver_sLicensesInfo1.Name = "cntrlDriver_sLicensesInfo1";
            this.cntrlDriver_sLicensesInfo1.Size = new System.Drawing.Size(1118, 394);
            this.cntrlDriver_sLicensesInfo1.TabIndex = 1;
            // 
            // FrmPersonLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1169, 934);
            this.Controls.Add(this.cntrlPersonCardWithFilter1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cntrlDriver_sLicensesInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPersonLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driver Licenses History";
            this.Load += new System.EventHandler(this.FrmPersonLicensesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.cntrlDriver_sLicensesInfo cntrlDriver_sLicensesInfo1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private cntrlPersonCardWithFilter cntrlPersonCardWithFilter1;
    }
}