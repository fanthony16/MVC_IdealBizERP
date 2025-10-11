using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblUserAccess
    {
        public int IntAccess { get; set; }
        public string TxtGroupCode { get; set; }
        public string TxtMenuCode { get; set; }
        public bool? BlnIsMain { get; set; }
        public bool? BlnCreate { get; set; }
        public bool? BlnEdit { get; set; }
        public bool? BlnDelete { get; set; }
        public bool? BlnPrint { get; set; }
        public DateTime? DteCreated { get; set; }
    }
}
