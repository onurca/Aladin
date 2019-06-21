using Aladin.Data.Enum;
using Framework.Model;
using System;

namespace Aladin.Data
{
    public class Customer : AuditableEntity
    {
        public string IDNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid CountryID { get; set; }
        public Guid CityID { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public IdentityDocument IdentityDocument { get; set; }
    }
}
