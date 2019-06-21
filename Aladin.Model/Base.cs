using System;

namespace Aladin.Model
{
    public class Base
    {
        public Guid ID { get; set; } = Guid.Empty;

        public bool IsNew { get { return ID == Guid.Empty; } }
    }
}