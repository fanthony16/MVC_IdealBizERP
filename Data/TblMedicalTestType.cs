using System;
using System.Collections.Generic;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class TblMedicalTestType
    {
        public int IntTypeId { get; set; }
        public string TxtCategoryCode { get; set; }
        public string TxtSubCategoryCode { get; set; }
        public string TxtTestCode { get; set; }
        public string TxtTestName { get; set; }
        public DateTime? DteCreated { get; set; }

        public virtual TblMedicalCategory TxtCategoryCodeNavigation { get; set; }
        public virtual TblMedicalSubCategory TxtSubCategoryCodeNavigation { get; set; }
    }
}
