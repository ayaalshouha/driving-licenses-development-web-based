using DVLD___Driving_Licenses_Managment.Properties;
using DVLD_Buissness;
using System;
using System.Windows.Forms;
using static DVLD_Buissness.clsTestTypes;

namespace DVLD___Driving_Licenses_Managment.Controls
{
    public partial class cntrlScheduledTest : UserControl
    {
        private clsLocalDrivingLicenses _LocalApplication;
        private int _LocalAppilicationID = -1;
        private clsAppointment _Appointment;
        private clsTestTypes.enTestType _enTestTypeID = enTestType.VisionTest;
        private int _TestAppointmentID = -1;
        private int _TestID = -1;
        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }
        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _enTestTypeID;
            }

            set
            {
                _enTestTypeID = value;

                switch (_enTestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.eye_chart__1_;
                            break;
                        }

                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.essay;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.street_racing_config;
                            break;
                        }
                }
            }
        }

        public cntrlScheduledTest()
        {
            InitializeComponent();
        }

        public void LoadInformation(int AppointmentID)
        {

            _TestAppointmentID = AppointmentID;

            _Appointment = clsAppointment.Find(_TestAppointmentID);

            if (_Appointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }
            _TestID = _Appointment.TestID;

            _LocalAppilicationID = _Appointment.LocalLicenseApplicationID;
            _LocalApplication = clsLocalDrivingLicenses.Find(_LocalAppilicationID);

            if (_LocalApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalAppilicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLicenseID.Text = _LocalApplication.ID.ToString();
            lblClassName.Text = _LocalApplication.LicenseClassesInfo.ClassName;
            lblFullName.Text = _LocalApplication.FullName;
            lblDate.Text = _Appointment.Date.ToString();
            lblFees.Text = _Appointment.PaidFees.ToString();
            lblTestID.Text = _Appointment.TestID == -1 ? "NOT Taken Yet." : _Appointment.TestID.ToString();
        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
    }
}
