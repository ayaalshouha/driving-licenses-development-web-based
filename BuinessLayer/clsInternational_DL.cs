using DataLayer;
using DTOsLayer;
using System;
using System.Data;

namespace BuisnessLayer
{
    public class clsInternational_DL
    {
        public enMode _Mode { get; set; }
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication MainApplicationInfo { get; set; }
        public int DriverID { get; set; }
        public clsDrviers DriverInfo { get; set; }
        public int IssuedByLocalLicenseID { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpDate { get; set; }
        public bool isActive { get; set; }
        public int CreatedByUserID { get; set; }
        public InternationalLicense internationalLicenseDTO
        {
            get
            {
                return new InternationalLicense(this.ID, this.ApplicationID, this.DriverID, this.IssuedByLocalLicenseID, 
                    this.IssueDate, this.ExpDate, this.isActive, this.CreatedByUserID);
            }
        }
        public clsInternational_DL()
        {
            this.ID = -1; 
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedByLocalLicenseID = -1;
            this.IssueDate = DateOnly.FromDateTime(DateTime.Now); 
            this.ExpDate = DateOnly.FromDateTime(DateTime.Now);
            this.isActive = false;
            this.CreatedByUserID = -1;
            _Mode = enMode.add; 
        }
        private clsInternational_DL(InternationalLicense license)
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
            _Mode = enMode.update;
        }
        public static async Task<clsInternational_DL> FindAsync(int ApplicationID)
        {
            InternationalLicense application = await International_DL_Data.getApplicationInfoAsync(ApplicationID);
            if (application != null)
                return new clsInternational_DL(application);
            else
                return null;
        }
        public async Task<bool> _AddNewAsync()
        {
            this.ID = await International_DL_Data.AddAsync(internationalLicenseDTO);
            return this.ID != -1;
        }
        public async Task<bool> _UpdateAsync()
        {
            return await International_DL_Data.UpdateAsync(internationalLicenseDTO);
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
        public static async Task<IEnumerable<InternationalLicense>> ListAsync()
        {
            return await International_DL_Data.ListAsync();
        }
    
        public static async Task<bool> isExist(int licenseID)
        {
            return await International_DL_Data.isExistAsync(licenseID);
        }
    }
}
