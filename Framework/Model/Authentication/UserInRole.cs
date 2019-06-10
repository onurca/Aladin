using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Model.Authentication
{
    [Table("UserInRole", Schema = "Authentication")]
    public class UserInRole : AuditableEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
