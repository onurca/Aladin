using Framework.Model;
using System;

namespace Aladin.Data
{
    public class City : AuditableEntity
    {
        public string Name { get; set; }
        public Guid CountryID { get; set; }
    }
}
