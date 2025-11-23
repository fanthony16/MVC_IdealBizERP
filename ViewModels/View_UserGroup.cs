using IdealBizUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.ViewModels
{
    public class View_UserGroup
    {
        [NotMapped]
        public List<UserGroup> UserGroups { get; set; }

        public UserGroup _UserGroup { get; set; }
    }
}
