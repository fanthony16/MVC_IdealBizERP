using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class Ssislog
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int? IntRecordCount { get; set; }
    }
}
