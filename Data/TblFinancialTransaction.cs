using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblFinancialTransaction
    {
        public int Int { get; set; }
        public int? DivisionId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionClass { get; set; }
        public decimal? MonthAmount { get; set; }
        public string CentreName { get; set; }
        public decimal? Qtdamount { get; set; }
        public decimal? Ytdamount { get; set; }
        public DateTime? MonthYear { get; set; }
        public string FileName { get; set; }
    }
}
