using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Models
{
    public class Company
    {
        
        [Display(Name = "ID")]
        public int CompanyID { get; set; }
        [Key]
        [Display(Name = "Name", Description = "Enter the comapany's name")]
        public string CompanyName { get; set; }
        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }
        [Display(Name = "Phone No.")]
        public string ContactPhone { get; set; }
        [Display(Name = "Office Phone")]
        public string OfficePhone { get; set; }
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Display(Name = "Vat Ledger")]
        public string VatLedger { get; set; }
        [Display(Name = "Inventory Ledger")]
        public string InventoryLedger { get; set; }
        [Display(Name = "Inventory Expense Ledger")]
        public string InventoryExpenseLedger { get; set; }
        [Display(Name = "Inventory Income Ledger")]
        public string InventoryIncomeLedger { get; set; }
        [Display(Name = "Recievable Ledger")]
        public string RecievableLedger { get; set; }
        [Display(Name = "Payable Ledger")]
        public string PayableLedger { get; set; }
        [Display(Name = "General Income Ledger")]
        public string GeneralIncomeLedger { get; set; }
        [Display(Name = "Connect 2GL")]
        public bool blnConnect2GL { get; set; }
        [Display(Name = "Apply Vat")]
        public bool ApplyVat { get; set; }
        [Display(Name = "Vat Rate")]
        public decimal? VatRate { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> AccountsChart { get; set; }

        //public Company MCompany { get; set; }




    }
}
