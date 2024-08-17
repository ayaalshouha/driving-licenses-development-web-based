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

namespace DVLD___Driving_Licenses_Managment.Controls
{
    public partial class cntrlScheduleTest : UserControl
    {
        private enum enMode { Add=1, Update=2}
        private enMode _Mode = enMode.Add;

        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private enum enCreationMode { FirstTimeSchedule=1, RetakeTestShedule=2}
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsLocalDrivingLicenses _LocalApplication;
        private int _LocalApplicationID = -1;
        private clsAppointment _Appointment; 
        private int _AppointmentID = -1;

        public clsTestTypes.enTestType TestTypeID { 

            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
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

        private void _LoadAppointmentData(clsAppointment appointment)
        {

            if (appointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + appointment.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            lblLicenseID.Text = appointment.LocalLicenseApplicationID.ToString();
            lblFees.Text = appointment.PaidFees.ToString();
            datePicker.Value = appointment.Date;


            if(DateTime.Compare(DateTime.Now, appointment.Date) < 0) 
                datePicker.MinDate = DateTime.Now;
            else
                datePicker.MinDate = appointment.Date;


            if(appointment.RetakeTestApplicationID == -1)
            {
                lblRetakeFees.Text = "0"; 
                lblRetakeTestID.Text = "N/A";
            }
            else
            {
                lblRetakeTestID.Text = appointment.RetakeTestApplicationID.ToString();

                if(appointment.RetakeTestInfo != null)
                {
                    lblRetakeFees.Text = appointment.RetakeTestInfo.PaidFees.ToString();
                }

                gbRetakeTest.Enabled = true;
                lblHeader.Text = "Schedule Retake Test";
            }

            if (!_HandleAppointmentLockedConstraint())
                return;
        }
        private bool _HandlePreviousTestConstraint()
        {
            switch (TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblUserMessage.Visible = false;
                    return true;

                case clsTestTypes.enTestType.WrittenTest:
                    if (!_LocalApplication.DoesAttendTestType(clsTestTypes.enTestType.VisionTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        datePicker.Enabled = false;
                        return false;

                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        datePicker.Enabled = true;
                    }
                    return true;

                case clsTestTypes.enTestType.StreetTest:
                    if (!_LocalApplication.DoesAttendTestType(clsTestTypes.enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        datePicker.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        datePicker.Enabled = true;
                    }
                    return true;
            }
            return true;
        }
        public void LoadInfo(int LocalAppID, int AppointmentID = -1)
        {
            _LocalApplicationID = LocalAppID;
            _AppointmentID = AppointmentID; 
            _Appointment =  clsAppointment.Find(_AppointmentID);
            _LocalApplication = clsLocalDrivingLicenses.Find(_LocalApplicationID);


            if (_AppointmentID == -1)
                _Mode = enMode.Add;
            else
                _Mode = enMode.Update;


            //appointment mode 
            if (_Mode == enMode.Add)
            {
                _Appointment = new clsAppointment();
                lblFees.Text = clsTestTypes.Find((int)_TestTypeID).Fees.ToString();
                lblRetakeTestID.Text = "N/A";
                datePicker.MinDate = DateTime.Now; 
            }
            else
            {
                _LoadAppointmentData(_Appointment);
            }

           

            //decide creation mode 
            if (_LocalApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestShedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule; 



            if(_CreationMode == enCreationMode.RetakeTestShedule)
            {
                gbRetakeTest.Enabled = true;
                lblHeader.Text = "Schedule Retake Test";
                lblRetakeFees.Text = clsApplicationTypes.Fee((int)clsApplication.enApplicationTypes.RetakeTest).ToString();
                lblRetakeTestID.Text = "0"; 
            }
            else
            {
                lblHeader.Text = "Schedule Test";
                lblRetakeFees.Text = "0";
                lblRetakeTestID.Text = "N/A";
            }

            lblTotalFees.Text = (Convert.ToSingle(lblRetakeFees.Text) + Convert.ToSingle(lblFees.Text)).ToString();
            lblLicenseID.Text = _LocalApplication.ID.ToString();
            lblClassName.Text = _LocalApplication.LicenseClassesInfo.ClassName;
            lblFullName.Text = _LocalApplication.FullName;

            if (!_HandlePreviousTestConstraint())
                return;

        }

        public cntrlScheduleTest()
        {
            InitializeComponent();
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_Appointment.isLocked)
            {
                lblUserMessage.Visible = true;
                btnSave.Enabled = false; 
                datePicker.Enabled = false;
                return false; 

            }
            else
                lblUserMessage.Visible = false;


            return true; 
        }
        private bool _HandleRetakeApplication()
        {
            if (_Mode == enMode.Add && _CreationMode == enCreationMode.RetakeTestShedule)
            {
                clsApplication Application = new clsApplication();

                Application.PersonID = _LocalApplication.MainApplicationInfo.PersonID;
                Application.Date = DateTime.Now;
                Application.TypeID = (int)clsApplication.enApplicationTypes.RetakeTest;
                Application.Status = clsApplication.enApplicationSatatus.Completed;
                Application.lastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationTypes.RetakeTest).Fees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.ID;

                if (!Application.Save())
                {
                    _Appointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //not handled
                    return false;
                }
                _Appointment.RetakeTestApplicationID = Application.ID;
            }
            //handled
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return; 


            _Appointment.TestType = _TestTypeID;
            _Appointment.LocalLicenseApplicationID = _LocalApplication.ID;
            _Appointment.Date = datePicker.Value;
            _Appointment.PaidFees = Convert.ToDecimal(lblFees.Text);
            _Appointment.CreatedByUserID = clsGlobal.CurrentUser.ID;

            if (_Appointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
