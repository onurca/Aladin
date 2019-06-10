using System;
using System.ComponentModel.DataAnnotations;

namespace Framework.Core.Filter
{
    public class PropertyFilter
    {
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        sealed public class GuidRequired : ValidationAttribute
        {
            public override bool IsValid(Object value)
            {
                bool result = true;

                if ((Guid)value == Guid.Empty)
                    result = false;

                return result;
            }
        }
    }
}
