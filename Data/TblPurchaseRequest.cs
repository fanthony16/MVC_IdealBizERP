using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblPurchaseRequest
    {
        public TblPurchaseRequest()
        {
            TblPaymentRequests = new HashSet<TblPaymentRequest>();
        }

        public int IntRequisition { get; set; }
        public string TxtRequisitionCode { get; set; }
        public string TxtVendorCode { get; set; }
        public int? IntCompany { get; set; }
        public bool? IntRequisitionType { get; set; }
        public string TxtExpenseLedger { get; set; }
        public string TxtItemCode { get; set; }
        public int? IntQty { get; set; }
        public decimal? NumUnitPrice { get; set; }
        public decimal? NumTotalAmount { get; set; }
        public string TxtDescription { get; set; }
        public DateTime? DteRequest { get; set; }
        public DateTime? DteCreated { get; set; }
        public string TxtCreatedBy { get; set; }
        public string TxtStatus { get; set; }
        public DateTime? DteSentForApproval { get; set; }
        public DateTime? DteApproved { get; set; }
        public string TxtApprovedBy { get; set; }
        public string TxtSentForApprovalBy { get; set; }

        public virtual TblCompany IntCompanyNavigation { get; set; }
        public virtual TblVendor TxtVendorCodeNavigation { get; set; }
        public virtual ICollection<TblPaymentRequest> TblPaymentRequests { get; set; }
    }
}
