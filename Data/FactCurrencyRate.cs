using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class FactCurrencyRate
    {
        public int RowId { get; set; }
        public decimal? AverageRate { get; set; }
        public string CurrencyKey { get; set; }
        public DateTime? DateKey { get; set; }
        public decimal? EndOfDayRate { get; set; }
    }
}
