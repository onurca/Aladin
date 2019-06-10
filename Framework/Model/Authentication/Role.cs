using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Model.Authentication
{
    [Table("Role", Schema = "Authentication")]
    public class Role : AuditableEntity
    {
        public Role()
        {

        }

        public Role(Guid id,string name)
        {
            ID = id;
            Name = name;
        }

        [Display(Name = "İsim")]
        public string Name { get; set; }
    }
}
