using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblClosingBalance
    {
        public int IntRecordId { get; set; }
        public string TxtAccountCode { get; set; }
        public string TxtPostPeriod { get; set; }
        public decimal? NumDebit { get; set; }
        public decimal? NumCredit { get; set; }
        public DateTime? DteClosed { get; set; }
        public string TxtCloseBy { get; set; }
    }
}
