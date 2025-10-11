using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblMedicalCategory
    {
        public TblMedicalCategory()
        {
            TblMedicalSubCategories = new HashSet<TblMedicalSubCategory>();
            TblMedicalTestTypes = new HashSet<TblMedicalTestType>();
        }

        public int IntCategoryId { get; set; }
        public string TxtCategoryCode { get; set; }
        public string TxtCategoryName { get; set; }

        public virtual ICollection<TblMedicalSubCategory> TblMedicalSubCategories { get; set; }
        public virtual ICollection<TblMedicalTestType> TblMedicalTestTypes { get; set; }
    }
}
