using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblPl
    {
        public int IntId { get; set; }
        public string TxtTitle { get; set; }
        public int? IntType { get; set; }
        public string TxtScript { get; set; }
        public int? IntOrderId { get; set; }
        public string TxtLedgerAccounts { get; set; }
    }
}
