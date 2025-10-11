using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblReciept
    {
        public int IntRecieptNo { get; set; }
        public string TxtRecieptCode { get; set; }
        public string TxtOrderNumber { get; set; }
        public DateTime? DteReciept { get; set; }
        public decimal? NumAmount { get; set; }
        public string TxtRecieptType { get; set; }
        public DateTime? DteReversed { get; set; }
        public string TxtNarration { get; set; }

        public virtual TblOrder TxtOrderNumberNavigation { get; set; }
    }
}
