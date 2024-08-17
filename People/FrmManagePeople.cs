using DVLD___Driving_Licenses_Managment.License;
using DVLD_Buissness;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class FrmManagePeople : Form
    {
        public FrmManagePeople()
        {
            InitializeComponent();
        }

        private void _UpdateList ()
        {
            dgvPersonList.DataSource = clsPerson.PeopleList();
            lblRecordNumber.Text = dgvPersonList.RowCount.ToString();
        }

        private void FrmManagePeople_Load(object sender, EventArgs e)
        {
            dgvPersonList.DataSource = clsPerson.PeopleList();
            lblRecordNumber.Text = dgvPersonList.RowCount.ToString();

            comboBox1.Items.Add("None");
            comboBox1.SelectedItem = "None";
            foreach (DataGridViewColumn column in dgvPersonList.Columns)
            {
                if(column.HeaderText == "Birthdate")
                {
                    continue;
                }
                comboBox1.Items.Add(column.HeaderText);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            FrmShowPersonCard Form = new FrmShowPersonCard((int)dgvPersonList.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            _UpdateList();
        }

        private void tsmAddPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson Form = new FrmAddEditPerson();
            Form.ShowDialog();
            _UpdateList();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson Form = new FrmAddEditPerson((int)dgvPersonList.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            _UpdateList();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete person ID: {Convert.ToInt32(dgvPersonList.CurrentRow.Cells[0].Value)} ? "
                ,"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPerson.Delete((int)dgvPersonList.CurrentRow.Cells[0].Value))
                    _UpdateList();
                else
                    MessageBox.Show($"Persons info is associated with another data in the system. ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else
                MessageBox.Show($"Deletion canceled", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable OriginalList = clsPerson.PeopleList();
            string filter = textBox1.Text;
            string selectedColumnName = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(filter) || selectedColumnName == "None")
            {
                dgvPersonList.DataSource = OriginalList;
                return;
            }

            if (OriginalList.Columns[selectedColumnName].DataType == typeof(Int32))
            {
                DataView View1 = OriginalList.DefaultView;
                View1.RowFilter = $"{selectedColumnName}='{filter}'";
                dgvPersonList.DataSource = View1;
            }
            else
            {
                DataView View1 = OriginalList.DefaultView;
                View1.RowFilter = $"{selectedColumnName} LIKE '%{filter}%'";
                dgvPersonList.DataSource = View1;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text != "None")
            {
                textBox1.Visible = true; 
                textBox1.Focus();
            }
            else
            {
                textBox1.Visible = false;
                dgvPersonList.DataSource = clsPerson.PeopleList();
            }
        }
        private void pbAddUser_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson Form = new FrmAddEditPerson();
            Form.ShowDialog();
            _UpdateList();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(comboBox1.Text == "ID" || comboBox1.Text == "NationalID" || comboBox1.Text == "PhoneNumber")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tsmPhoneCall_Click(object sender, EventArgs e)
        {
            //porson licenses history 
            FrmPersonLicensesHistory form = new FrmPersonLicensesHistory((int)dgvPersonList.CurrentRow.Cells[0].Value);
            form.ShowDialog();
        }
    }
}
