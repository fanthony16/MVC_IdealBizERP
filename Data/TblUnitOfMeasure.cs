using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblUnitOfMeasure
    {
        public TblUnitOfMeasure()
        {
            TblItemTxtBaseUnitOfMeasureNavigations = new HashSet<TblItem>();
            TblItemTxtPurchUnitOfMeasureNavigations = new HashSet<TblItem>();
            TblItemTxtSalesUnitOfMeasureNavigations = new HashSet<TblItem>();
        }

        public int IntUnitOfMeasure { get; set; }
        public string TxtDesciption { get; set; }
        public string TxtUomcode { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual ICollection<TblItem> TblItemTxtBaseUnitOfMeasureNavigations { get; set; }
        public virtual ICollection<TblItem> TblItemTxtPurchUnitOfMeasureNavigations { get; set; }
        public virtual ICollection<TblItem> TblItemTxtSalesUnitOfMeasureNavigations { get; set; }
    }
}
