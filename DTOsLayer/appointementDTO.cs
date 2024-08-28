using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class Appointement_
    {
        public int ID { get; set; }
        public DateOnly Date { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }

        public Appointement_(int id, DateOnly date, decimal fees, bool islocked)
        {
            this.Date= date;
            this.ID = id;
            this.PaidFees= fees;
            this.isLocked = islocked;
        }

    }
    public class Appointment_Veiw
    {
        public Appointement_ info;
        public int TestType { get; set; }
        public int LocalLicenseApplicationID { get; set; }

        public Appointment_Veiw(int testtype,int locallicenseid)
        {
            this.TestType = testtype;
            this.LocalLicenseApplicationID = locallicenseid;
        }

    }
    public class Appointment
    {
        public Appointment_Veiw appoint;
        public int CreatedByUserID { get; set; }
        public int RetakeTestID { get; set; }

        public Appointment(int createdby, int retaketestid)
        {
            this.RetakeTestID = retaketestid;
            this.CreatedByUserID = createdby;
        }
    }

    
}
