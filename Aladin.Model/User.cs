using System;
using System.ComponentModel.DataAnnotations;

namespace Aladin.Areas.Yonetim.Models
{
    public class UserViewModel
    {
        [Display(Name = "İsim")]
        public string FirstName { get; set; }
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
        public Guid ID { get; set; }
    }
}