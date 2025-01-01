using DataLayer;
using System;
using DTOsLayer;
namespace BuisnessLayer
{
    public class clsTests
    {
        public enMode _Mode { get; set; }
        public int ID { get; set; }
        public int AppointmentID { get; set; }
        public clsAppointment AppointmentInfo { get; set; }
        public bool Result { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public Test testDTO
        {
            get
            {
                return new Test(this.ID, this.AppointmentID, this.Result, this.Notes, this.CreatedByUserID);
            }
        }
        public clsTests()
        {
            this.ID = -1; 
            this.AppointmentID = -1;
            this.Notes = string.Empty;
            this.Result = false;
            this.CreatedByUserID = -1;
            this._Mode = enMode.add;
        }

        private clsTests(Test test)
        {
            this.ID=test.ID;
            this.AppointmentID = test.AppointmentID;
            AppointmentInfo = clsAppointment.FindAsync(AppointmentID).GetAwaiter().GetResult();
            this.Notes = test.Notes;
            this.CreatedByUserID=test.CreatedByUserID;
            this.Result= test.Result;
            this._Mode = enMode.update;
        }
        public static async Task<clsTests> FindAsync(int testID)
        {
            Test test = await Tests_Data.getTestInfoAsync(testID);
            if (test != null)
                return new clsTests(test);
            else
                return null;
        }
        public static async Task<clsTests> FindTestByPersonIDAndLicenseClassAsync(int personID, int LicenseCLassID,enTestType TestType)
        {
            Test Test = await Tests_Data.GetLastTestPerTestTypeAsync(personID, LicenseCLassID, (int)TestType);
            if(Test != null)
                return new clsTests(Test); 
            return null; 
        }
        public async Task<bool> _AddNewAsync()
        {
            this.ID = await Tests_Data.AddAsync(testDTO);
            return this.ID != -1;
        }
        public async Task<bool> _UpdateAsync()
        {
            return await Tests_Data.UpdateAsync(testDTO);
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

        public static async Task<bool> isExistAsync(int TestID)
        {
            return await Tests_Data.isExistAsync(TestID);
        }
        public static async Task<bool> DeleteAsync(int TestID)
        {
            return await Tests_Data.DeleteAsync(TestID);
        }
        public static async Task<IEnumerable<Test>> getAllAsync()
        {
            return await Tests_Data.getTestsTableAsync();
        }
        public static async Task<int> passedTestsCount()
        {
            return await Tests_Data.passedTestCount();
        }
        public static async Task<int> failedTestsCount()
        {
            return await Tests_Data.failedTestCount();
        }
        public static async Task<int> TotalCount()
        {
            int passed = await passedTestsCount();
            int failed = await failedTestsCount();
            int total = passed + failed;
            return total;
        }
        public static async Task<int> PassedPercentage()
        {
            int passed = await passedTestsCount();
            int total = await TotalCount();
            double percentage = (passed / (double)total) * 100;
            return (int)percentage;
        }
        public static async Task<int> FailedPercentage()
        {
            int failed = await failedTestsCount();
            int total = await TotalCount();
            double percentage = (failed / (double)total) * 100;
            return (int)percentage;
        }
        public static async Task<int> count()
        {
            return await Tests_Data.TestsCount();
        }
    }
}
