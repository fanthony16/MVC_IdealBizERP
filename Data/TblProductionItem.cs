using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblProductionItem
    {
        public int IntProductionId { get; set; }
        public string TxtProductionCode { get; set; }
        public int? IntCompanyId { get; set; }
        public DateTime? DteDate { get; set; }
        public int? IntItemId { get; set; }
        public string TxtStatus { get; set; }
        public string TxtCreatedBy { get; set; }
        public DateTime? DteSentForApproval { get; set; }
        public DateTime? DteApproved { get; set; }
        public DateTime? DteReleased { get; set; }
        public string TxtApprovedBy { get; set; }
        public string TxtSentBy { get; set; }
        public string TxtReleasedBy { get; set; }
        public int? IntCutter { get; set; }
        public int? IntTailor { get; set; }
        public string TxtInventoryCode { get; set; }
        public string TxtInventoryEntryCode { get; set; }
    }
}
