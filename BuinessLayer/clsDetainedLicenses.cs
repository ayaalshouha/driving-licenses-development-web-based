using DataLayer;
using System;
using System.Data;
using DTOsLayer; 

namespace BuisnessLayer
{
    public class clsDetainedLicenses
    {
        private enMode _Mode = enMode.add;
        public int ID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public int LicenseID { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly DetainDate { get; set; }
        public bool isReleased { get; set; }
        public decimal FineFees { get; set; }
        public int ReleasedByUserID { get; set; }
        public clsUser ReleasedByUserInfo {  get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public DetainedLicense DetainedLicenseDTO
        {
            get
            {
                return new DetainedLicense(this.ID, this.ReleaseApplicationID, this.LicenseID,
                    this.ReleaseDate, this.DetainDate, this.isReleased,
                    this.FineFees, this.ReleasedByUserID, this.CreatedByUserID); 
            }
        }
        public clsDetainedLicenses()
        {
            this.ID = -1;
            this.LicenseID = -1;
            this.CreatedByUserID = -1;
            this.isReleased =false;
            this.DetainDate = DateOnly.FromDateTime(DateTime.MinValue);
            this.ReleaseDate = DateOnly.FromDateTime(DateTime.MinValue);
            this.ReleasedByUserID = -1;
            this.FineFees = -1;
            this.ReleaseApplicationID = -1;
           
            this._Mode = enMode.add;
        }
        private clsDetainedLicenses(DetainedLicense license)
        {
            this.ID = license.ID;
            this.LicenseID = license.LicenseID;
            this.DetainDate = license.DetainDate;
            this.CreatedByUserID = license.CreatedByUserID;
            this.isReleased = license.isReleased;
            this.ReleaseApplicationID = license.ReleaseApplicationID;
            this.ReleaseDate = license.ReleaseDate;
            this.ReleasedByUserID = license.ReleasedByUserID;
            this.FineFees = license.FineFees;
            this.ReleasedByUserInfo = clsUser.Find(ReleasedByUserID);
            this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);
            this._Mode = enMode.update;
        }
        public static async Task<clsDetainedLicenses> FindAsync(int DetainID)
        {
            var license = await DetainedLicenses_Data.getDetainedLicenseInfoAsync(DetainID);
            if (license != null)
                return new clsDetainedLicenses(license);
            else
                return null;
        }
        public static async Task<clsDetainedLicenses> FindByLicenseIDAsync(int licenseID)
        {
            var license = await DetainedLicenses_Data.getDetainedInfoByLicenseIDAsync(licenseID);
            if (license != null)
                return new clsDetainedLicenses(license);
            else
                return null;
        }
        public async Task<bool> _AddNewAsync()
        {
            this.ID = await DetainedLicenses_Data.AddAsync(DetainedLicenseDTO);
            return this.ID != -1;
        }
        public async Task<bool> _UpdateAsync()
        {
            return await DetainedLicenses_Data.UpdateAsync(DetainedLicenseDTO); 
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
        public static async Task<bool> isLicenseDetainedAsync(int LicenseID)
        {
            bool result = await DetainedLicenses_Data.isLicenseDetainedAsync(LicenseID);
            return result;
        }
        public static async Task<IEnumerable<DetainedLicense>> ListAsync()
        {
            return await DetainedLicenses_Data.DetainedLicesesListAsync();
        }
    
        public static async Task<bool> isExistAsync(int detainID)
        {
            bool result = await DetainedLicenses_Data.isExistAsync(detainID);
            return result;
        }
        public static async Task<bool> DeleteAsync(int detainID)
        {
            return await DetainedLicenses_Data.DeleteAsync(detainID);
        }
    }
}
