using DataLayer;
using DTOsLayer;
using System;
using System.Collections.Generic;

namespace BuisnessLayer
{
    public class clsLicenseClasses
    {
        public enMode Mode = enMode.add;
        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public byte MinimumAllowedAge { set; get; }
        public byte DefaultValidityLength { set; get; }
        public decimal ClassFees { set; get; }

        public LicenseClass licenseDTO
        {
            get
            {
                return new LicenseClass(this.LicenseClassID, this.ClassName,
                    this.ClassDescription, this.ClassFees,
                    this.MinimumAllowedAge, this.DefaultValidityLength);
            }
        }
        public clsLicenseClasses()

        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = 0;

            Mode = enMode.add;

        }

        public clsLicenseClasses(LicenseClass licenseClass)

        {
            this.LicenseClassID = licenseClass.ID;
            this.ClassName = licenseClass.ClassName;
            this.ClassDescription = licenseClass.Description;
            this.MinimumAllowedAge = licenseClass.MinAgeAllowed;
            this.DefaultValidityLength = licenseClass.ValidityYears;
            this.ClassFees = licenseClass.Fees;
            Mode = enMode.update;
        }

        public static async Task<clsLicenseClasses> FindAsync(int ClassID)
        {
            LicenseClass Class = await LicenseClassesData.getClassInfoAsync(ClassID);
             if(Class != null)
                return new clsLicenseClasses(Class);
            else
                return null;
        }
        public static clsLicenseClasses Find(int ClassID)
        {
            LicenseClass Class =  LicenseClassesData.getClassInfo(ClassID);
            if (Class != null)
                return new clsLicenseClasses(Class);
            else
                return null;
        }

        public static async Task<List<string>> ClassesNames()
        {
            return await LicenseClassesData.getAllClassesNameAsync();
        }
    }
}
