using IdealBizUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.ViewModels
{
    public class View_Company
    {
        [NotMapped]
        public List<Company> Companies { get; set; }
        [NotMapped]
        public Company MyCompany { get; set; }
    }
}
