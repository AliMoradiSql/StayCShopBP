using System.ComponentModel.DataAnnotations;

namespace StayCShop.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}