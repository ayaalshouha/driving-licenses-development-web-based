namespace DVLD___Driving_Licenses_Managment.Tests
{
    partial class FrmScheduleTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.cntrlScheduleTest1 = new DVLD___Driving_Licenses_Managment.Controls.cntrlScheduleTest();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.cross__2_1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(328, 711);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 24;
            this.button1.Text = "   Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cntrlScheduleTest1
            // 
            this.cntrlScheduleTest1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrlScheduleTest1.Location = new System.Drawing.Point(8, 12);
            this.cntrlScheduleTest1.Name = "cntrlScheduleTest1";
            this.cntrlScheduleTest1.Size = new System.Drawing.Size(468, 699);
            this.cntrlScheduleTest1.TabIndex = 0;
            this.cntrlScheduleTest1.TestTypeID = DVLD_Buissness.clsTestTypes.enTestType.VisionTest;
            this.cntrlScheduleTest1.Load += new System.EventHandler(this.cntrlScheduleTest1_Load);
            // 
            // FrmScheduleTest
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(488, 760);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cntrlScheduleTest1);
            this.Name = "FrmScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.FrmScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.cntrlScheduleTest cntrlScheduleTest1;
        private System.Windows.Forms.Button button1;
    }
}