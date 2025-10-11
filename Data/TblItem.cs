using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblItem
    {
        public int IntItemId { get; set; }
        public int? IntCompany { get; set; }
        public string TxtInventoryCode { get; set; }
        public string TxtItemName { get; set; }
        public decimal? NumCostOfSewing { get; set; }
        public decimal? NumCostOfAlteration { get; set; }
        public DateTime? DteCreated { get; set; }
    }
}
