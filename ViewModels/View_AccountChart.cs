using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace IdealBizUI.ViewModels
{
    public class View_AccountChart
    {
        [Key]
        [Display(Name = "AccountID")]
        public int intRecID { get; set; }
        [Display(Name = "Account No")]
        public string txtAccountNumber { get; set; }

        [Display(Name = "Account Name")]
        public string txtAccountName { get; set; }

        [Display(Name = "Account Group")]
        public string intAccountGroup { get; set; }

        [Display(Name = "Direct Posting")]
        public bool isPosting { get; set; }

        [Display(Name = "Blocked")]
        public bool isBlocked { get; set; }

        [Display(Name = "Income/Balance")]
        public string IntIncomeOrBalance { get; set; }

        [Display(Name = "Acount Type")]
        public string IntAccountType { get; set; }

        [Display(Name = "Debit/Credit")]
        public string intPostingType { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> AccountGroups { get; set; }

    }
}
