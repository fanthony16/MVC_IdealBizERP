using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Models
{
    public class ItemCategory
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
