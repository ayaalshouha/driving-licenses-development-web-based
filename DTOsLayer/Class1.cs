﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
    public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
    public enum enMode { add, update }
    public enum enStatus : int { New = 1, cancelled, completed }
    public enum enApplicationType : int
    {
        NewLocalDL = 1, RenewDL = 2, LostReplacement = 3,
        DamagedReplacement = 4, ReleaseDetainedDL = 5, NewInternationalDL = 6, RetakeTest = 7
    }
    public class Driver
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedByUserID { get; set; }

        public Driver(int id, int personId, DateTime creationDate, int createdByUserId)
        {
            this.ID = id;
            this.PersonID = personId;
            this.CreationDate = creationDate;
            this.CreatedByUserID = createdByUserId;
        }
    }
    public class DetainedLicenses
    {
        public int ID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public int LicenseID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DetainDate { get; set; }
        public bool isReleased { get; set; }
        public decimal FineFees { get; set; }
        public int ReleasedByUserID { get; set; }
        public int CreatedByUserID { get; set; }

        public DetainedLicenses(int id, int releaseappid, int licensesid, DateTime releasedate, DateTime detaindate, bool isreleased
            , decimal fee, int releasedby, int createdby)
        {
            this.ID = id;
            this.ReleaseApplicationID = releaseappid;
            this.LicenseID = licensesid;
            this.ReleaseDate = releasedate;
            this.CreatedByUserID = createdby;
            this.ReleasedByUserID = releasedby;
            this.FineFees = fee;
            this.isReleased = isreleased;
        }

    }  
    public class InternationalLicenses
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedByLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpDate { get; set; }
        public bool isActive { get; set; }
        public int CreatedByUserID { get; set; }

        public InternationalLicenses(int id, int appid, int driverid, int issuedbylocalid, DateTime issuedate, DateTime expdate, bool isactive, int createdby)
        {
            this.ID = id;
            this.ApplicationID = appid;
            this.DriverID = driverid;
            this.IssuedByLocalLicenseID = issuedbylocalid;
            this.isActive = isactive;
            this.ExpDate = expdate;
            this.IssueDate = issuedate;
            this.CreatedByUserID = createdby;
        }
    }
    public class Appointment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int TestType { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }
        public int CreatedByUserID { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public int RetakeTestID { get; set; }

        public Appointment(int id, DateTime date, int testtype, decimal paidfees, bool islocked, int createdby, int locallicenseid, int retaketestid)
        {
            this.isLocked = islocked;
            this.ID = id;
            this.Date = date;
            this.TestType = testtype;
            this.RetakeTestID = retaketestid;
            this.CreatedByUserID = createdby;
            this.PaidFees = paidfees;
            this.LocalLicenseApplicationID = locallicenseid;
        }

    }
    

}

