using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.ViewModels
{
    public class VerifyEmailViewModel
    {

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
