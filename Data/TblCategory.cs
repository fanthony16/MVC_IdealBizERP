using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblCategory
    {
        public int IntCategory { get; set; }
        public int? IntCompany { get; set; }
        public string TxtCategoryName { get; set; }
        public string TxtLedgerAccount { get; set; }
        public DateTime? DteCreated { get; set; }
    }
}
