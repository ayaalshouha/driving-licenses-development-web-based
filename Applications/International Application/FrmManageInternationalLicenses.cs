using DVLD___Driving_Licenses_Managment.License;
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

namespace DVLD___Driving_Licenses_Managment.Applications.International_Application
{
    public partial class FrmManageInternationalLicenses : Form
    {

        public FrmManageInternationalLicenses()
        {
            InitializeComponent();
        }

        private void pbAddNewApplication_Click(object sender, EventArgs e)
        {
            FrmInternationalApplication form = new FrmInternationalApplication();
            form.ShowDialog();
            _RefreshTable(); 

        }

        private void _RefreshTable()
        {
            dgvInternationalApplicationsList.DataSource = clsInternational_DL.List();
            lblRecordNumber.Text = dgvInternationalApplicationsList.RowCount.ToString();
        }

        private void FrmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            dgvInternationalApplicationsList.DataSource = clsInternational_DL.List();
            lblRecordNumber.Text = dgvInternationalApplicationsList.RowCount.ToString();

            comboBox1.Items.Add("None");
            comboBox1.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvInternationalApplicationsList.Columns)
            {
                if (column.HeaderText == "CreatedByUserID" || column.HeaderText == "IssueDate" || column.HeaderText == "ExpirationDate" || column.HeaderText == "isActive")
                {
                    continue;
                }
                comboBox1.Items.Add(column.HeaderText);
            }

            if (dgvInternationalApplicationsList.Rows.Count > 0)
            {
                dgvInternationalApplicationsList.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalApplicationsList.Columns[1].HeaderText = "Application ID";
                dgvInternationalApplicationsList.Columns[2].HeaderText = "Driver ID";
                dgvInternationalApplicationsList.Columns[3].HeaderText = "L.License ID";
                dgvInternationalApplicationsList.Columns[4].HeaderText = "Issue Date";
                dgvInternationalApplicationsList.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalApplicationsList.Columns[6].HeaderText = "Is Active";
                dgvInternationalApplicationsList.Columns[7].HeaderText = "UserID";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "None")
            {
                textBox1.Visible = false;
                dgvInternationalApplicationsList.DataSource = clsInternational_DL.List();
                return;
            }

            textBox1.Visible = true;
            textBox1.Focus();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable OriginalList = clsInternational_DL.List();
            string filter = textBox1.Text;
            string selectedColumnName = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(filter) || selectedColumnName == "None")
            {
                dgvInternationalApplicationsList.DataSource = OriginalList;
                return;
            }

            if (OriginalList.Columns[selectedColumnName].DataType == typeof(Int32))
            {
                
                DataView View1 = OriginalList.DefaultView;
                View1.RowFilter = $"{selectedColumnName}='{filter}'";
                dgvInternationalApplicationsList.DataSource = View1;
            }
            else
            {
                DataView View1 = OriginalList.DefaultView;
                View1.RowFilter = $"{selectedColumnName} LIKE '%{filter}%'";
                dgvInternationalApplicationsList.DataSource = View1;
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[2].Value;
            int PersonID = clsDrviers.Find(DriverID).PersonID;
            FrmShowPersonCard form = new FrmShowPersonCard(PersonID); 
            form.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value;
            FrmShowInternationalLicenseInfo form = new FrmShowInternationalLicenseInfo(InternationalLicenseID);
            form.ShowDialog();
        }

        private void showPersonHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[2].Value;
            int PersonID = clsDrviers.Find(DriverID).PersonID; 
            FrmPersonLicensesHistory form = new FrmPersonLicensesHistory(PersonID); 
            form.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
