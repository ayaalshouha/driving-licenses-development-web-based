using DVLD_Data;
using System;
using System.Data;

namespace DVLD_Buissness
{
    public class clsDetainedLicenses
    {
        private enum enMode { Add = 1, Update }
        private enMode _Mode = enMode.Add;

        public int ID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public int LicenseID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DetainDate { get; set; }
        public bool isReleased { get; set; }
        public decimal FineFees { get; set; }
        public int ReleasedByUserID { get; set; }
        public clsUser ReleasedByUserInfo {  get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }


        public clsDetainedLicenses()
        {
            this.ID = -1;
            this.LicenseID = -1;
            this.CreatedByUserID = -1;
            this.isReleased =false;
            this.DetainDate = DateTime.MinValue;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.FineFees = -1;
            this.ReleaseApplicationID = -1;
           
            this._Mode = enMode.Add;
        }

        private clsDetainedLicenses(stDetainedLicenses license)
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
            this._Mode = enMode.Update;
        }
        public static clsDetainedLicenses Find(int DetainID)
        {
            stDetainedLicenses license = new stDetainedLicenses();
            if (DetainedLicenses_Data.getDetainedLicenseInfo(DetainID, ref license))
                return new clsDetainedLicenses(license);
            else
                return null;
        }

        public static clsDetainedLicenses FindByLicenseID(int licenseID)
        {
            stDetainedLicenses license = new stDetainedLicenses();
            if (DetainedLicenses_Data.getDetainedInfoByLicenseID(licenseID, ref license))
                return new clsDetainedLicenses(license);
            else
                return null;
        }

        public bool _AddNew()
        {
            stDetainedLicenses license = new stDetainedLicenses
            {
                ID = this.ID,
                LicenseID = this.LicenseID,
                DetainDate = this.DetainDate,
                isReleased = this.isReleased,
                ReleaseApplicationID = this.ReleaseApplicationID,
                ReleasedByUserID = this.ReleasedByUserID,
                CreatedByUserID = this.CreatedByUserID,
                FineFees = this.FineFees,
                ReleaseDate = this.ReleaseDate
            };

            this.ID = DetainedLicenses_Data.Add(license);
            return this.ID != -1;
        }

        public bool _Update()
        {
            stDetainedLicenses license = new stDetainedLicenses
            {
                ID = this.ID,
                LicenseID = this.LicenseID,
                DetainDate = this.DetainDate,
                isReleased = this.isReleased,
                ReleaseApplicationID = this.ReleaseApplicationID,
                ReleasedByUserID = this.ReleasedByUserID,
                CreatedByUserID = this.CreatedByUserID,
                FineFees = this.FineFees,
                ReleaseDate = this.ReleaseDate
            };

            return DetainedLicenses_Data.Update(license);
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

        public static bool isLicenseDetained(int LicenseID)
        {
            return DetainedLicenses_Data.isLicenseDetained(LicenseID);
        }
        public static DataTable List()
        {
            return DetainedLicenses_Data.DetainedLicesesList();
        }
    }
}
