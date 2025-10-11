using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblSubAccount
    {
        public int IntSubAccount { get; set; }
        public string TxtAccountCode { get; set; }
        public string TxtAccountName { get; set; }
        public string TxtMainAccount { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual TblAccountChart TxtMainAccountNavigation { get; set; }
    }
}
