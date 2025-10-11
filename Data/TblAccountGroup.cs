using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblAccountGroup
    {
        public TblAccountGroup()
        {
            TblAccountCharts = new HashSet<TblAccountChart>();
        }

        public int IntAccountGroup { get; set; }
        public string TxtAccountGroupName { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual ICollection<TblAccountChart> TblAccountCharts { get; set; }
    }
}
