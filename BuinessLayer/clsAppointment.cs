using DTOsLayer;
using DataLayer;
namespace BuisnessLayer
{
    public class clsAppointment
    {
        public enMode _Mode = enMode.add;
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public enTestType TestType { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }
        public int CreatedByUserID { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public int? RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestInfo {  get; set; }
        public int TestID
        {
            get
            {
                return Appointments_Data.getTestIDAsync(this.ID).GetAwaiter().GetResult(); 
            }
        }
        public Appointment AppointementDTO
        {
            get
            {
                return new Appointment(this.CreatedByUserID, this.RetakeTestApplicationID, (int)this.TestType, 
                    this.LocalLicenseApplicationID, this.ID, this.Date, this.PaidFees, this.isLocked);
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
            this._Mode = enMode.add;
        }
        private clsAppointment(Appointment appointment)
        {
            this.ID = appointment.ID;
            this.Date = appointment.Date;
            this.TestType = (enTestType)appointment.TestType;
            this.PaidFees = appointment.PaidFees;
            this.isLocked = appointment.isLocked;
            this.CreatedByUserID = appointment.CreatedByUserID;
            this.LocalLicenseApplicationID = appointment.LocalLicenseApplicationID;
            this.RetakeTestApplicationID = appointment.RetakeTestID; 
            this._Mode = enMode.update; 
        }

        public static async Task<clsAppointment> FindAsync(int appointmentID)
        {
            Appointment appointment = await Appointments_Data.getAppointmentInfoAsync(appointmentID);
            if(appointment != null)
                return new clsAppointment(appointment);
            else
                return null;
        }
        public async Task<bool> _AddNewAsync()
        {
            this.ID = await Appointments_Data.AddAsync(AppointementDTO);
            return this.ID != -1;
        }
        public async Task<bool> _UpdateAsync()
        {
            return await Appointments_Data.UpdateAsync(AppointementDTO);
        }
        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.add:
                    if (await _AddNewAsync())
                    {
                        this._Mode = enMode.update;
                        return true;
                    }
                    break;
                case enMode.update:
                    return await _UpdateAsync();
            }

            return false;
        }
        public static async Task<IEnumerable<Appointement_>> AppointmentsTablePerTestTypeAsync(int LocalDrivingID,enTestType TestType)
        {
            return await Appointments_Data.getAppointmentsTablePerTestTypeAsync(LocalDrivingID, (int)TestType); 
        }
        public static async Task<IEnumerable<Appointement_>> Appointments_View()
        {
            return await Appointments_Data.Appointments_View();
        }
        public static async Task<bool> isThereAnyActiveAppointments(int LocalDrivingID, enTestType TestType)
        {
            return await Appointments_Data.isThereAnyActiveAppointmentsAsync(LocalDrivingID, (int)TestType); 
        }    
        public static async Task<bool> isExistAsync(int id)
        {
            return await Appointments_Data.isExist(id);
        }
        public static async Task<bool> DeleteAsync(int id)
        {
            return await Appointments_Data.DeleteAsync(id);
        }
        public static async Task<Appointment> GetApointmentPerTestType(int localID, enTestType TestTypeID)
        {
            return await Appointments_Data.getAppointmentByTest(localID, (int)TestTypeID);
        }
        public static async Task<bool> UpdateDate(int ID, DateTime date)
        {
            return await Appointments_Data.UpdateDate(ID, date);
        }
    }
}
