using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblProductionMaterial
    {
        public int IntProductionMaterialId { get; set; }
        public string TxtProductionCode { get; set; }
        public string TxtInventoryCode { get; set; }
        public int? IntQty { get; set; }
        public decimal? NumUnitPrice { get; set; }
        public decimal? NumTotal { get; set; }
    }
}
