using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblItemCategory
    {
        public TblItemCategory()
        {
            TblInventoryItems = new HashSet<TblInventoryItem>();
            TblItems = new HashSet<TblItem>();
        }

        public int IntCategoryId { get; set; }
        public string TxtCategoryCode { get; set; }
        public string TxtDescription { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual ICollection<TblInventoryItem> TblInventoryItems { get; set; }
        public virtual ICollection<TblItem> TblItems { get; set; }
    }
}
