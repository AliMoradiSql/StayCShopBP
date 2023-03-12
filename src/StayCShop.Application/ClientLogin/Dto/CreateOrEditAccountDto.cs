using StayCShop.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StayCShop.ClientLogin.Dto
{
    public class CreateOrEditAccountDto
    {
        [Display(Name = "First Name")]
        public string Name { get; set; }
        [Display(Name = "Last Name")]
        public string SureNAme { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public string ActiveCode { get; set; } = GenerateActiveCode.GenarateUniqCode();
        [Display(Name = "Confirmation Password")]
        [Compare("UserPassword", ErrorMessage = "Password Confirmation Is Does Not Match!")]
        public string ConfirmationPassword { get; set; }
    }
}
