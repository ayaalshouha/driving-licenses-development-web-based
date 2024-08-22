using DataLayer;
using DTOsLayer;
using System;
using System.Collections.Generic;

namespace BuisnessLayer
{
    public class clsLicenseClasses
    {
        public enMode Mode = enMode.AddNew;
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

        public clsLicenseClasses(stLicenseClass licenseClass)

        {
            this.LicenseClassID = licenseClass.ID;
            this.ClassName = licenseClass.ClassName;
            this.ClassDescription = licenseClass.Description;
            this.MinimumAllowedAge = licenseClass.MinAgeAllowed;
            this.DefaultValidityLength = licenseClass.ValidityYears;
            this.ClassFees = licenseClass.Fees;
            Mode = enMode.update;
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
