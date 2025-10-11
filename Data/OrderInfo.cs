using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class OrderInfo
    {
        public int SubscriptionId { get; set; }
        public string Order { get; set; }
        public bool? FileType { get; set; }
        public string Format { get; set; }
    }
}
