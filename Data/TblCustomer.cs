using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            TblOnlineOrders = new HashSet<TblOnlineOrder>();
            TblOrders = new HashSet<TblOrder>();
        }

        public int IntCustomerId { get; set; }
        public string TxtCustomerCode { get; set; }
        public string TxtTitle { get; set; }
        public string TxtSex { get; set; }
        public string TxtCustomerName { get; set; }
        public string TxtHomeAddress { get; set; }
        public string TxtOfficeAddress { get; set; }
        public string TxtTelephone1 { get; set; }
        public string TxtTelephone2 { get; set; }
        public string TxtEmail { get; set; }
        public string TxtRelationShip { get; set; }
        public string TxtParentId { get; set; }
        public decimal? NumCreditLimit { get; set; }
        public DateTime? DteDob { get; set; }
        public DateTime? DteAnniversory { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual ICollection<TblOnlineOrder> TblOnlineOrders { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
