using DVLD_Buissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Tests
{
    public partial class FrmUpdateTestType : Form
    {
        private clsTestTypes type;
       private int type_id = 0;

        public FrmUpdateTestType(int TypeID)
        {
            type_id = TypeID;
            InitializeComponent();
        }

        private void FrmUpdateTestType_Load(object sender, EventArgs e)
        {
            type = clsTestTypes.Find(type_id);
            lblID.Text = type_id.ToString();
            txtFee.Text = type.Fees.ToString();
            txtTitle.Text = type.TypeTitle.ToString();
            txtDescription.Text= type.Description.ToString();

        }
        private void AssignData()
        {
            type.ID = (clsTestTypes.enTestType)type_id;
            type.TypeTitle = txtTitle.Text;

            if (int.TryParse(txtFee.Text, out int result))
            {
                type.Fees = result;
            }
            type.Description = txtDescription.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFee.Text) || string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Some data is null please fill it all.", "Message Box",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AssignData();

            if (type.Save())
            {
                MessageBox.Show("Test Type Saved Successfully.", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Something went wrong!!", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                errorProvider1.SetError(txtTitle, "Title can't be blank!");
            }else
                errorProvider1.SetError(txtTitle, null);
        }
    }
}
