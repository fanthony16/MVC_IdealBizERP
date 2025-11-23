using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Models
{
    public class UnitOfMeasure
    {
        
        [Display(Name = "Code", Description = "Enter code for Unit Of Measure")]
        [Required]
        public string Code { get; set; }
        [Key]
        public int UoMID { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
