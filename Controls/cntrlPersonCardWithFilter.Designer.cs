namespace DVLD___Driving_Licenses_Managment
{
    partial class cntrlPersonCardWithFilter
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbFindby = new System.Windows.Forms.ComboBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFind = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.gbFilterBox = new System.Windows.Forms.GroupBox();
            this.cntrPersonCard1 = new DVLD___Driving_Licenses_Managment.cntrPersonCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find by:";
            // 
            // cbFindby
            // 
            this.cbFindby.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbFindby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindby.FormattingEnabled = true;
            this.cbFindby.Items.AddRange(new object[] {
            "NationalNo",
            "PersonID"});
            this.cbFindby.Location = new System.Drawing.Point(84, 32);
            this.cbFindby.Name = "cbFindby";
            this.cbFindby.Size = new System.Drawing.Size(223, 28);
            this.cbFindby.Sorted = true;
            this.cbFindby.TabIndex = 4;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(313, 32);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(223, 28);
            this.txtInput.TabIndex = 5;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // btnFind
            // 
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.administrator__6_;
            this.btnFind.Location = new System.Drawing.Point(554, 20);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(52, 48);
            this.btnFind.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnFind, "Find Perosn");
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Image = global::DVLD___Driving_Licenses_Managment.Properties.Resources.administrator__2_;
            this.btnAddPerson.Location = new System.Drawing.Point(610, 20);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(52, 48);
            this.btnAddPerson.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnAddPerson, "Add New Person");
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // gbFilterBox
            // 
            this.gbFilterBox.Controls.Add(this.btnAddPerson);
            this.gbFilterBox.Controls.Add(this.label1);
            this.gbFilterBox.Controls.Add(this.btnFind);
            this.gbFilterBox.Controls.Add(this.cbFindby);
            this.gbFilterBox.Controls.Add(this.txtInput);
            this.gbFilterBox.Location = new System.Drawing.Point(3, 3);
            this.gbFilterBox.Name = "gbFilterBox";
            this.gbFilterBox.Size = new System.Drawing.Size(878, 74);
            this.gbFilterBox.TabIndex = 7;
            this.gbFilterBox.TabStop = false;
            this.gbFilterBox.Text = "Filter";
            // 
            // cntrPersonCard1
            // 
            this.cntrPersonCard1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cntrPersonCard1.Location = new System.Drawing.Point(3, 88);
            this.cntrPersonCard1.Name = "cntrPersonCard1";
            this.cntrPersonCard1.Size = new System.Drawing.Size(878, 372);
            this.cntrPersonCard1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cntrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.gbFilterBox);
            this.Controls.Add(this.cntrPersonCard1);
            this.Name = "cntrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(890, 449);
            this.Load += new System.EventHandler(this.cntrlPersonCardWithFilter_Load);
            this.gbFilterBox.ResumeLayout(false);
            this.gbFilterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private cntrPersonCard cntrPersonCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFindby;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox gbFilterBox;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
