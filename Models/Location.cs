using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
