using IdealBizUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.ViewModels
{
    public class View_Location
    {

        [NotMapped]
        public List<Location> ItemLocations { get; set; }
        [NotMapped]
        public Location ItemLocation { get; set; }

    }
}
