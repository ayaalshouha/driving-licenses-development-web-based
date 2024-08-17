namespace DVLD___Driving_Licenses_Managment
{
    partial class FrmChangePassword
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
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.lblCurrentPass = new System.Windows.Forms.Label();
            this.lblNewpass = new System.Windows.Forms.Label();
            this.lblCheckpass = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cntrUserCard1 = new DVLD___Driving_Licenses_Managment.cntrUserCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(291, 490);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.PasswordChar = '*';
            this.txtCurrent.Size = new System.Drawing.Size(168, 26);
            this.txtCurrent.TabIndex = 0;
            this.txtCurrent.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrent_Validating);
            // 
            // txtCheck
            // 
            this.txtCheck.Location = new System.Drawing.Point(291, 600);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.PasswordChar = '*';
            this.txtCheck.Size = new System.Drawing.Size(168, 26);
            this.txtCheck.TabIndex = 2;
            this.txtCheck.Validating += new System.ComponentModel.CancelEventHandler(this.txtCheck_Validating);
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(291, 545);
            this.txtNew.Name = "txtNew";
            this.txtNew.PasswordChar = '*';
            this.txtNew.Size = new System.Drawing.Size(168, 26);
            this.txtNew.TabIndex = 3;
            this.txtNew.Validating += new System.ComponentModel.CancelEventHandler(this.txtNew_Validating);
            // 
            // lblCurrentPass
            // 
            this.lblCurrentPass.AutoSize = true;
            this.lblCurrentPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPass.Location = new System.Drawing.Point(98, 490);
            this.lblCurrentPass.Name = "lblCurrentPass";
            this.lblCurrentPass.Size = new System.Drawing.Size(155, 20);
            this.lblCurrentPass.TabIndex = 4;
            this.lblCurrentPass.Text = "Current password:";
            // 
            // lblNewpass
            // 
            this.lblNewpass.AutoSize = true;
            this.lblNewpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewpass.Location = new System.Drawing.Point(98, 545);
            this.lblNewpass.Name = "lblNewpass";
            this.lblNewpass.Size = new System.Drawing.Size(129, 20);
            this.lblNewpass.TabIndex = 5;
            this.lblNewpass.Text = "New password:";
            // 
            // lblCheckpass
            // 
            this.lblCheckpass.AutoSize = true;
            this.lblCheckpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckpass.Location = new System.Drawing.Point(98, 600);
            this.lblCheckpass.Name = "lblCheckpass";
            this.lblCheckpass.Size = new System.Drawing.Size(157, 20);
            this.lblCheckpass.TabIndex = 6;
            this.lblCheckpass.Text = "Confirm password:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.key__3_;
            this.pictureBox3.Location = new System.Drawing.Point(35, 478);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 37);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.key__4_;
            this.pictureBox2.Location = new System.Drawing.Point(35, 533);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 37);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.key__3_;
            this.pictureBox1.Location = new System.Drawing.Point(35, 588);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 37);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // cntrUserCard1
            // 
            this.cntrUserCard1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrUserCard1.Location = new System.Drawing.Point(12, 9);
            this.cntrUserCard1.Name = "cntrUserCard1";
            this.cntrUserCard1.Size = new System.Drawing.Size(890, 464);
            this.cntrUserCard1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.cross__2_1;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(687, 627);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.diskette__2_;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(802, 627);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 37);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "    Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(31, 637);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "NOTES";
            this.label1.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(931, 678);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCheckpass);
            this.Controls.Add(this.lblNewpass);
            this.Controls.Add(this.lblCurrentPass);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.cntrUserCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password Form";
            this.Load += new System.EventHandler(this.FrmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cntrUserCard cntrUserCard1;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label lblCurrentPass;
        private System.Windows.Forms.Label lblNewpass;
        private System.Windows.Forms.Label lblCheckpass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}