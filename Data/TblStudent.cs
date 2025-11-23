using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblStudent
    {
        public int IntId { get; set; }
        public string TxtLastName { get; set; }
        public string TxtOthernames { get; set; }
        public DateTime? DteDob { get; set; }
        public bool? IsActive { get; set; }
        public decimal? NumBalance { get; set; }
    }
}
