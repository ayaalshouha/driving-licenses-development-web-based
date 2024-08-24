using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class DetainedLicense
    {
        public int ID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public int LicenseID { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly DetainDate { get; set; }
        public bool isReleased { get; set; }
        public decimal FineFees { get; set; }
        public int ReleasedByUserID { get; set; }
        public int CreatedByUserID { get; set; }
        public DetainedLicense(int id, int releaseappid, int licensesid,
            DateOnly releasedate, DateOnly detaindate, bool isreleased
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
}
