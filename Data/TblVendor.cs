using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblVendor
    {
        public TblVendor()
        {
            TblPaymentRequests = new HashSet<TblPaymentRequest>();
            TblPurchaseRequests = new HashSet<TblPurchaseRequest>();
        }

        public int IntVendorId { get; set; }
        public string TxtVendorCode { get; set; }
        public string TxtVendorName { get; set; }
        public string TxtOfficeAddress { get; set; }
        public string TxtEmail { get; set; }
        public string TxtTelephone1 { get; set; }
        public string TxtTelephone2 { get; set; }
        public string TxtTin { get; set; }
        public string TxtContactPerson { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual ICollection<TblPaymentRequest> TblPaymentRequests { get; set; }
        public virtual ICollection<TblPurchaseRequest> TblPurchaseRequests { get; set; }
    }
}
