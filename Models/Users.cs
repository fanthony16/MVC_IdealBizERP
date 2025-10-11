using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Models
{
    public class Users: IdentityUser
    {
        public string FullName { get; set; }

    }
}
