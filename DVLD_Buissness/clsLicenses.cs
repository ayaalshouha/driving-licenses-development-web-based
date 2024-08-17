using DVLD_Data;
using System;

namespace DVLD_Buissness
{
    public class clsLicenses
    {
        public enum enMode { Add = 1, Update }
        public enMode _Mode = enMode.Add; 
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDrviers DriverInfo {  get; set; }
        public int LicenseClass { get; set; }
        public clsLicenseClasses ClassInfo {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpDate { get; set; }
        public bool isActive { get; set; }
        public decimal PaidFees { get; set; }
        public enIssueReason IssueReason { get; set; }

        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public bool isDetained
        {
            get { return clsDetainedLicenses.isLicenseDetained(this.ID); }
        }

        public clsLicenses()
        {
            this.ID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.CreatedByUserID = -1;
            this.LicenseClass = -1;
            this.isActive = false;
            this.IssueDate = DateTime.Now; 
            this.ExpDate=DateTime.Now;
            this.Notes=string.Empty;
            this.PaidFees = -1;
            this.IssueReason = enIssueReason.FirstTime;
            this._Mode = enMode.Add;
        }

        private clsLicenses(stLicenses license)
        {
            this.ID = license.ID;
            this.ApplicationID = license.ApplicationID;
            this.DriverID = license.DriverID;
            this.CreatedByUserID = license.CreatedByUserID;
            this.isActive = license.isActive;
            this.IssueDate = license.IssueDate;
            this.ExpDate = license.ExpDate;
            this.Notes = license.Notes;
            this.PaidFees = license.PaidFees;
            this.IssueReason = (enIssueReason)license.IssueReason;
            this.LicenseClass = license.LicenseClass;
            this.ClassInfo = clsLicenseClasses.Find(this.LicenseClass);
            this.DriverInfo = clsDrviers.Find(this.DriverID);

            this._Mode = enMode.Update;
        }
        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";
                    case enIssueReason.Renew:
                        return "Renew";
                    case enIssueReason.DamagedReplacement:
                        return "Replacement for Damaged";
                    case enIssueReason.LostReplacement:
                        return "Replacement for Lost";
                    default:
                        return "First Time";
                }
            }
        }

        public static clsLicenses Find(int licenseID)
        {
            stLicenses license = new stLicenses();
            if (LicensesData.getLicenseInfo(licenseID, ref license))
                return new clsLicenses(license);
            else
                return null;
        }

        public bool _AddNew()
        {
            stLicenses license = new stLicenses
            {
                ID = this.ID,
                ApplicationID = this.ApplicationID,
                IssueDate = this.IssueDate,
                ExpDate = this.ExpDate,
                isActive = true,
                Notes = this.Notes,
                CreatedByUserID = this.CreatedByUserID,
                PaidFees = this.PaidFees,
                IssueReason = (int)this.IssueReason,
                LicenseClass = this.LicenseClass,
                DriverID = this.DriverID
            };

            this.ID = LicensesData.Add(license);
            return this.ID != -1;
        }

        public bool _Update()
        {
            stLicenses license = new stLicenses
            {
                ID = this.ID,
                ApplicationID = this.ApplicationID,
                IssueDate = this.IssueDate,
                ExpDate = this.ExpDate,
                isActive = this.isActive,
                Notes = this.Notes,
                CreatedByUserID = this.CreatedByUserID,
                PaidFees = this.PaidFees,
                IssueReason = (int)this.IssueReason,
                LicenseClass = this.LicenseClass,
                DriverID = this.DriverID
            };

            return LicensesData.Update(license);
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

        public bool ActivateCurrentLicense()
        {
            return LicensesData.DeactivateLicense(this.ID);
        }
        public bool DeactivateCurrentLicense()
        {
            return LicensesData.ActivateLicense(this.ID);
        }

        public clsLicenses RenewLicense(string Notes, int CreatedByUserID)
        {
            clsApplication NewApplication = new clsApplication();
            clsLicenses NewLicense = new clsLicenses();

            NewApplication.PersonID = this.DriverInfo.PersonID;
            NewApplication.Status = clsApplication.enApplicationSatatus.New;
            NewApplication.TypeID = (int)clsApplication.enApplicationTypes.RenewDL;
            NewApplication.PaidFees = clsApplicationTypes.Fee(NewApplication.TypeID);
            NewApplication.Date = DateTime.Now;
            NewApplication.lastStatusDate = DateTime.Now;
            NewApplication.CreatedByUserID = CreatedByUserID;

            if (NewApplication.Save())
            {
                NewLicense.ApplicationID = NewApplication.ID;
                NewLicense.DriverID = this.DriverID;
                NewLicense.LicenseClass = this.LicenseClass; 
                NewLicense.IssueDate = DateTime.Now;
                NewLicense.ExpDate = DateTime.Now.AddYears(this.ClassInfo.DefaultValidityLength);
                NewLicense.isActive = true;
                NewLicense.PaidFees = (decimal)this.ClassInfo.ClassFees;
                NewLicense.IssueReason = enIssueReason.Renew;
                NewLicense.Notes = Notes;
                NewLicense.CreatedByUserID = CreatedByUserID;

                if (NewLicense.Save())
                {
                    NewApplication.setCompleted();
                    DeactivateCurrentLicense();
                }

            }
            return NewLicense;
        }

        public clsLicenses Replace(enIssueReason reason, int CreatedByUserID)
        {
            clsApplication NewApplication = new clsApplication();
            clsLicenses NewLicense = new clsLicenses();

            NewApplication.PersonID = this.DriverInfo.PersonID;
            NewApplication.Status = clsApplication.enApplicationSatatus.New;
            NewApplication.TypeID = (reason == enIssueReason.DamagedReplacement ?
                (int)clsApplication.enApplicationTypes.DamagedReplacement :
                (int)clsApplication.enApplicationTypes.LostReplacement);


            NewApplication.PaidFees = clsApplicationTypes.Fee(NewApplication.TypeID);
            NewApplication.Date = DateTime.Now;
            NewApplication.lastStatusDate = DateTime.Now;
            NewApplication.CreatedByUserID = CreatedByUserID;

            if (NewApplication.Save())
            {
                
                NewLicense.ApplicationID = NewApplication.ID;
                NewLicense.DriverID = this.DriverID;
                NewLicense.LicenseClass = this.LicenseClass;
                NewLicense.IssueDate = DateTime.Now;
                NewLicense.ExpDate = DateTime.Now.AddYears(this.ClassInfo.DefaultValidityLength);
                NewLicense.isActive = true;
                NewLicense.PaidFees = (decimal)this.ClassInfo.ClassFees;
                NewLicense.IssueReason = reason; 
                NewLicense.Notes = Notes;
                NewLicense.CreatedByUserID = CreatedByUserID;

                if (NewLicense.Save())
                {
                    NewApplication.setCompleted();
                    DeactivateCurrentLicense();
                }
            }

            return NewLicense; 
        }


        public int Detain(decimal finefee, int CreatedByUserID)
        {
            int DetainID = -1;
            clsDetainedLicenses DetainInfo = new clsDetainedLicenses();
            DetainInfo.DetainDate = DateTime.Now;
            DetainInfo.FineFees = finefee;
            DetainInfo.isReleased = false;
            DetainInfo.CreatedByUserID = CreatedByUserID;
            DetainInfo.LicenseID = this.ID;

            if (DetainInfo.Save())
            {
                this.DeactivateCurrentLicense();
                DetainID = DetainInfo.ID; 
            }

            return DetainID; 
        }

        public bool ReleaseLicense(int ReleasedByUserID)
        {
            if (!this.isDetained)
                return false;


            clsDetainedLicenses detainInfo = clsDetainedLicenses.FindByLicenseID(this.ID);
            clsApplication NewApplication = new clsApplication();

            NewApplication.PersonID = this.DriverInfo.PersonID;
            NewApplication.Status = clsApplication.enApplicationSatatus.New;
            NewApplication.TypeID = (int)clsApplication.enApplicationTypes.ReleaseDetainedDL;
            NewApplication.Date = DateTime.Now;
            NewApplication.PaidFees = clsApplicationTypes.Fee(NewApplication.TypeID); 
            NewApplication.lastStatusDate = DateTime.Now;
            NewApplication.CreatedByUserID = ReleasedByUserID;

            if (NewApplication.Save())
            {
                if (detainInfo != null)
                {
                    detainInfo.ReleaseApplicationID = NewApplication.ID;
                    detainInfo.isReleased = true;
                    detainInfo.ReleaseDate = DateTime.Now;
                    detainInfo.ReleasedByUserID = ReleasedByUserID;

                    if (detainInfo.Save())
                    {
                        this.ActivateCurrentLicense();
                        NewApplication.setCompleted();
                        return true; 
                    }
                }
            }

            return false; 
        }
    }
}
