using DVLD_Data;
using System;
using static DVLD_Buissness.clsApplication;

namespace DVLD_Buissness
{
    public class clsApplication
    {
        private enum enMode { Add, Update };
        private enMode _Mode = enMode.Add;
        public enum enApplicationTypes
        {
            NewLocalDL = 1, RenewDL = 2, LostReplacement = 3,
            DamagedReplacement = 4, ReleaseDetainedDL = 5, NewInternationalDL = 6, RetakeTest = 7
        }

        public enum enApplicationSatatus { New = 1, Cancelled = 2, Completed = 3 }


        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; } 
        public enApplicationSatatus Status { get; set; }
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
                    case enApplicationSatatus.New:
                        return "New";
                    case enApplicationSatatus.Cancelled:
                        return "Cancelled";
                    case enApplicationSatatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
       public clsApplication()
       {
            _Mode = enMode.Add;
            this.ID = -1; 
            this.PersonID = -1;
            this.Status = enApplicationSatatus.New;
            this.TypeID = -1;
            this.Date = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.lastStatusDate = DateTime.Now; 
       }

        private clsApplication(stApplication application)
        {
            this.ID = application.ID;
            this.PersonID = application.PersonID;
            this.Status = (enApplicationSatatus)application.Status;
            this.TypeID = application.Type;
            this.TypeInfo = clsApplicationTypes.Find(TypeID); 
            this.Date = application.Date;
            this.lastStatusDate = application.lastStatusDate;
            this.CreatedByUserID = application.CreatedByUserID;
            this.PaidFees = application.PaidFees;
            this.PersonInfo = clsPerson.Find(this.PersonID);
            _Mode = enMode.Update; 
        }

        public static clsApplication Find(int ApplicationID)
        {
            stApplication application = new stApplication();
            if (ApplicationData.getApplicationInfo(ApplicationID, ref application))
                return new clsApplication(application);
            else
                return null; 
        }

        public string ApplicantFullName()
        {
            return ApplicationData.GetFullNameOfApplicant(this.PersonID); 
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
