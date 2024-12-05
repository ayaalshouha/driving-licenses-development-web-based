#pragma warning disable CS8604 // Possible null reference argument
using System;
using DataLayer;
using DTOsLayer; 

namespace BuisnessLayer
{
    public class clsLicenses
    {
        public enMode _Mode = enMode.add; 
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDrviers DriverInfo {  get; set; }
        public int LicenseClass { get; set; }
        public clsLicenseClasses ClassInfo {  get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpDate { get; set; }
        public bool isActive { get; set; }
        public decimal PaidFees { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public bool isDetained
        {
            get { return clsDetainedLicenses.isLicenseDetainedAsync(this.ID).GetAwaiter().GetResult(); }
        }
        public _License licenseDTO
        {
            get
            {
                return new _License(this.ID, this.ApplicationID, this.DriverID,
                    this.LicenseClass, this.IssueDate, this.ExpDate,
                    this.isActive, this.PaidFees, (int)this.IssueReason,
                    this.Notes, this.CreatedByUserID);
            }
        }
        public clsLicenses()
        {
            this.ID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.CreatedByUserID = -1;
            this.LicenseClass = -1;
            this.isActive = false;
            this.IssueDate = DateOnly.FromDateTime(DateTime.Now);
            this.ExpDate = DateOnly.FromDateTime(DateTime.Now);
            this.Notes=string.Empty;
            this.PaidFees = -1;
            this.IssueReason = enIssueReason.FirstTime;
            this._Mode = enMode.add;
        }
        private clsLicenses(_License license)
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

            this._Mode = enMode.update;
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
        public static async Task<clsLicenses> FindAsync(int licenseID)
        {
            _License license = await LicensesData.getLicenseInfoAsync(licenseID);
            if (license != null)
                return new clsLicenses(license);
            else
                return null;
        }
        public async Task<bool> _AddNewAsync()
        {
            this.ID = await LicensesData.AddAsync(licenseDTO);
            return this.ID != -1;
        }
        public async Task<bool> _UpdateAsync()
        {
            return await LicensesData.UpdateAsync(licenseDTO);
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
        public async Task<bool> ActivateCurrentLicenseAsync()
        {
            return await LicensesData.DeactivateLicenseAsync(this.ID);
        }
        public async Task<bool> DeactivateCurrentLicenseAsync()
        {
            return await LicensesData.ActivateLicenseAsync(this.ID);
        }
        public async Task<clsLicenses> RenewLicenseAsync(string Notes, int CreatedByUserID)
        {
            var NewApplication = new clsApplication
            {
                PersonID = this.DriverInfo.PersonID,
                Status = enStatus.New,
                TypeID = (int)enApplicationType.RenewDL,
                PaidFees = clsApplicationTypes.FeeAsync(enApplicationType.RenewDL).GetAwaiter().GetResult(),
                Date = DateTime.Now,
                lastStatusDate = DateTime.Now,
                CreatedByUserID = CreatedByUserID,
            };

            var NewLicense = new clsLicenses();

            if (await NewApplication.SaveAsync())
            {
                NewLicense.ApplicationID = NewApplication.ID;
                NewLicense.DriverID = this.DriverID;
                NewLicense.LicenseClass = this.LicenseClass; 
                NewLicense.IssueDate = DateOnly.FromDateTime(DateTime.Now);
                NewLicense.ExpDate = DateOnly.FromDateTime(DateTime.Now.AddYears(this.ClassInfo.DefaultValidityLength));
                NewLicense.isActive = true;
                NewLicense.PaidFees = (decimal)this.ClassInfo.ClassFees;
                NewLicense.IssueReason = enIssueReason.Renew;
                NewLicense.Notes = Notes;
                NewLicense.CreatedByUserID = CreatedByUserID;

                if (await NewLicense.SaveAsync())
                {
                    await NewApplication.setCompletedAsync();
                    await DeactivateCurrentLicenseAsync();
                }
            }
            return NewLicense;
        }
        public async Task<clsLicenses> ReplaceAsync(enIssueReason reason, int CreatedByUserID)
        {
            var NewApplication = new clsApplication();
            var NewLicense = new clsLicenses();

            NewApplication.PersonID = this.DriverInfo.PersonID;
            NewApplication.Status = enStatus.New;
            NewApplication.TypeID = (reason == enIssueReason.DamagedReplacement ?
                (int)enApplicationType.DamagedReplacement :
                (int)enApplicationType.LostReplacement);
            NewApplication.PaidFees = clsApplicationTypes.FeeAsync((enApplicationType)NewApplication.TypeID).GetAwaiter().GetResult();
            NewApplication.Date = DateTime.Now;
            NewApplication.lastStatusDate = DateTime.Now;
            NewApplication.CreatedByUserID = CreatedByUserID;

            if (await NewApplication.SaveAsync())
            {
                
                NewLicense.ApplicationID = NewApplication.ID;
                NewLicense.DriverID = this.DriverID;
                NewLicense.LicenseClass = this.LicenseClass;
                NewLicense.IssueDate = DateOnly.FromDateTime(DateTime.Now);
                NewLicense.ExpDate = DateOnly.FromDateTime(DateTime.Now.AddYears(this.ClassInfo.DefaultValidityLength));
                NewLicense.isActive = true;
                NewLicense.PaidFees = (decimal)this.ClassInfo.ClassFees;
                NewLicense.IssueReason = reason; 
                NewLicense.Notes = Notes;
                NewLicense.CreatedByUserID = CreatedByUserID;

                if (await NewLicense.SaveAsync())
                {
                    await NewApplication.setCompletedAsync();
                    await DeactivateCurrentLicenseAsync();
                }
            }
            return NewLicense; 
        }
        public async Task<int> DetainAsync(decimal finefee, int CreatedByUserID)
        {
            int DetainID = -1;
            var DetainInfo = new clsDetainedLicenses();
            DetainInfo.DetainDate = DateOnly.FromDateTime(DateTime.Now);
            DetainInfo.FineFees = finefee;
            DetainInfo.isReleased = false;
            DetainInfo.CreatedByUserID = CreatedByUserID;
            DetainInfo.LicenseID = this.ID;

            if (await DetainInfo.SaveAsync())
            {
               await this.DeactivateCurrentLicenseAsync();
                DetainID = DetainInfo.ID; 
            }

            return DetainID; 
        }
        public async Task<bool> ReleaseLicenseAsync(int ReleasedByUserID)
        {
            if (!this.isDetained)
                return false;

            var detainInfo = await clsDetainedLicenses.FindByLicenseIDAsync(this.ID);
            var NewApplication = new clsApplication();
            NewApplication.PersonID = this.DriverInfo.PersonID;
            NewApplication.Status = enStatus.New;
            NewApplication.TypeID = (int)enApplicationType.ReleaseDetainedDL;
            NewApplication.Date = DateTime.Now;
            NewApplication.PaidFees = clsApplicationTypes.FeeAsync((enApplicationType)NewApplication.TypeID).GetAwaiter().GetResult(); 
            NewApplication.lastStatusDate = DateTime.Now;
            NewApplication.CreatedByUserID = ReleasedByUserID;
            if (await NewApplication.SaveAsync())
            {
                if (detainInfo != null)
                {
                    detainInfo.ReleaseApplicationID = NewApplication.ID;
                    detainInfo.isReleased = true;
                    detainInfo.ReleaseDate = DateOnly.FromDateTime(DateTime.Now);
                    detainInfo.ReleasedByUserID = ReleasedByUserID;

                    if (await detainInfo.SaveAsync())
                    {
                        await this.ActivateCurrentLicenseAsync();
                        await NewApplication.setCompletedAsync();
                        return true; 
                    }
                }
            }
            return false; 
        }
        public static async Task<bool> DeleteAsync(int licenseID)
        {
            return await LicensesData.DeleteAsync(licenseID); 
        }
        public static async Task<bool> isExistAsync(int LicenseID)
        {
            return await LicensesData.isExistAsync(LicenseID);
        }
    
        public static async Task<IEnumerable<_License>> ListAsync()
        {
            return await LicensesData.LicensesListAsync();
        }
    }
}
