using DVLD_Data;
using System;
using System.Data;

namespace DVLD_Buissness
{
    public class clsInternational_DL
    {
        public enum enMode { Add, Update };
        public enMode _Mode { get; set; }
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication MainApplicationInfo {  get; set; }
        public int DriverID { get; set; }
        public clsDrviers DriverInfo { get; set; }
        public int IssuedByLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpDate { get; set; }
        public bool isActive { get; set; }
        public int CreatedByUserID { get; set; }
     

        public clsInternational_DL()
        {
            this.ID = -1; 
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedByLocalLicenseID = -1;
            this.IssueDate = DateTime.Now; 
            this.ExpDate = DateTime.Now;
            this.isActive = false;
            this.CreatedByUserID = -1;
            _Mode = enMode.Add; 
        }

        private clsInternational_DL(stInternationalLicenses license)
        {
            this.ID = license.ID;
            this.ApplicationID = license.ApplicationID;
            this.MainApplicationInfo = clsApplication.Find(this.ApplicationID); 
            this.DriverID = license.DriverID;
            this.DriverInfo = clsDrviers.Find(this.DriverID); 
            this.IssuedByLocalLicenseID = license.IssuedByLocalLicenseID;
            this.IssueDate = license.IssueDate;
            this.ExpDate = license.ExpDate;
            this.isActive=true;
            this.CreatedByUserID= license.CreatedByUserID;
            _Mode = enMode.Update;
        }

        public static clsInternational_DL Find(int ApplicationID)
        {
            stInternationalLicenses application = new stInternationalLicenses();
            if (International_DL_Data.getApplicationInfo(ApplicationID, ref application))
                return new clsInternational_DL(application);
            else
                return null;
        }

        public bool _AddNew()
        {
            stInternationalLicenses application = new stInternationalLicenses
            {
                ID = this.ID,
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID, 
                IssueDate = this.IssueDate,
                ExpDate = this.ExpDate,
                isActive=this.isActive, 
                IssuedByLocalLicenseID = this.IssuedByLocalLicenseID,
                CreatedByUserID = this.CreatedByUserID
            };

            this.ID = International_DL_Data.Add(application);
            return this.ID != -1;
        }

        public bool _Update()
        {
            stInternationalLicenses application = new stInternationalLicenses
            {
                ID = this.ID,
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                IssueDate = this.IssueDate,
                ExpDate = this.ExpDate,
                isActive = this.isActive,
                IssuedByLocalLicenseID = this.IssuedByLocalLicenseID,
                CreatedByUserID = this.CreatedByUserID
            };

            return International_DL_Data.Update(application);
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

        public static DataTable List()
        {
            return International_DL_Data.getInternationalLicenses();
        }

        public static int getActiveLicenseID(int DriverID)
        {
            return International_DL_Data.GetActiveLicenseID(DriverID);
        }

    }
}
