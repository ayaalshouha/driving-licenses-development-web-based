using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class _License
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpDate { get; set; }
        public bool isActive { get; set; }
        public decimal PaidFees { get; set; }
        public int IssueReason { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public _License(int id, int applicationId, int driverId, int licenseClass,
            DateOnly issueDate, DateOnly expDate, bool isActive, decimal paidFees,
            int issueReason, string notes, int createdByUserId)
        {
            this.ID = id;
            this.ApplicationID = applicationId;
            this.DriverID = driverId;
            this.LicenseClass = licenseClass;
            this.IssueDate = issueDate;
            this.ExpDate = expDate;
            this.isActive = isActive;
            this.PaidFees = paidFees;
            this.IssueReason = issueReason;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserId;
        }

    }
}
