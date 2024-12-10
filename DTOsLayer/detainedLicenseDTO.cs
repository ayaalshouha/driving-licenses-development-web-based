using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class DetainedLicense
    {
        public int ID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool isReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }
        public DetainedLicense(int id, int? releaseappid, int licensesid,
            DateTime? releasedate, DateTime detaindate, bool isreleased
            , decimal fee, int? releasedby, int createdby)
        {
            this.ID = id;
            this.ReleaseApplicationID = releaseappid;
            this.LicenseID = licensesid;
            this.ReleaseDate = releasedate;
            this.CreatedByUserID = createdby;
            this.ReleasedByUserID = releasedby;
            this.FineFees = fee;
            this.isReleased = isreleased;
            this.DetainDate = detaindate;
        }

    }
    public class DetainedLicense_View
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public bool isReleased { get; set; }
        public decimal FineFees { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string NationalNo { get; set; }
        public int? ReleaseApplicationID { get; set; }
        public DetainedLicense_View(int id, int? releaseappid, int licensesid,
            DateTime? releasedate, DateTime detaindate, bool isreleased
            , decimal fee, string nationalNo, string fullname)
        {
            this.ID = id;
            this.ReleaseApplicationID = releaseappid;
            this.LicenseID = licensesid;
            this.ReleaseDate = releasedate;
            this.FullName = fullname;
            this.NationalNo = nationalNo;
            this.FineFees = fee;
            this.isReleased = isreleased;
            this.DetainDate = detaindate;
        }

    }

}
