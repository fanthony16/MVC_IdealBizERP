using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblLeisureFinancial
    {
        public int Uid { get; set; }
        public int? DivisionId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionClass { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Qtd { get; set; }
        public decimal? Ytd { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
