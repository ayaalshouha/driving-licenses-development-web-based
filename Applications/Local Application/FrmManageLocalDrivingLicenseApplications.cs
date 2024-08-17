using DVLD___Driving_Licenses_Managment.Applications.Local_Application;
using DVLD___Driving_Licenses_Managment.License;
using DVLD___Driving_Licenses_Managment.Tests;
using DVLD_Buissness;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class FrmManageLocalDrivingLicenseApplications : Form
    {
        public FrmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void _UpdateList()
        {
            dgvInternationalApplicationsList.DataSource = clsLocalDrivingLicenses.List();
            lblRecordNumber.Text = dgvInternationalApplicationsList.RowCount.ToString();
        }

        private void FrmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            dgvInternationalApplicationsList.DataSource = clsLocalDrivingLicenses.List();
            lblRecordNumber.Text = dgvInternationalApplicationsList.RowCount.ToString();

            comboBox1.Items.Add("None");
            comboBox1.SelectedItem = "None";
            
            foreach (DataGridViewColumn column in dgvInternationalApplicationsList.Columns)
            {
                if (column.HeaderText == "Date" || column.HeaderText == "PassedTestCount" || column.HeaderText == "Class")
                {
                    continue;
                }
                comboBox1.Items.Add(column.HeaderText);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "None")
            {
                textBox1.Visible = false;
                cbStatusChoices.Visible = false;
                dgvInternationalApplicationsList.DataSource = clsLocalDrivingLicenses.List();
            }
            else if (comboBox1.Text == "Status")
            {
                textBox1.Visible = false;
                cbStatusChoices.Visible = true;
                cbStatusChoices.SelectedIndex = 0;
            }
            else
            {
                textBox1.Visible = true;
                cbStatusChoices.Visible = false;
                textBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable OriginalList = clsLocalDrivingLicenses.List();
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
                View1.RowFilter = $"{selectedColumnName} = '{filter}'";
                dgvInternationalApplicationsList.DataSource = View1;
            }
            else
            {
                DataView View1 = OriginalList.DefaultView;
                View1.RowFilter = $"{selectedColumnName} LIKE '%{filter}%'";
                dgvInternationalApplicationsList.DataSource = View1;
            }

        }
        private void cbStatusChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbStatusChoices.SelectedIndex)
            {
                case 0:
                    dgvInternationalApplicationsList.DataSource = clsLocalDrivingLicenses.List();
                    lblRecordNumber.Text = dgvInternationalApplicationsList.RowCount.ToString();
                    break;

                case 1:
                    dgvInternationalApplicationsList.DataSource = clsLocalDrivingLicenses.NewStatus_List();
                    lblRecordNumber.Text = dgvInternationalApplicationsList.RowCount.ToString();
                    break;

                case 2:
                    dgvInternationalApplicationsList.DataSource = clsLocalDrivingLicenses.CancelledStatus_List();
                    lblRecordNumber.Text = dgvInternationalApplicationsList.RowCount.ToString();
                    break;

                case 3:
                    dgvInternationalApplicationsList.DataSource = clsLocalDrivingLicenses.CompletedStatus_List();
                    lblRecordNumber.Text = dgvInternationalApplicationsList.RowCount.ToString();
                    break;
            
            }
        }

        private void pbAddNewLocalApplication_Click(object sender, EventArgs e)
        {
            FrmAddEditLocalLicenseApplication frm = new FrmAddEditLocalLicenseApplication();
            frm.ShowDialog();
            _UpdateList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedLocalApplicationID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value;
            FrmAddEditLocalLicenseApplication frm = new FrmAddEditLocalLicenseApplication(SelectedLocalApplicationID);
            frm.ShowDialog();
            _UpdateList();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsLocalDrivingLicenses.Delete((int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value) 
                && clsApplication.Delete((int)dgvInternationalApplicationsList.CurrentRow.Cells[1].Value))
            {
                MessageBox.Show("Application Deletted Successfully","Deletion process", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong, try again later!", "Deletion Failed!", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenses local_applicaiton = clsLocalDrivingLicenses.Find((int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value);
            if (clsApplication.Cancel(local_applicaiton.ApplicationID))
            {
                MessageBox.Show("Application Cancelled Successfully", "Cancel process", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong, try again later!", "Cancel Failed!", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }
            _UpdateList();
        }
        private void ScheduleTest(clsTestTypes.enTestType Type)
        {
            int SelectedLocalApplicationID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value;
            FrmTestAppointments Form = new FrmTestAppointments(Type, SelectedLocalApplicationID);
            Form.ShowDialog();
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTest(clsTestTypes.enTestType.VisionTest);
            _UpdateList();
        }

        private void theoriticalTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTest(clsTestTypes.enTestType.WrittenTest);
            _UpdateList();
        }

        private void practicalTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTest(clsTestTypes.enTestType.StreetTest);
            _UpdateList();
        }

        private void cmsApplicationOptions_Opening(object sender, CancelEventArgs e)
        {
            
            int PassedTestCount = (int)dgvInternationalApplicationsList.CurrentRow.Cells[5].Value;
            int SelectedLocalApplicationID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenses LocalApplication = clsLocalDrivingLicenses.Find(SelectedLocalApplicationID);

            bool LicenseExists = LocalApplication.isLicenseIssued();

            //issue a license Enabled only if person passed all tests and Does not have license. 
            isseDrivingLicenseFirstTimeToolStripMenuItem.Enabled = !LicenseExists && (PassedTestCount == 3);

            //show license tool strip 
            showLicenseToolStripMenuItem.Enabled = LicenseExists;

            //edit application 
            editApplicationToolStripMenuItem.Enabled = (LocalApplication.MainApplicationInfo.Status == clsApplication.enApplicationSatatus.New && !LicenseExists); 
            
            //Cancel Menue Item
            cancelApplicationToolStripMenuItem.Enabled = (LocalApplication.MainApplicationInfo.Status == clsApplication.enApplicationSatatus.New && !LicenseExists);


            // Delete Menue Item
            deleteApplicationToolStripMenuItem.Enabled = (LocalApplication.MainApplicationInfo.Status == clsApplication.enApplicationSatatus.New && !LicenseExists);

            //Enable Disable Schedule menue and it's sub menue
            ScheduletoolStripMenuItem7.Enabled = (LocalApplication.MainApplicationInfo.Status == clsApplication.enApplicationSatatus.New && !LicenseExists && PassedTestCount != 3);


            //shedule sub-menu  
            if (ScheduletoolStripMenuItem7.Enabled)
            {
                bool VisionTestPassed = LocalApplication.isTestPassed(clsTestTypes.enTestType.VisionTest);
                bool WrittenTestPassed = LocalApplication.isTestPassed( clsTestTypes.enTestType.WrittenTest);
                bool StretTestPassed = LocalApplication.isTestPassed(clsTestTypes.enTestType.StreetTest);

                visionTestToolStripMenuItem.Enabled = !VisionTestPassed;
                theoriticalTestToolStripMenuItem.Enabled = VisionTestPassed && !WrittenTestPassed;
                practicalTestToolStripMenuItem.Enabled = VisionTestPassed && WrittenTestPassed && !StretTestPassed; 
            }

            //show person History ALWAYS
            //show application details ALWAYS
        }

        private void isseDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedLocalApplicationID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value;
            FrmIssueDrivingLicense Form = new FrmIssueDrivingLicense(SelectedLocalApplicationID);
            Form.ShowDialog();
            _UpdateList();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedLocalApplicationID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenses LocalApplication = clsLocalDrivingLicenses.Find(SelectedLocalApplicationID);

            int LicenseID = LocalApplication.getLicenseID();

            if(LicenseID != -1)
            {
                FrmShowLicenseInfo form = new FrmShowLicenseInfo(LicenseID);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No License Found!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedLocalApplicationID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value;
            FrmShpwApplicationInfo Form = new FrmShpwApplicationInfo(SelectedLocalApplicationID);
            Form.ShowDialog();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if a person has licenses it will be appeared here 
            int SelectedLocalApplicationID = (int)dgvInternationalApplicationsList.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenses LocalApplication = clsLocalDrivingLicenses.Find(SelectedLocalApplicationID);
            FrmPersonLicensesHistory form = new FrmPersonLicensesHistory(LocalApplication.MainApplicationInfo.PersonID);
            form.ShowDialog();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "NationalID" || comboBox1.Text == "ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
