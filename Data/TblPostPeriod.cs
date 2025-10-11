using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblPostPeriod
    {
        public int IntPostPeriod { get; set; }
        public string TxtPostPeriod { get; set; }
        public DateTime? DteStartDate { get; set; }
        public DateTime? DteEndDate { get; set; }
        public bool? IsYearEnd { get; set; }
        public bool? IsPeriodClose { get; set; }
        public DateTime? DteCreated { get; set; }
        public DateTime? DtePeriodClose { get; set; }
        public string TxtPeriodCloseBy { get; set; }
    }
}
