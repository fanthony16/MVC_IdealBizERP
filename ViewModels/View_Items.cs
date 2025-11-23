using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdealBizUI.ViewModels
{
    public class View_Items
    {
        [Key]
        [Display(Name ="Item No")]
        public int ItemID { get; set; }
        [Display(Name ="Item Code")]
        [Required]
        public string ItemCode { get; set; }
        [Display(Name = "Item Name")]
        [Required]
        public string ItemName { get; set; }
        [Display(Name = "Base Unit Of Measure")]
        public string BaseUnitOfMeasure { get; set; }
        [Display(Name ="Purchase Unit Of Measure")]
        public string PuchaseUnitOfMeasure { get; set; }
        [Display(Name ="Sales Unit Of Measure")]
        public string SalesUnitOfMeasure { get; set; }

        [Display(Name = "Allow Invoice Discount")]
        public bool AllowInvoiceDiscount { get; set; }

        [Display(Name = "Shelf No")]
        public string ShelfNo { get; set; }

        [Display(Name = "Selling Price")]
        public decimal? SellingPrice { get; set; }

        [Display(Name = "Item Type")]
        public string ItemType { get; set; }
        [Display(Name = "Item Blocked?")]
        public bool ItemBlocked { get; set; }
        [Display(Name = "Sales Blocked?")]
        public bool SalesBlocked { get; set; }
        [Display(Name = "Purchase Blocked?")]
        public bool PurchaseBlocked { get; set; }

        [Display(Name = "Replenish System")]
        public int? ReplenishSystem { get; set; }

        [Display(Name = "Replenish Vendor")]
        public string PurchaseVendor { get; set; }

        [Display(Name = "Item Category")]
        public int? CategoryID { get; set; }

        [Display(Name = "Costing Method")]
        public string CostingMethod { get; set; }

        [Display(Name = "Standard Cost")]
        public decimal? StandardCost { get; set; }
        [Display(Name = "Unit Cost")]
        public decimal? UnitCost { get; set; }
        [Display(Name = "Indirect Cost")]
        public decimal? IndirectCost { get; set; }

        [Display(Name = "Inventory Posting Group")]
        public string InventoryPostingGroup { get; set; }

        [Display(Name = "General Product Posting Group")]
        public string GeneralProductPostingGroup { get; set; }

        [Display(Name = "VAT Product Posting Group")]
        public string VATProductPostingGroup { get; set; }

        
        [Display(Name = "Upload Item Image")]
        public IFormFile ItemFile { get; set; }

        
        public string ImagePath { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> UnitOfMeasures { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ItemsCategories { get; set; }

    }
}
