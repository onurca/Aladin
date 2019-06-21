using Framework.Model;
using System;

namespace Aladin.Data
{
    public class CustomerFood : AuditableEntity
    {
        public Guid FoodID { get; set; }
        public Guid CustomerID { get; set; }
    }
}
