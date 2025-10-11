using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblInventoryEntry
    {
        public TblInventoryEntry()
        {
            TblInventoryRequisitions = new HashSet<TblInventoryRequisition>();
        }

        public int IntEntryId { get; set; }
        public string TxtEntryCode { get; set; }
        public string TxtItemCode { get; set; }
        public string TxtVendorCode { get; set; }
        public int? IntQty { get; set; }
        public decimal? NumUnitPrice { get; set; }
        public decimal? NumTotalPrice { get; set; }
        public int? IntTransType { get; set; }
        public DateTime? DteTransactionDate { get; set; }
        public string TxtExternalEntryCode { get; set; }
        public string TxtStatus { get; set; }
        public DateTime? DteSentForApproval { get; set; }
        public DateTime? DteApproved { get; set; }
        public string TxtSentForApprovalBy { get; set; }
        public string TxtApprovedBy { get; set; }

        public virtual ICollection<TblInventoryRequisition> TblInventoryRequisitions { get; set; }
    }
}
