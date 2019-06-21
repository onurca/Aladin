using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Models
{
    public class ViewInRoleViewModel
    {
        public ViewInRoleViewModel()
        {

        }

        public ViewInRoleViewModel(Guid roleId, List<SelectListItem> viewsWithControllerGroup)
        {
            RoleId = roleId;
            ViewsWithControllerGroup = viewsWithControllerGroup;
        }


        [Display(Name = "Roller")]
        public Guid RoleId { get; set; }
        public List<SelectListItem> Roles { get; set; }

        [Display(Name = "Sayfalar")]
        public string[] ViewNames { get; set; }
        public List<SelectListItem> ViewsWithControllerGroup { get; set; }
    }
}