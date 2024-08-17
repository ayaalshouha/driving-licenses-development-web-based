using DVLD_Buissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Applications.Types
{
    public partial class FrmEditApplicationType : Form
    {
        private clsApplicationTypes type;
        private int type_id = -1;
        public FrmEditApplicationType(int TypeID)
        {
            type_id = TypeID;
            InitializeComponent();
        }

        private void FrmEditApplicationType_Load(object sender, EventArgs e)
        {
            type = clsApplicationTypes.Find(type_id);
            lblID.Text = type_id.ToString();
            txtFee.Text = type.Fees.ToString();
            txtTitle.Text=type.TypeTitle.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _AssignData()
        {
            type.ID = type_id;
            type.TypeTitle = txtTitle.Text;

            if (int.TryParse(txtFee.Text, out int result))
            {
                type.Fees = result;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid yet!, put the mouse over the red icon(s) to see the error(s)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _AssignData();

            if (type.Save())
            {
                MessageBox.Show("Application Type Saved Successfully.", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Something went wrong!!", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            if (!clsGlobal.isNumber(txtFee.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFee, "Invalid Number!"); 
            }
            else
                errorProvider1.SetError(txtFee, null);
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title can't be blank");
            }
            else
                errorProvider1.SetError(txtTitle, null);
        }
    }
}
