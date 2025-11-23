using IdealBizUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.ViewModels
{
    public class View_UnitOfMeasure
    {

        [NotMapped]
        public List<UnitOfMeasure> UnitOfMeasures { get; set; }
        [NotMapped]
        public UnitOfMeasure UnitOfMeasure { get; set; }

    }
}
