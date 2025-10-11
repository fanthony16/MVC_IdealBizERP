using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblInventoryRequisition
    {
        public int IntEntryId { get; set; }
        public string TxtEntryCode { get; set; }
        public int? IntQty { get; set; }
        public DateTime? DteTransaction { get; set; }
        public string TxtExternalEntryCode { get; set; }
        public string TxtNarration { get; set; }
        public DateTime? DteCreated { get; set; }
        public string TxtStatus { get; set; }
        public DateTime? DteSentForApproval { get; set; }
        public string TxtSentForApprovalBy { get; set; }
        public DateTime? DteApproved { get; set; }
        public string TxtApprovedBy { get; set; }
        public string TxtExternalCode { get; set; }

        public virtual TblInventoryEntry TxtEntryCodeNavigation { get; set; }
    }
}
