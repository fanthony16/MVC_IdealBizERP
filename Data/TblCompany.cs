using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblCompany
    {
        public TblCompany()
        {
            TblOnlineOrders = new HashSet<TblOnlineOrder>();
            TblOrders = new HashSet<TblOrder>();
            TblPurchaseRequests = new HashSet<TblPurchaseRequest>();
        }

        public int IntCompany { get; set; }
        public string TxtCompanyName { get; set; }
        public string TxtCompanyAddress { get; set; }
        public string TxtContactPhone { get; set; }
        public string TxtOfficePhone { get; set; }
        public string TxtEmailAddress { get; set; }
        public string TxtVatLedger { get; set; }
        public string TxtInventoryLedger { get; set; }
        public string TxtInventoryExpenseLedger { get; set; }
        public string TxtInventoryIncomeLedger { get; set; }
        public string TxtRecievableLedger { get; set; }
        public string TxtPayableLedger { get; set; }
        public string TxtGeneralIncomeLedger { get; set; }
        public bool? BlnConnect2Gl { get; set; }
        public bool? BlnApplyVat { get; set; }
        public decimal? NumVatRate { get; set; }
        public DateTime? DteCreated { get; set; }
        public string BtnLogo { get; set; }

        public virtual ICollection<TblOnlineOrder> TblOnlineOrders { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
        public virtual ICollection<TblPurchaseRequest> TblPurchaseRequests { get; set; }
    }
}
