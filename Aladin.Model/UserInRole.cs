using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Models
{
    public class UserInRoleViewModel
    {
        public UserInRoleViewModel()
        {

        }

        public UserInRoleViewModel(Guid userId,string fullName, List<SelectListItem> userRoles)
        {
            UserId = userId;
            UserRoles = userRoles;
            FullName = fullName;
        }

        public Guid UserId { get; set; }

        [Display(Name = "Kullanıcı İsmi")]
        public string FullName { get; set; }

        [Display(Name ="Kullanıcı Rolleri")]
        public List<SelectListItem> UserRoles { get; set; }

        [Required]
        public List<string> Roles { get; set; }
    }
}