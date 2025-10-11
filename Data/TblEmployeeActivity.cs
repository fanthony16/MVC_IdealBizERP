using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblEmployeeActivity
    {
        public int IntActivityId { get; set; }
        public int? IntWorkItemId { get; set; }
        public int? IntEmployeeId { get; set; }
        public int? IntActivityType { get; set; }
        public int? IntQuantity { get; set; }
        public DateTime? DteCreated { get; set; }
        public DateTime? DteDeallocated { get; set; }
        public string TxtProductionCode { get; set; }

        public virtual TblEmployee IntEmployee { get; set; }
    }
}
