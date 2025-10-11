using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblOrderItem
    {
        public int IntOrderItem { get; set; }
        public string TxtOrderNumber { get; set; }
        public string TxtItemCode { get; set; }
        public string TxtNarration { get; set; }
        public int? IntQty { get; set; }
        public decimal? NumUnitPrice { get; set; }
        public decimal? NumTotal { get; set; }

        public virtual TblOrder TxtOrderNumberNavigation { get; set; }
    }
}
