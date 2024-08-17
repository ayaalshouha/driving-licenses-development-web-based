using DVLD___Driving_Licenses_Managment.License;
using DVLD_Buissness;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Drivers
{
    public partial class FrmManageDrivers : Form
    {
        public FrmManageDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageDrivers_Load(object sender, EventArgs e)
        {
            dgvDriversList.DataSource = clsDrviers.DriversList();
            lblRecordNumber.Text = dgvDriversList.RowCount.ToString();

            comboBox1.Items.Add("None");
            comboBox1.SelectedItem = "None";
            foreach (DataGridViewColumn column in dgvDriversList.Columns)
            {
                if (column.HeaderText == "Date" || column.HeaderText == "ActiveLicenses")
                {
                    continue;
                }
                comboBox1.Items.Add(column.HeaderText);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable OriginalList = clsDrviers.DriversList();
            string filter = textBox1.Text;
            string selectedColumnName = comboBox1.SelectedItem.ToString();

            if (OriginalList.Columns[selectedColumnName].DataType == typeof(Int32))
            {
                if (int.TryParse(textBox1.Text, out int number))
                {
                    DataView View1 = OriginalList.DefaultView;
                    View1.RowFilter = $"{selectedColumnName}='{filter}'";
                    dgvDriversList.DataSource = View1;
                }
            }
            else
            {
                DataView View1 = OriginalList.DefaultView;
                View1.RowFilter = $"{selectedColumnName} LIKE '%{filter}%'";
                dgvDriversList.DataSource = View1;
            }

            if (string.IsNullOrEmpty(filter) || selectedColumnName == "None")
            {
                dgvDriversList.DataSource = OriginalList;

                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "None")
            {
                textBox1.Visible = true;
                textBox1.Focus();
            }
            else
            {
                textBox1.Visible = false;
                dgvDriversList.DataSource = clsDrviers.DriversList();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == "ID" || textBox1.Text == "PersonID" || textBox1.Text == "NationalID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); 
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void driverLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvDriversList.CurrentRow.Cells[1].Value;
            FrmPersonLicensesHistory form = new FrmPersonLicensesHistory(personID); 
            form.ShowDialog();
        }
    }
}
 