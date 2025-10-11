using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblJournalMaster
    {
        public TblJournalMaster()
        {
            TblJournalDetails = new HashSet<TblJournalDetail>();
        }

        public int IntJournalMaster { get; set; }
        public string TxtJournalCode { get; set; }
        public decimal? NumJournalAmount { get; set; }
        public DateTime? TxtValueDate { get; set; }
        public string TxtPostPeriod { get; set; }
        public bool? IsPosted { get; set; }
        public DateTime? DtePostDate { get; set; }
        public DateTime? DteCreated { get; set; }
        public string TxtStatus { get; set; }
        public DateTime? DteApproved { get; set; }
        public DateTime? DteSentForApproval { get; set; }
        public string TxtCreatedBy { get; set; }
        public string TxtPostedBy { get; set; }
        public string TxtSentForApprovalBy { get; set; }

        public virtual ICollection<TblJournalDetail> TblJournalDetails { get; set; }
    }
}
