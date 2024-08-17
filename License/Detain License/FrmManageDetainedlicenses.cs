using DVLD___Driving_Licenses_Managment.Applications.Detain_License;
using DVLD___Driving_Licenses_Managment.Applications.Release_DetainedLicense;
using DVLD_Buissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.License.Detain_License
{
    public partial class FrmManageDetainedlicenses : Form
    {
        public FrmManageDetainedlicenses()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            dgvDetainLincesesList.DataSource = clsDetainedLicenses.List();
            lblRecordNumber.Text = dgvDetainLincesesList.RowCount.ToString();

            if (dgvDetainLincesesList.RowCount > 0)
            {
                dgvDetainLincesesList.Columns[0].HeaderText = "D.ID";
                dgvDetainLincesesList.Columns[1].HeaderText = "L.ID";
                dgvDetainLincesesList.Columns[2].HeaderText = "D.Date";
                dgvDetainLincesesList.Columns[3].HeaderText = "isReleased";
                dgvDetainLincesesList.Columns[4].HeaderText = "FineFees";
                dgvDetainLincesesList.Columns[5].HeaderText = "ReleaseDate";
                dgvDetainLincesesList.Columns[6].HeaderText = "NationalID";
                dgvDetainLincesesList.Columns[7].HeaderText = "FullName";
                dgvDetainLincesesList.Columns[8].HeaderText = "ReleaseAppID";
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbDetainLicense_Click(object sender, EventArgs e)
        {
            FrmDetainLicenseApplication from = new FrmDetainLicenseApplication();
            from.ShowDialog();
        }

        private void FrmManageDetainedlicenses_Load(object sender, EventArgs e)
        {
            dgvDetainLincesesList.DataSource = clsDetainedLicenses.List();
            lblRecordNumber.Text = dgvDetainLincesesList.RowCount.ToString();

            if(dgvDetainLincesesList.RowCount > 0)
            {
                dgvDetainLincesesList.Columns[0].HeaderText = "D.ID";
                dgvDetainLincesesList.Columns[1].HeaderText = "L.ID";
                dgvDetainLincesesList.Columns[2].HeaderText = "D.Date";
                dgvDetainLincesesList.Columns[3].HeaderText = "isReleased";
                dgvDetainLincesesList.Columns[4].HeaderText = "FineFees";
                dgvDetainLincesesList.Columns[5].HeaderText = "ReleaseDate";
                dgvDetainLincesesList.Columns[6].HeaderText = "NationalID";
                dgvDetainLincesesList.Columns[7].HeaderText = "FullName";
                dgvDetainLincesesList.Columns[8].HeaderText = "ReleaseAppID";
            }

            comboBox1.Items.Add("None");
            comboBox1.SelectedIndex = 0; 

            foreach (DataGridViewColumn column in dgvDetainLincesesList.Columns)
            {
                if (column.HeaderText == "ReleaseDate" || column.HeaderText == "D.Date" || column.HeaderText == "isReleased")
                    continue; 


                comboBox1.Items.Add(column.HeaderText);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "None")
            {
                textBox1.Visible = false;
                dgvDetainLincesesList.DataSource = clsDetainedLicenses.List();
                return;
            }

            textBox1.Visible = true;
        }

        private void pbReleaseLicense_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainedLicense form = new FrmReleaseDetainedLicense();
            form.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLincesesList.CurrentRow.Cells[1].Value;
            int PersonID = clsLicenses.Find(LicenseID).DriverInfo.PersonID; 

            FrmShowPersonCard form = new FrmShowPersonCard(PersonID); 
            form.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLincesesList.CurrentRow.Cells[1].Value;
            FrmShowLicenseInfo form = new FrmShowLicenseInfo(LicenseID); 
            form.ShowDialog();
        }

        private void showPersonHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLincesesList.CurrentRow.Cells[1].Value;
            int PersonID = clsLicenses.Find(LicenseID).DriverInfo.PersonID;

            FrmPersonLicensesHistory form = new FrmPersonLicensesHistory(PersonID);
            form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable OriginalList = clsDetainedLicenses.List();
            string filter = textBox1.Text;
            string selectedColumnName = comboBox1.SelectedItem.ToString();

            if (OriginalList.Columns[selectedColumnName].DataType == typeof(Int32))
            {
                if (int.TryParse(textBox1.Text, out int number))
                {
                    DataView View1 = OriginalList.DefaultView;
                    View1.RowFilter = $"{selectedColumnName}='{filter}'";
                    dgvDetainLincesesList.DataSource = View1;
                }
                else
                {
                    textBox1.Clear();
                    return;
                }
            }
            else
            {
                DataView View1 = OriginalList.DefaultView;
                View1.RowFilter = $"{selectedColumnName} LIKE '%{filter}%'";
                dgvDetainLincesesList.DataSource = View1;
            }

            if (string.IsNullOrEmpty(filter) || selectedColumnName == "None")
            {
                dgvDetainLincesesList.DataSource = OriginalList;

                return;
            }
        }

        private void pbDetainLicense_MouseHover(object sender, EventArgs e)
        {
            pbDetainLicense.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbReleaseLicense_MouseHover(object sender, EventArgs e)
        {
            pbReleaseLicense
                .BorderStyle = BorderStyle.FixedSingle;

        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLincesesList.CurrentRow.Cells[1].Value;
            FrmReleaseDetainedLicense form = new FrmReleaseDetainedLicense(LicenseID);
            form.ShowDialog();
        }

        private void cmsApplicationOptions_Opening(object sender, CancelEventArgs e)
        {
            int LicenseID = (int)dgvDetainLincesesList.CurrentRow.Cells[1].Value; 

            if(!clsLicenses.Find(LicenseID).isDetained)
            {
                releaseLicenseToolStripMenuItem.Enabled = false; 
            }
        }
    }
}
