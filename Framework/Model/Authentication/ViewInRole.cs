using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Model.Authentication
{
    [Table("ViewInRole", Schema = "Authentication")]
    public class ViewInRole : AuditableEntity
    {
        public ViewInRole()
        {

        }

        public ViewInRole(Guid roleId, string area, string controller, string action)
        {
            RoleId = roleId;
            Area = area;
            Controller = controller;
            Action = action;
        }
        public Guid RoleId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
    }
}
