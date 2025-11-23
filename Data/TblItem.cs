using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblItem
    {
        public int IntItemId { get; set; }
        public int? IntCompany { get; set; }
        public string TxtItemCode { get; set; }
        public string TxtItemName { get; set; }
        public string TxtBaseUnitOfMeasure { get; set; }
        public string TxtPurchUnitOfMeasure { get; set; }
        public string TxtSalesUnitOfMeasure { get; set; }
        public bool? BlnAllowInvoiceDiscount { get; set; }
        public string TxtShelfNo { get; set; }
        public decimal? NumSellingPrice { get; set; }
        public int? IntItemType { get; set; }
        public bool? BlnBlocked { get; set; }
        public bool? BlnSalesBlocked { get; set; }
        public bool? BtnPurchaseBlocked { get; set; }
        public int? TxtReplenishSystem { get; set; }
        public string TxtPurchaseVendor { get; set; }
        public int? IntCategoryId { get; set; }
        public string TxtCostingMethod { get; set; }
        public decimal? NumStandardCost { get; set; }
        public decimal? NumUnitCost { get; set; }
        public decimal? NumIndirectCost { get; set; }
        public string TxtInventoryPostingGroup { get; set; }
        public string TxtGeneralProductPostingGroup { get; set; }
        public string TxtVatproductPostingGroup { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual TblItemCategory IntCategory { get; set; }
        public virtual TblUnitOfMeasure TxtBaseUnitOfMeasureNavigation { get; set; }
        public virtual TblUnitOfMeasure TxtPurchUnitOfMeasureNavigation { get; set; }
        public virtual TblUnitOfMeasure TxtSalesUnitOfMeasureNavigation { get; set; }
    }
}
