using DVLD_Data;
using System;
using System.Data;

namespace DVLD_Buissness
{
    public class clsAppointment
    {
        public enum enMode { Add, Update };
        public enMode _Mode = enMode.Add;

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public clsTestTypes.enTestType TestType { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }
        public int CreatedByUserID { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestInfo {  get; set; }
        public int TestID
        {
            get
            {
                return Appointments_Data.getTestID(this.ID); 
            }
        }
        public clsAppointment()
        {
            this.ID = -1;
            this.Date = DateTime.Now;
            this.TestType = 0;
            this.PaidFees = -1;
            this.isLocked = false;
            this.CreatedByUserID = -1;
            this.LocalLicenseApplicationID = -1;
            this.RetakeTestApplicationID = -1;
            this._Mode = enMode.Add;
        }
        private clsAppointment(stAppointment appointment)
        {
            this.ID = appointment.ID;
            this.Date = appointment.Date;
            this.TestType = (clsTestTypes.enTestType)appointment.TestType;
            this.PaidFees = appointment.PaidFees;
            this.isLocked = appointment.isLocked;
            this.CreatedByUserID = appointment.CreatedByUserID;
            this.LocalLicenseApplicationID = appointment.LocalLicenseApplicationID;
            this.RetakeTestApplicationID = appointment.RetakeTestID; 
            this._Mode = enMode.Update; 
        }

        public static clsAppointment Find(int appointmentID)
        {
            stAppointment appointment = new stAppointment();
            if (Appointments_Data.getAppointmentInfo(appointmentID, ref appointment))
                return new clsAppointment(appointment);
            else
                return null;
        }

        public bool _AddNew()
        {
            stAppointment appointment = new stAppointment
            {
                ID = this.ID,
                Date = this.Date,
                PaidFees = this.PaidFees,
                LocalLicenseApplicationID = this.LocalLicenseApplicationID,
                isLocked = this.isLocked,
                TestType = (int)this.TestType,
                CreatedByUserID = this.CreatedByUserID,
                RetakeTestID = this.RetakeTestApplicationID
            };

            this.ID = Appointments_Data.Add(appointment);
            return this.ID != -1;
        }

        public bool _Update()
        {
            stAppointment appointment = new stAppointment
            {
                ID = this.ID,
                Date = this.Date,
                TestType = (int)this.TestType,
                LocalLicenseApplicationID = this.LocalLicenseApplicationID,
                isLocked = this.isLocked,
                PaidFees = this.PaidFees,
                CreatedByUserID = this.CreatedByUserID,
                 RetakeTestID = this.RetakeTestApplicationID
            };

            return Appointments_Data.Update(appointment);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddNew())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static DataTable AppointmentsTablePerTestType(int LocalDrivingID, clsTestTypes.enTestType TestType)
        {
            return Appointments_Data.getAppointmentsTablePerTestType(LocalDrivingID, (int)TestType); 
        }

        public static bool isThereAnyActiveAppointments(int LocalDrivingID, clsTestTypes.enTestType TestType)
        {
            return Appointments_Data.isThereAnyActiveAppointments(LocalDrivingID, (int)TestType); 
        }
    }
}
