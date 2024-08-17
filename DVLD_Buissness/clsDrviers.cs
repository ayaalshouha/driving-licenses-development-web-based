using DVLD_Data;
using System;
using System.Data;

namespace DVLD_Buissness
{
    public class clsDrviers
    {

        public int ID { get; set; }
        public int PersonID { get; set; }

        public clsPerson PersonInfo;
        public DateTime CreationDate { get; set; }
        public int CreatedByUserID { get; set; }
        private enum enMode { Add, Update };
        private enMode _Mode = enMode.Add;

       public clsDrviers()
        {
            this.ID = -1; 
            this.PersonID = -1;
            this.CreationDate = DateTime.Now;
            this.CreatedByUserID = -1;
            _Mode = enMode.Add; 
        }

        private clsDrviers(stDriver driver)
        {
            this.ID = driver.ID;
            this.PersonID = driver.PersonID;
            this.CreationDate = driver.CreationDate;
            this.CreatedByUserID = driver.CreatedByUserID;
            this.PersonInfo = clsPerson.Find(PersonID);
            _Mode = enMode.Update;
        }

        public static clsDrviers Find_ByPersonID(int PersonID)
        {
            stDriver driver = new stDriver();
            if (DriverData.getDriverInfo_ByPersonID(PersonID, ref driver))
                return new clsDrviers(driver);
            else return null;
        }

        public static clsDrviers Find(int DriverID)
        {
            stDriver driver = new stDriver();
            if (DriverData.getDriverInfo_ByID(DriverID, ref driver))
                return new clsDrviers(driver);
            else return null;
        }

        private bool _AddNew()
        {
            stDriver driver = new stDriver
            {
                PersonID = this.PersonID,
                CreatedByUserID = this.CreatedByUserID,
                CreationDate = this.CreationDate,
            };

            this.ID = DriverData.Add(driver);   
            return this.ID != -1;
        }

        private bool _Update()
        {
            stDriver driver = new stDriver
            {
                ID = this.ID,
                PersonID = this.PersonID,
                CreatedByUserID = this.CreatedByUserID,
                CreationDate = this.CreationDate
            };

            return DriverData.Update(driver);
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

        public static bool Delete(int ID)
        {
            return DriverData.Delete(ID);
        }

        public static DataTable DriversList()
        {
            return DriverData.List();
        }

        public static DataTable getLocalLicenses(int DriverID)
        {
            return DriverData.getActiveLicenses(DriverID);
        }

        public static DataTable getInternationalLicenses(int DriverID)
        {
            return DriverData.getInternationalLicenses(DriverID);
        }
    }
}
