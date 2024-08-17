using DVLD_Buissness;
using System;
using System.Windows.Forms;
using DVLD___Driving_Licenses_Managment.Forms;
using System.Data;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class FrmManageUsers : Form
    {
        public FrmManageUsers()
        {
            InitializeComponent();
        }

        private void _UpdateList()
        {
            dgvUsersList.DataSource = clsUser.UsersList();
            lblRecordNumber.Text = dgvUsersList.RowCount.ToString();
        }

        private void FrmManageUsers_Load(object sender, EventArgs e)
        {
            _UpdateList();
            comboBox1.Items.Add("None");
            comboBox1.SelectedIndex = 0;
            foreach (DataGridViewColumn column_name in dgvUsersList.Columns)
            {
                comboBox1.Items.Add(column_name.HeaderText);
            }
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            FrmShowUserCard Form = new FrmShowUserCard((int)dgvUsersList.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            _UpdateList(); 
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            FrmAddEditUser Form = new FrmAddEditUser((int)dgvUsersList.CurrentRow.Cells[0].Value); 
            Form.ShowDialog();
            _UpdateList();
        }

        private void tsmAddPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditUser Form = new FrmAddEditUser(-1);
            Form.ShowDialog();
            _UpdateList();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show($"Are you sure you want to delete User ID: {Convert.ToInt32(dgvUsersList.CurrentRow.Cells[0].Value)} ? "
                , "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.Delete((int)dgvUsersList.CurrentRow.Cells[0].Value))
                    _UpdateList();
                else
                    MessageBox.Show($"Something went wrong, try again. ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show($"Deletion canceled", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            FrmChangePassword Form = new FrmChangePassword((int)dgvUsersList.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox1.Text;
            string selectedColumnName = comboBox1.SelectedItem.ToString();
            DataTable OriginalList = clsUser.UsersList();

            if(string.IsNullOrWhiteSpace(filter) || selectedColumnName == "None")
            {
                dgvUsersList.DataSource = OriginalList;
                return; 
            }

            if (OriginalList.Columns[selectedColumnName].DataType == typeof(Int32))
            {
                    DataView View1 = OriginalList.DefaultView;
                    View1.RowFilter = $"{selectedColumnName}='{filter}'";
                    dgvUsersList.DataSource = View1;
            }
            else
            {
                DataView View1 = OriginalList.DefaultView;
                View1.RowFilter = $"{selectedColumnName} LIKE '%{filter}%'";
                dgvUsersList.DataSource = View1;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(comboBox1.Text == "None")
            {
                textBox1.Visible = false;
                cbActiveChoices.Visible = false;
                dgvUsersList.DataSource = clsUser.UsersList();
            }
            else if (comboBox1.Text == "isActive")
            {
                textBox1.Visible = false; 
                cbActiveChoices.Visible = true;
                cbActiveChoices.SelectedIndex = 0;
            }
            else
            {
                textBox1.Visible = true;
                cbActiveChoices.Visible = false;
                textBox1.Focus();
            }
        }
        private void cbActiveChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbActiveChoices.SelectedIndex)
            {
                case 0:

                    dgvUsersList.DataSource = clsUser.UsersList();
                    lblRecordNumber.Text = dgvUsersList.RowCount.ToString();

                    break;
                case 1:
                    dgvUsersList.DataSource = clsUser.ActiveUsersList();
                    lblRecordNumber.Text = dgvUsersList.RowCount.ToString();

                    break;
                case 2:
                    dgvUsersList.DataSource = clsUser.NonActiveUsersList();
                    lblRecordNumber.Text = dgvUsersList.RowCount.ToString();

                    break;
            }
        }
        private void pbAddUser_Click(object sender, EventArgs e)
        {
            FrmAddEditUser Form = new FrmAddEditUser(-1);
            Form.ShowDialog();
            _UpdateList();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //prevent user from entering a letters when filtering a numerous values 
            if (comboBox1.Text == "PersonID" || comboBox1.Text == "ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
