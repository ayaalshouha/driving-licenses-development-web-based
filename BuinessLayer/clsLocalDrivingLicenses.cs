using DataLayer;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using DTOsLayer; 

namespace BuisnessLayer
{  
    public class clsLocalDrivingLicenses
    {
        public enMode _Mode { get; set; }
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsApplication MainApplicationInfo { get; set; }
        public clsLicenseClasses LicenseClassesInfo { get; set; }
        public LocalDLApp LocalDLAppDTO
        {
            get{
                return new LocalDLApp(this.ID, this.ApplicationID, this.LicenseClassID);
            }
        }
        public clsLocalDrivingLicenses()
        {
            this.ID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
            this._Mode = enMode.add; 

        }
        private clsLocalDrivingLicenses(LocalDLApp License)
        {
            this.ID = License.ID;
            this.ApplicationID = License.ApplicationID;
            this.LicenseClassID= License.LicenseClassID;
            MainApplicationInfo =  clsApplication.Find(ApplicationID);
             LicenseClassesInfo = clsLicenseClasses.Find(this.LicenseClassID); 
            this._Mode = enMode.update; 
        }
        public async Task<string> FullNameAsync()
        {
            clsApplication applicant = await clsApplication.FindAsync(ApplicationID); 
             return await applicant.ApplicantFullNameAsync(); 
        }
        public static async Task<clsLocalDrivingLicenses> FindAsync(int Local_LicenseID)
        {
            LocalDLApp localLicense = await Local_DL_Data.getLocalLicenseInfoAsync(Local_LicenseID);
            if (localLicense != null)
                return new clsLocalDrivingLicenses(localLicense);
            else
                return null;
        }
        public async Task<bool> _AddNewAsync()
        {
            this.ID = await Local_DL_Data.AddAsync(LocalDLAppDTO);
            return this.ID != -1;
        }
        public async Task<bool> _UpdateAsync()
        {
            return await Local_DL_Data.UpdateAsync(LocalDLAppDTO);
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
        public static async Task<bool> DeleteAsync(int localAppID)
        {
            return await Local_DL_Data.DeleteAsync(localAppID);
        }
        //public async Task<bool> isRepeatedClassAsync(int personID)
        //{
        //    return await Local_DL_Data.isRepeatedClassAsync(personID, this.LicenseClassID); 
        //}
        public static async Task<IEnumerable<LocalDLApp_View>> ListAsync()
        {
            return await Local_DL_Data.LocalApplicationsViewAsync();
        }
        public async Task<bool> isTestPassedAsync(enTestType TestType)
        {
            //decide if person passed specific test type or not 
            return await Local_DL_Data.isTestPassedAsync(this.ID, (int)TestType); 
        }
        public static async Task<IEnumerable<LocalDLApp_View>> NewStatus_List()
        {
            return await Local_DL_Data.New_LocalApplicationsViewAsync();
        }
        public static async Task<IEnumerable<LocalDLApp_View>> CancelledStatus_List()
        {
            return await Local_DL_Data.Cancelled_LocalApplicationsViewAsync();
        }
        public static async Task<IEnumerable<LocalDLApp_View>> CompletedStatus_List()
        {
            return await Local_DL_Data.Completed_LocalApplicationsViewAsync();
        }
        public static async Task<int> PassedTestAsync(int LocalAppID)
        {
            //total passed test for the applicant
            return await Local_DL_Data.getPassedTestCountAsync(LocalAppID); 
        }
        public async Task<bool> isAllTestsPassed()
        {
            return (await PassedTestAsync(this.ID) == 3); 
        }
        public static async Task<bool> DoesItCancelledAsync(int MainApplicationID)
        {
            return await Local_DL_Data.DoesItCancelledAsync(MainApplicationID);
        }
        public static async Task<bool> DoesItCompletedAsync(int MainApplicationID)
        {
            return await Local_DL_Data.DoesItCompletedAsync(MainApplicationID);
        }
        public async Task<bool> isLicenseIssuedAsync()
        {
            int id = await getLicenseIDAsync();
            return (id != -1); 
        }
        public async Task<int> getLicenseIDAsync()
        {
           //get ID if person has an active license of specific Class and -1 if he does NOT have one
            return await LicensesData.GetActiveLicenseIDByPersonIDAsync(MainApplicationInfo.PersonID, this.LicenseClassID);
        }
        public async Task<clsTests> GetLastTestPerTestTypeAsync(enTestType Type)
        {
            //decide if there is a test record for the person , regardless the result 
            return await clsTests.FindTestByPersonIDAndLicenseClassAsync(MainApplicationInfo.PersonID, LicenseClassID, Type);
        }            
        public async Task<bool> DoesAttendTestTypeAsync(enTestType Type)
        {
            //decide if the creation mode of appointment is a first time mode or a retake test mode 
            return await Local_DL_Data.DoesAttendTestTypeAsync(this.ID, (int)Type);
        }        
        public async Task<bool> setCancelledAsync()
        {
            return await ApplicationData.UpdateStatusAsync(this.ApplicationID, 2);
        }
        public async Task<bool> setCompletedAsync()
        {
            return await ApplicationData.UpdateStatusAsync(this.ApplicationID, 3); 
        }
        public async Task<int> IssueLicenseForTheFirstTime(int CreatedByUserID, string Notes)
        {
            int DriverID = -1; 
            clsDrviers Driver = await clsDrviers.Find_ByPersonIDAsync(this.MainApplicationInfo.PersonID);

            if(Driver == null)
            {
                Driver = new clsDrviers();
                Driver.PersonID = this.MainApplicationInfo.PersonID;
                Driver.CreationDate = DateOnly.FromDateTime(DateTime.Now);
                Driver.CreatedByUserID = CreatedByUserID;

                if (await Driver.SaveAsync())
                    DriverID = Driver.ID;
            }
            else
                DriverID = Driver.ID; 



            clsLicenses New_License = new clsLicenses();

            New_License.ApplicationID = this.ApplicationID;
            New_License.DriverID = DriverID;
            New_License.IssueDate = DateOnly.FromDateTime(DateTime.Now);
            New_License.LicenseClass = this.LicenseClassID;
            New_License.Notes = Notes;
            New_License.ExpDate = DateOnly.FromDateTime(DateTime.Now.AddYears(this.LicenseClassesInfo.DefaultValidityLength));
            New_License.PaidFees = (decimal)this.LicenseClassesInfo.ClassFees;
            New_License.IssueReason = enIssueReason.FirstTime;
            New_License.isActive = true;
            New_License.CreatedByUserID = CreatedByUserID;

            if (await New_License.SaveAsync())
            {
                if (await this.setCompletedAsync())
                    return New_License.ID;
            }
           
            return -1;
        }
        public static async Task<bool> isExistAsync(int appID)
        {
            return await Local_DL_Data.isExistAsync(appID);
        }
    }
}

