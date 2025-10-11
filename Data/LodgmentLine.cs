using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class LodgmentLine
    {
        public string CashId { get; set; }
        public bool? ContributionPosted { get; set; }
        public decimal? Amount { get; set; }
        public string FileName { get; set; }
    }
}
