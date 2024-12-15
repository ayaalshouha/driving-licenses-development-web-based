using System;
using static BuisnessLayer.clsApplication;
using DataLayer;
using DTOsLayer;
using System.Text.Json.Serialization;

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
        public DateTime Date { get; set; }
        public decimal PaidFees { get; set; }
        public DateTime lastStatusDate { get; set; }
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
            this.Date = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.lastStatusDate = DateTime.Now; 
       }
        private clsApplication(_Application application)
        {
            this.ID = application.ID;
            this.PersonID = application.PersonID;
            this.Status = (enStatus)application.Status;
            this.TypeID = application.Type;
            this.TypeInfo = clsApplicationTypes.FindAsync(TypeID).GetAwaiter().GetResult(); 
            this.Date = application.Date;
            this.lastStatusDate = application.lastStatusDate;
            this.CreatedByUserID = application.CreatedByUserID;
            this.PaidFees = application.PaidFees;
            this.PersonInfo = clsPerson.FindAsync(this.PersonID).GetAwaiter().GetResult();
            _Mode = enMode.update; 
        }
        public static clsApplication Find(int ApplicationID)
        {
            return FindAsync(ApplicationID).GetAwaiter().GetResult();
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
        public  async Task<string> ApplicantFullNameAsync()
        {
            return await PersonData.GetFullNameOfApplicantAsync(this.PersonID); 
        }

        //Create sync version of async method
        public string ApplicantFullName
        {
            get { return ApplicantFullNameAsync().GetAwaiter().GetResult(); }
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

        public async Task<decimal> FeesAsync()
        {
            decimal fee = await ApplicationData.GetFeesAsync(this.ID);
            return fee; 
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
        public static async Task<bool> isExistAsync(int AppID)
        {
            return await ApplicationData.isExistAsync(AppID); 
        }
        public static async Task<bool> isClassExistAsync(int PersonID, int ClassID)
        {
            return await ApplicationData.isClassExistAsync(PersonID, ClassID); 
        }

       
    }
}
