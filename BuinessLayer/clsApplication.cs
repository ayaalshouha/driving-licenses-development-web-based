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

        //TODO : convert methods into async 
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
            return await ApplicationData.GetFullNameOfApplicant(this.PersonID); 
        }
        private bool _AddNew()
        {
            stApplication application = new stApplication
            {
                ID = this.ID,
                PersonID = this.PersonID,
                Date = this.Date,
                lastStatusDate = this.lastStatusDate,
                Status = (enStatus)this.Status,
                Type = this.TypeID,
                CreatedByUserID = this.CreatedByUserID,
                PaidFees = this.PaidFees,
            };

            this.ID = ApplicationData.Add(application);
            return this.ID != -1;
        }

        private bool _Update()
        {
            stApplication application = new stApplication
            {
                ID = this.ID,
                PersonID = this.PersonID,
                Date = this.Date,
                lastStatusDate = this.lastStatusDate,
                Status = (enStatus)this.Status,
                Type = this.TypeID,
                CreatedByUserID = this.CreatedByUserID,
                PaidFees = this.PaidFees,
            };

            return ApplicationData.Update(application);
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

        public int Fees()
        {
            return ApplicationData.GetFees(this.ID);
        }

        public static bool Delete(int AppID)
        {
            return ApplicationData.Delete(AppID);

        }

        public static bool Cancel(int ApplicationID)
        {
            return ApplicationData.Cancel(ApplicationID);
        }


        public bool setCompleted()
        {
            return ApplicationData.UpdateStatus(this.ID,3);
        }

        public static bool isClassExist(int PersonID, int ClassID)
        {
            return ApplicationData.isClassExist(PersonID, ClassID); 
        }

       
    }
}
