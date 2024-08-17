using DVLD_Data;
using System;
namespace DVLD_Buissness
{
    public class clsTests
    {
        public int ID { get; set; }
        public int AppointmentID { get; set; }
        public clsAppointment AppointmentInfo { get; set; }
        public bool Result { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public enum enMode { Add, Update };
        public enMode _Mode { get; set; }

        public clsTests()
        {
            this.ID = -1; 
            this.AppointmentID = -1;
            this.Notes = string.Empty;
            this.Result = false;
            this.CreatedByUserID = -1;
            this._Mode = enMode.Add;
        }

        private clsTests(stTests test)
        {
            this.ID=test.ID;
            this.AppointmentID = test.AppointmentID;
            AppointmentInfo = clsAppointment.Find(AppointmentID);
            this.Notes = test.Notes;
            this.CreatedByUserID=test.CreatedByUserID;
            this.Result= test.Result;
            this._Mode = enMode.Update;
        }

        public static clsTests Find(int testID)
        {
            stTests test = new stTests();
            if (Tests_Data.getTestInfo(testID, ref test))
                return new clsTests(test);
            else
                return null;
        }
        public static clsTests FindTestByPersonIDAndLicenseClass(int personID, int LicenseCLassID, clsTestTypes.enTestType TestType)
        {
            stTests Test = new stTests();
            if(Tests_Data.GetLastTestPerTestType(personID,LicenseCLassID, (int)TestType, ref Test))
            {
                return new clsTests(Test); 
            }
            return null; 
        }

        public bool _AddNew()
        {
            stTests test = new stTests()
            {
                ID = this.ID,
                AppointmentID= this.AppointmentID,
                Result = this.Result,
                Notes = this.Notes,
                CreatedByUserID = this.CreatedByUserID
            };

            this.ID = Tests_Data.Add(test);
            return this.ID != -1;
        }

        public bool _Update()
        {
            stTests test = new stTests()
            {
                ID = this.ID,
                AppointmentID = this.AppointmentID,
                Result = this.Result,
                Notes = this.Notes,
                CreatedByUserID = this.CreatedByUserID
            };

            return Tests_Data.Update(test);
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

    }
}
