using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblAccountChart
    {
        public TblAccountChart()
        {
            TblSubAccounts = new HashSet<TblSubAccount>();
        }

        public int IntRecId { get; set; }
        public string TxtAccountNumber { get; set; }
        public string TxtAccountName { get; set; }
        public int? IntAccountGroup { get; set; }
        public bool? IsPosting { get; set; }
        public bool? IsBlocked { get; set; }
        public int? IntIncomeOrBalance { get; set; }
        public int? IntAccountType { get; set; }
        public int? IntPostingType { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual TblAccountGroup IntAccountGroupNavigation { get; set; }
        public virtual ICollection<TblSubAccount> TblSubAccounts { get; set; }
    }
}
