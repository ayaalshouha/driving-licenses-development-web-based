using DataLayer;
using System;
using System.Data;
using DTOsLayer;

namespace BuisnessLayer
{
    public class clsDrviers
    {
        private enMode _Mode = enMode.add;
        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public DateOnly CreationDate { get; set; }
        public int CreatedByUserID { get; set; }
        public Driver DriverDTO{
            get
            {
                return new Driver(this.ID, this.PersonID, this.CreationDate, this.CreatedByUserID);
            }
        }
        public clsDrviers()
        {
            this.ID = -1; 
            this.PersonID = -1;
            this.CreationDate = DateOnly.FromDateTime(DateTime.Now);
            this.CreatedByUserID = -1;
            _Mode = enMode.add; 
        }
        private clsDrviers(Driver driver)
        {
            this.ID = driver.ID;
            this.PersonID = driver.PersonID;
            this.CreationDate = driver.CreationDate;
            this.CreatedByUserID = driver.CreatedByUserID;
            this.PersonInfo = clsPerson.Find(PersonID);
            _Mode = enMode.update;
        }
        public static async Task<clsDrviers> Find_ByPersonIDAsync(int PersonID)
        {
            Driver driver = await DriverData.getDriverInfo_ByPersonIDAsync(PersonID);
            if (driver != null)
                return new clsDrviers(driver);
            else return null;
        }
        public static async Task<clsDrviers> FindAsync(int DriverID)
        {
            Driver driver = await DriverData.getDriverInfo_ByIDAsync(PersonID);
            if (driver != null)
                return new clsDrviers(driver);
            else return null;
        }
        private async Task<bool> _AddNewAsync()
        {
            this.ID = await DriverData.AddAsync(DriverDTO);   
            return this.ID != -1;
        }
        private async Task<bool> _UpdateAsync()
        {
            return await DriverData.UpdateAsync(DriverDTO);
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
        public static async Task<bool> DeleteAsync(int ID)
        {
            return await DriverData.DeleteAsync(ID);
        }
        public static async Task<IEnumerable<Driver>> ListAsync()
        {
            return await DriverData.ListAsync();
        }
        public static async Task<IEnumerable<ActiveLicense>> getLocalLicensesAsync(int DriverID)
        {
            return await DriverData.getActiveLicensesAsync(DriverID);
        }
        public static async Task<IEnumerable<DriverInterNationalLicense>> getInternationalLicenses(int DriverID)
        {
            return await DriverData.getInternationalLicensesAsync(DriverID);
        }
        public static async Task<int> getActiveLicenseIDAsync(int DriverID)
        {
            return await DriverData.GetActiveLicenseIDAsync(DriverID);
        }

    }
}
