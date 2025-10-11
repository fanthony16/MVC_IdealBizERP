using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblInventoryItem
    {
        public TblInventoryItem()
        {
            TblOnlineOrders = new HashSet<TblOnlineOrder>();
        }

        public int IntInventoryId { get; set; }
        public string TxtItemCode { get; set; }
        public string TxtItemName { get; set; }
        public string TxtUnitOfMeasure { get; set; }
        public decimal? NumSellingPrice { get; set; }
        public string TxtExpenseLedger { get; set; }
        public string TxtItemType { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual ICollection<TblOnlineOrder> TblOnlineOrders { get; set; }
    }
}
