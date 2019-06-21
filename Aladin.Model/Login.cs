using System.ComponentModel.DataAnnotations;

namespace Aladin.Model
{
    public class Login
    {
        [Display(Name = "Üye Numarası"), MaxLength(11), DataType(DataType.Text), Required]
        public string IdentificationNumber { get; set; }
        [Display(Name = "Şifre"), DataType(DataType.Password), Required]
        public string Password { get; set; }

        private string _returnUrl;

        public string returnUrl
        {
            get
            {
                return _returnUrl;
            }
            set
            {
                _returnUrl = value ?? "/Admin/Dues/List";
            }
        }
    }
}
