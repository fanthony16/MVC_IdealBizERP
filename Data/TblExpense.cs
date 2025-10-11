using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblExpense
    {
        public int IntExpenseId { get; set; }
        public string TxtExpenseCode { get; set; }
        public DateTime? DteExpense { get; set; }
        public decimal? NumAmount { get; set; }
        public string TxtNarration { get; set; }
        public string TxtExpenseType { get; set; }
        public string TxtPaymentSource { get; set; }
        public int? IntCompany { get; set; }
        public bool? IsReversed { get; set; }
    }
}
