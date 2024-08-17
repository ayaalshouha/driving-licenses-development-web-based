using DVLD_Data;
using System;
using System.Collections.Generic;

namespace DVLD_Buissness
{
    public class clsLicenseClasses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public byte MinimumAllowedAge { set; get; }
        public byte DefaultValidityLength { set; get; }
        public decimal ClassFees { set; get; }

        public clsLicenseClasses()

        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = 0;

            Mode = enMode.AddNew;

        }

        public clsLicenseClasses(stLicenseClass licenseClass)

        {
            this.LicenseClassID = licenseClass.ID;
            this.ClassName = licenseClass.ClassName;
            this.ClassDescription = licenseClass.Description;
            this.MinimumAllowedAge = licenseClass.MinAgeAllowed;
            this.DefaultValidityLength = licenseClass.ValidityYears;
            this.ClassFees = licenseClass.Fees;
            Mode = enMode.Update;
        }


        public static clsLicenseClasses Find(int ClassID)
        {
            stLicenseClass stClass = new stLicenseClass();
             if(LicenseClassesData.getClassInfo(ClassID, ref stClass))
                return new clsLicenseClasses(stClass);
            else
                return null;
        }

        public static List<string> ClassesNames()
        {
            return LicenseClassesData.getAllClassesName();
        }
    }
}
