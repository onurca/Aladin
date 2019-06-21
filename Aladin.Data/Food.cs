using Framework.Model;
using System;

namespace Aladin.Data
{
    public class Food : AuditableEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid Category { get; set; }
    }
}
