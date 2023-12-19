using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adesso.Dapr.Core.Common.Abstraction.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AdessoLinePropertyAttribute : Attribute
    {
        public AdessoLinePropertyAttribute(
            int capacity,
            int order)
        {
            this.Capacity = capacity;
            this.Order = order;
        }

        public int Capacity { get; }
        public int Order { get; }
    }
}
