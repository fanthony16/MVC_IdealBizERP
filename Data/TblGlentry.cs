using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblGlentry
    {
        public int IntGlentry { get; set; }
        public string TxtEntryCode { get; set; }
        public DateTime? DteValueDate { get; set; }
        public string TxtLedgerAccount { get; set; }
        public string TxtMainAccount { get; set; }
        public decimal? NumDebit { get; set; }
        public decimal? NumCredit { get; set; }
        public string TxtNarration { get; set; }
        public string TxtPostPeriod { get; set; }
        public string TxtExternalCode { get; set; }
        public DateTime? DteCreated { get; set; }
        public string TxtPostedBy { get; set; }
    }
}
