using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StayCShop.ClientLogin.Dto
{
    public class ClientLoginDto : EntityDto
    {
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Rremember Me")]
        public bool RememberMe { get; set; }
    }
}
