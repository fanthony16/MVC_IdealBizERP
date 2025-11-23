using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Models
{
    public class UserGroup
    {
        [Key]
        public int AccessGroupID { get; set; }
        [Display(Name ="Group Code")]
        public string GroupCode { get; set; }
        [Display(Name ="Group Name")]
        public string GroupName { get; set; }
    }
}
