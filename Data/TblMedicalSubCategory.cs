using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblMedicalSubCategory
    {
        public TblMedicalSubCategory()
        {
            TblMedicalTestTypes = new HashSet<TblMedicalTestType>();
        }

        public int IntSubId { get; set; }
        public string TxtCategoryCode { get; set; }
        public string TxtSubCategoryCode { get; set; }
        public string TxtSubCategoryName { get; set; }

        public virtual TblMedicalCategory TxtCategoryCodeNavigation { get; set; }
        public virtual ICollection<TblMedicalTestType> TblMedicalTestTypes { get; set; }
    }
}
