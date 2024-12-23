﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class _Application
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public enStatus Status { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
        public decimal PaidFees { get; set; }
        public DateTime lastStatusDate { get; set; }
        public int CreatedByUserID { get; set; }

        public _Application(int id, int personId, enStatus status, int type, DateTime date, decimal paidFees, DateTime lastStatusDate, int createdByUserId)
        {
            this.ID = id;
            this.PersonID = personId;
            this.Status = status;
            this.Type = type;
            this.Date = date;
            this.PaidFees = paidFees;
            this.lastStatusDate = lastStatusDate;
            this.CreatedByUserID = createdByUserId;
        }

    }
}
