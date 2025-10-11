using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrderItems = new HashSet<TblOrderItem>();
            TblOrderPayments = new HashSet<TblOrderPayment>();
            TblReciepts = new HashSet<TblReciept>();
        }

        public int IntOrderId { get; set; }
        public string TxtOrderNumber { get; set; }
        public int? IntCompanyId { get; set; }
        public string TxtCustomerCode { get; set; }
        public decimal? NumOrderAmount { get; set; }
        public decimal? NumDiscountAmount { get; set; }
        public decimal? NumOtherCharges { get; set; }
        public decimal? NumNetAmount { get; set; }
        public decimal? NumVat { get; set; }
        public DateTime? DteOrderDate { get; set; }
        public DateTime? DteDueDate { get; set; }
        public string TxtStatus { get; set; }
        public DateTime? DteSentForApproval { get; set; }
        public DateTime? DteConfirmed { get; set; }
        public DateTime? DteCreated { get; set; }
        public string TxtCreatedBy { get; set; }
        public string TxtConfirmedBy { get; set; }
        public string TxtSentForApproval { get; set; }
        public bool? BlnHasInventoryItem { get; set; }

        public virtual TblCompany IntCompany { get; set; }
        public virtual TblCustomer TxtCustomerCodeNavigation { get; set; }
        public virtual ICollection<TblOrderItem> TblOrderItems { get; set; }
        public virtual ICollection<TblOrderPayment> TblOrderPayments { get; set; }
        public virtual ICollection<TblReciept> TblReciepts { get; set; }
    }
}
