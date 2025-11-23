using IdealBizUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.ViewModels
{
    public class View_ItemCategory
    {

        [NotMapped]
        public List<ItemCategory> itemCategories { get; set; }
        [NotMapped]
        public ItemCategory itemCategory { get; set; }

    }
}
