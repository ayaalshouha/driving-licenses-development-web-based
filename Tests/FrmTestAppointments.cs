using DVLD___Driving_Licenses_Managment.Properties;
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
using static DVLD_Buissness.clsTestTypes;

namespace DVLD___Driving_Licenses_Managment.Tests
{
    public partial class FrmTestAppointments : Form
    {
        private clsLocalDrivingLicenses _LocalApplication; 
        private int _LocalApplicationID = -1;
        private clsTestTypes.enTestType _Type = enTestType.VisionTest; 
        
        public FrmTestAppointments(enTestType type, int LocalApplicationID)
        {
            InitializeComponent();
            _Type = type;
            _LocalApplicationID = LocalApplicationID;
        }

       private void _Refresh()
       {
            dgvAppointments.DataSource = clsAppointment.AppointmentsTablePerTestType(_LocalApplicationID, _Type);
            lblRecordNumber.Text = dgvAppointments.Rows.Count.ToString();

       }
        private void FrmTestAppointments_Load(object sender, EventArgs e)
        {
            cntrlDrivingLicenseAndApplicationBasicInfo1.LoadInformation(_LocalApplicationID); 



            switch (_Type)
            {
                case enTestType.VisionTest:
                    this.Text = "Vision Test Appointments";
                    lblHeader.Text = this.Text;
                    pictureBox1.Image = Resources.eye_chart__1_; 
                    break;
                case enTestType.WrittenTest:
                    this.Text = "Written Test Appointments";
                    lblHeader.Text = this.Text;
                    pictureBox1.Image = Resources.essay;
                    break;
                case enTestType.StreetTest:
                    this.Text = "Street Test Appointments";
                    lblHeader.Text = this.Text;
                    pictureBox1.Image = Resources.street_racing_config;
                    break;
                default:
                    this.Text = "Test Appointments";
                    lblHeader.Text = this.Text;
                    pictureBox1.Image = Resources.cross__1_;
                    break;
            }

            _Refresh(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            _LocalApplication = clsLocalDrivingLicenses.Find(_LocalApplicationID);

            //check if there is an active appointment for the same test type 
            if (clsAppointment.isThereAnyActiveAppointments(_LocalApplicationID,_Type))
            {
                MessageBox.Show("Person Has an Active Appointment, You can't schedule another appointment!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //is appointment locked with pass or fail result 

            clsTests LastTest = _LocalApplication.GetLastTestPerTestType(_Type); 

            if(LastTest == null)
            {
                //there is NO Test before at all 
                //Show Schadule Form 
                FrmScheduleTest Form1 = new FrmScheduleTest(_LocalApplicationID, _Type);
                Form1.ShowDialog();
                _Refresh();
                return;
            }
            
            if(LastTest.Result == true)
            {
                MessageBox.Show("Person has already PASSED this test type, You can't schedule another appointment with the same test type!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //schedule a retake test because he failed 
            FrmScheduleTest Form2 = new FrmScheduleTest(LastTest.AppointmentInfo.LocalLicenseApplicationID, _Type);
            Form2.ShowDialog();
            _Refresh();
            
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            //show scheduled test with pass or fail info 
            FrmTakeTest Form = new FrmTakeTest(_Type, TestAppointmentID);
            Form.ShowDialog();
            _Refresh();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            FrmScheduleTest Form2 = new FrmScheduleTest(_LocalApplicationID, _Type,AppointmentID); 
            Form2.ShowDialog();
            _Refresh();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
