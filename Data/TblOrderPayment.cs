using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblOrderPayment
    {
        public int IntPaymentId { get; set; }
        public string TxtPaymentRef { get; set; }
        public string TxtOrderNumber { get; set; }
        public decimal? NumAmount { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual TblOrder TxtOrderNumberNavigation { get; set; }
    }
}
