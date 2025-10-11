using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblUserGroup
    {
        public TblUserGroup()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public int IntAccessGroup { get; set; }
        public string TxtGroupCode { get; set; }
        public string TxtGroupName { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
