using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Model.Authentication
{
    [Table("User", Schema = "Authentication")]
    public class User : AuditableEntity
    {
        [Display(Name = "İsim")]
        public string FirstName { get; set; }
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        public string Email { get; set; }
        [Index(IsUnique = true), StringLength(1000), Display(Name = "T.C. Kimlik Numarası")]
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
    }
}
