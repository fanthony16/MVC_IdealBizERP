using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblUser
    {
        public int IntUser { get; set; }
        public string TxtFullName { get; set; }
        public string TxtSurname { get; set; }
        public string TxtUserName { get; set; }
        public string TxtPassword { get; set; }
        public string TxtUserAccessGroup { get; set; }
        public DateTime? DteCreated { get; set; }
        public bool? BlnIsActive { get; set; }
        public string TxtEmail { get; set; }
        public string TxtTitle { get; set; }
        public int? IntGender { get; set; }

        public virtual TblUserGroup TxtUserAccessGroupNavigation { get; set; }
    }
}
