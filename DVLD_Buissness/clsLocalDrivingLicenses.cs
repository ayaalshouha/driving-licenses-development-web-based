using DVLD_Data;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace DVLD_Buissness
{
    public class clsLocalDrivingLicenses 
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; }

        public clsApplication MainApplicationInfo {  get; set; }
        public int LicenseClassID { get; set; }

        public clsLicenseClasses LicenseClassesInfo { get; set; }

        public enum enMode { Add, Update };
        public enMode _Mode { get; set; }

        public clsLocalDrivingLicenses()
        {
            this.ID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
            this._Mode = enMode.Add; 

        }

        private clsLocalDrivingLicenses(stLocalDrivingLicensesApplication License)
        {
            this.ID = License.ID;
            this.ApplicationID = License.ApplicationID;
            this.LicenseClassID= License.LicenseClassID;
            MainApplicationInfo = clsApplication.Find(ApplicationID);
             LicenseClassesInfo = clsLicenseClasses.Find(this.LicenseClassID); 
            this._Mode = enMode.Update; 
        }

        public string FullName
        {
            get
            {
                return clsApplication.Find(ApplicationID).ApplicantFullName(); 
            } 
        }
        public static clsLocalDrivingLicenses Find(int Local_LicenseID)
        {
            stLocalDrivingLicensesApplication localLicense = new stLocalDrivingLicensesApplication();
            if (Local_DL_Data.getLocalLicenseInfo(Local_LicenseID, ref localLicense))
                return new clsLocalDrivingLicenses(localLicense);
            else
                return null;
        }

        public bool _AddNew()
        {
            stLocalDrivingLicensesApplication application = new stLocalDrivingLicensesApplication
            {
                ID = this.ID,
                ApplicationID = this.ApplicationID,
                LicenseClassID = this.LicenseClassID
            };

            this.ID = Local_DL_Data.Add(application);
            return this.ID != -1;
        }

        public bool _Update()
        {
            stLocalDrivingLicensesApplication application = new stLocalDrivingLicensesApplication
            {
                ID = this.ID,
                ApplicationID = this.ApplicationID,
                LicenseClassID = this.LicenseClassID
            };

            return Local_DL_Data.Update(application);
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

        public static bool Delete(int localAppID)
        {
            return Local_DL_Data.Delete(localAppID);
        }
        public bool isRepeatedClass(int personID)
        {
            return Local_DL_Data.isRepeatedClass(personID, this.LicenseClassID); 
        }
        public static DataTable List()
        {
            return Local_DL_Data.LocalApplicationsView();
        }

        public bool isTestPassed(clsTestTypes.enTestType TestType)
        {
            //decide if person passed specific test type or not 
            return Local_DL_Data.isTestPassed(this.ID, (int)TestType); 
        }
        public static DataTable NewStatus_List()
        {
            return Local_DL_Data.New_LocalApplicationsView();
        }
        public static DataTable CancelledStatus_List()
        {
            return Local_DL_Data.Cancelled_LocalApplicationsView();
        }
        public static DataTable CompletedStatus_List()
        {
            return Local_DL_Data.Completed_LocalApplicationsView();
        }
        public static int PassedTest(int LocalAppID)
        {
            //total passed test for the applicant
            return Local_DL_Data.getPassedTestCount(LocalAppID); 
        }

        public bool DoesPassedAllTest()
        {
            return (PassedTest(this.ID) == 3); 
        }

        public static bool DoesItCancelled(int MainApplicationID)
        {
            return Local_DL_Data.DoesItCancelled(MainApplicationID);
        }

        public static bool DoesItCompleted(int MainApplicationID)
        {
            return Local_DL_Data.DoesItCompleted(MainApplicationID);
        }
        public bool isLicenseIssued()
        {
            return (getLicenseID() != -1); 
        }

        public int getLicenseID()
        {
           //get ID if person has an active license of specific Class and -1 if he does NOT have one
            return LicensesData.GetActiveLicenseIDByPersonID(MainApplicationInfo.PersonID, this.LicenseClassID);
        }

        public clsTests GetLastTestPerTestType(clsTestTypes.enTestType Type)
        {
            //decide if there is a test record for the person , regardless the result 
            return clsTests.FindTestByPersonIDAndLicenseClass(MainApplicationInfo.PersonID, LicenseClassID, Type);
        }
        public bool DoesAttendTestType(clsTestTypes.enTestType Type)
        {
            //decide if the creation mode of appointment is a first time mode or a retake test mode 
            return Local_DL_Data.DoesAttendTestType(this.ID, (int)Type);
        }

        public bool setCancelled()
        {
            return ApplicationData.UpdateStatus(this.ApplicationID, 2);
        }

        public bool setCompleted()
        {
            return ApplicationData.UpdateStatus(this.ApplicationID, 3); 
        }
        public int IssueLicenseForTheFirstTime(int CreatedByUserID, string Notes)
        {
            int DriverID = -1; 
            clsDrviers Driver = clsDrviers.Find_ByPersonID(this.MainApplicationInfo.PersonID);

            if(Driver == null)
            {
                Driver = new clsDrviers();
                Driver.PersonID = this.MainApplicationInfo.PersonID;
                Driver.CreationDate = DateTime.Now;
                Driver.CreatedByUserID = CreatedByUserID;

                if (Driver.Save())
                {
                    DriverID = Driver.ID;
                }
            }
            else
            {
                DriverID = Driver.ID; 
            }

            clsLicenses New_License = new clsLicenses();

            New_License.ApplicationID = this.ApplicationID;
            New_License.DriverID = DriverID;
            New_License.IssueDate = DateTime.Now;
            New_License.LicenseClass = this.LicenseClassID;
            New_License.Notes = Notes;
            New_License.ExpDate = DateTime.Now.AddYears(this.LicenseClassesInfo.DefaultValidityLength);
            New_License.PaidFees = (decimal)this.LicenseClassesInfo.ClassFees;
            New_License.IssueReason = clsLicenses.enIssueReason.FirstTime;
            New_License.isActive = true;
            New_License.CreatedByUserID = CreatedByUserID;

            if (New_License.Save())
            {
                if (this.setCompleted())
                    return New_License.ID;
            }
           
            return -1;
        }

    } 
   

    
}

