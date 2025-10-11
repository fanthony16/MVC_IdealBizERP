using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblPaymentRequest
    {
        public int IntPaymentId { get; set; }
        public string TxtPaymentCode { get; set; }
        public int? IntCompany { get; set; }
        public DateTime? DtePayment { get; set; }
        public string TxtVendorCode { get; set; }
        public string TxtRequisitionCode { get; set; }
        public decimal? NumAmount { get; set; }
        public string TxtStatus { get; set; }
        public string TxtPaymentSource { get; set; }
        public string TxtNarration { get; set; }
        public DateTime? DteCreated { get; set; }
        public DateTime? DteSentForApproval { get; set; }
        public DateTime? DteApproved { get; set; }
        public string TxtApprovedBy { get; set; }
        public string TxtCreatedBy { get; set; }
        public string TxtSentForApprovalBy { get; set; }

        public virtual TblPurchaseRequest TxtRequisitionCodeNavigation { get; set; }
        public virtual TblVendor TxtVendorCodeNavigation { get; set; }
    }
}
