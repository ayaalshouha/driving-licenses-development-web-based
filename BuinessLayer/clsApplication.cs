using System;
using static BuisnessLayer.clsApplication;
using DataLayer;
using DTOsLayer;

namespace BuisnessLayer
{
    public class clsApplication
    {
        private enMode _Mode = enMode.add;
        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; } 
        public enStatus Status { get; set; }
        public int TypeID { get; set; }
        public clsApplicationTypes TypeInfo { get; set; }
        public DateOnly Date { get; set; }
        public decimal PaidFees { get; set; }
        public DateOnly lastStatusDate { get; set; }
        public int CreatedByUserID { get; set; }   
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case enStatus.New:
                        return "New";
                    case enStatus.cancelled:
                        return "Cancelled";
                    case enStatus.completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        public _Application applicationDTO
        {
            get
            {
                return new _Application
                    (   
                        this.ID, PersonID,this.Status, this.TypeID, this.Date, this.PaidFees, this.lastStatusDate, this.CreatedByUserID
                    );
            }
        }
       public clsApplication()
       {
            _Mode = enMode.add;
            this.ID = -1; 
            this.PersonID = -1;
            this.Status = enStatus.New;
            this.TypeID = -1;
            this.Date = DateOnly.FromDateTime(DateTime.Now);
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.lastStatusDate = DateOnly.FromDateTime(DateTime.Now); 
       }

        private clsApplication(_Application application)
        {
            this.ID = application.ID;
            this.PersonID = application.PersonID;
            this.Status = (enStatus)application.Status;
            this.TypeID = application.Type;
            this.TypeInfo = clsApplicationTypes.Find(TypeID); 
            this.Date = application.Date;
            this.lastStatusDate = application.lastStatusDate;
            this.CreatedByUserID = application.CreatedByUserID;
            this.PaidFees = application.PaidFees;
            this.PersonInfo = clsPerson.Find(this.PersonID);
            _Mode = enMode.update; 
        }

        public static async Task<clsApplication> FindAsync(int ApplicationID)
        {
            _Application application = await ApplicationData.getApplicationInfoAsync(ApplicationID);
            if (application != null)
                return new clsApplication(application);
            else
                return null; 
        }
        public static async Task<_Application> FindDTOAsync(int ApplicationID)
        {
            _Application application = await ApplicationData.getApplicationInfoAsync(ApplicationID);
            if (application != null)
                return application;
            else
                return null;
        }
        public async Task<string> ApplicantFullNameAsync()
        {
            return await ApplicationData.GetFullNameOfApplicantAsync(this.PersonID); 
        }
        private async Task<bool> _AddNewAsync()
        {
            this.ID = await ApplicationData.AddAsync(applicationDTO);
            return this.ID != -1;
        }

        private async Task<bool> _UpdateAsync()
        {
            return await ApplicationData.UpdateAsync(applicationDTO);
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

        public async Task<int> FeesAsync()
        {
            return await ApplicationData.GetFeesAsync(this.ID);
        }

        public static async Task<bool> DeleteAsync(int AppID)
        {
            return await ApplicationData.DeleteAsync(AppID);

        }
        public static async Task<bool> CancelAsync(int ApplicationID)
        {
            return await ApplicationData.CancelAsync(ApplicationID);
        }
        public async Task<bool> setCompletedAsync()
        {
            return await ApplicationData.UpdateStatusAsync(this.ID,3);
        }
        public static async Task<bool> isClassExistAsync(int PersonID, int ClassID)
        {
            return await ApplicationData.isClassExistAsync(PersonID, ClassID); 
        }

       
    }
}
