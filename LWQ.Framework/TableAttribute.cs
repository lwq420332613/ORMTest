using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWQ.Framework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute:BaseMappingAttribute
    {
        public TableAttribute(string name):base(name)
        {
        }
    }
}
