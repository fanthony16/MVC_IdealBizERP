using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblJournalDetail
    {
        public int IntJournalLine { get; set; }
        public string TxtJournalCode { get; set; }
        public string TxtPostPeriod { get; set; }
        public string TxtLedgerAccount { get; set; }
        public string TxtMainAccount { get; set; }
        public decimal? NumDebit { get; set; }
        public decimal? NumCredit { get; set; }
        public string TxtNarration { get; set; }
        public DateTime? DteValueDate { get; set; }
        public DateTime? DtePostDate { get; set; }

        public virtual TblJournalMaster TxtJournalCodeNavigation { get; set; }
    }
}
