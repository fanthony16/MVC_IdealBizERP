using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblEmployeeActivities = new HashSet<TblEmployeeActivity>();
        }

        public int IntEmployeeId { get; set; }
        public string TxtEmployeeCode { get; set; }
        public string TxtName { get; set; }
        public string TxtAddress { get; set; }
        public string TxtTelephone { get; set; }
        public string TxtAltTelephone { get; set; }
        public string TxtRole { get; set; }
        public string TxtPaymentMode { get; set; }
        public string TxtNokname { get; set; }
        public string TxtNoktelephone { get; set; }
        public string TxtNokrelationship { get; set; }
        public DateTime? DteCreated { get; set; }
        public int? IntCompanyId { get; set; }

        public virtual ICollection<TblEmployeeActivity> TblEmployeeActivities { get; set; }
    }
}
