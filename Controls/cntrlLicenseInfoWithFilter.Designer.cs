namespace DVLD___Driving_Licenses_Managment.Controls
{
    partial class cntrlLicenseInfoWithFilter
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
            this.gbFilterBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cntrlLicenseInfo1 = new DVLD___Driving_Licenses_Managment.Controls.cntrlLicenseInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilterBox
            // 
            this.gbFilterBox.Controls.Add(this.label1);
            this.gbFilterBox.Controls.Add(this.btnFind);
            this.gbFilterBox.Controls.Add(this.txtInput);
            this.gbFilterBox.Location = new System.Drawing.Point(3, 3);
            this.gbFilterBox.Name = "gbFilterBox";
            this.gbFilterBox.Size = new System.Drawing.Size(878, 74);
            this.gbFilterBox.TabIndex = 8;
            this.gbFilterBox.TabStop = false;
            this.gbFilterBox.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "License ID:";
            // 
            // btnFind
            // 
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.binoculars__2_;
            this.btnFind.Location = new System.Drawing.Point(374, 20);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(52, 48);
            this.btnFind.TabIndex = 6;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(118, 34);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(223, 28);
            this.txtInput.TabIndex = 5;
            this.txtInput.Validating += new System.ComponentModel.CancelEventHandler(this.txtInput_Validating);
            // 
            // cntrlLicenseInfo1
            // 
            this.cntrlLicenseInfo1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlLicenseInfo1.Location = new System.Drawing.Point(3, 83);
            this.cntrlLicenseInfo1.Name = "cntrlLicenseInfo1";
            this.cntrlLicenseInfo1.Size = new System.Drawing.Size(886, 474);
            this.cntrlLicenseInfo1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cntrlLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.gbFilterBox);
            this.Controls.Add(this.cntrlLicenseInfo1);
            this.Name = "cntrlLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(898, 558);
            this.Load += new System.EventHandler(this.cntrlLicenseInfoWithFilter_Load);
            this.gbFilterBox.ResumeLayout(false);
            this.gbFilterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private cntrlLicenseInfo cntrlLicenseInfo1;
        private System.Windows.Forms.GroupBox gbFilterBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
