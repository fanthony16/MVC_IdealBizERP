using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblOnlineOrder
    {
        public int IntId { get; set; }
        public string TxtCustomerCode { get; set; }
        public string TxtItemCode { get; set; }
        public int? IntCompanyId { get; set; }
        public DateTime? DteOrderDate { get; set; }
        public int? IntQty { get; set; }
        public decimal? NumCostPrice { get; set; }
        public decimal? NumTotal { get; set; }

        public virtual TblCompany IntCompany { get; set; }
        public virtual TblCustomer TxtCustomerCodeNavigation { get; set; }
        public virtual TblInventoryItem TxtItemCodeNavigation { get; set; }
    }
}
