using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace Aladin.Areas.Yonetim.Models
{
    public class SettingsViewModel
    {
        [Required]
        [MembershipPassword(
            MinRequiredNonAlphanumericCharacters = 1,
            MinNonAlphanumericCharactersError = "Şifreniz en az bir sembol içermelidir. (!, @, #, etc).",
            ErrorMessage = "Şifreniz en az 6 karakter ve en az bir sembol içermelidir.(!, @, #, etc).",
            MinRequiredPasswordLength = 6
        )]
        [DataType(DataType.Password)]
        [Display(Name ="Yeni Sifre")]
        public string Password { get; set; }

        [Display(Name = "Yeni Sifre Onay")]
        [Compare("Password", ErrorMessage = "Girmiş olduğunuz şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}