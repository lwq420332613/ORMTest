using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWQ.Framework
{
    public class BaseMappingAttribute:Attribute
    {
        private string _Name;

        public BaseMappingAttribute(string name)
        {
            _Name = name;
        }

        public virtual string GetName()
        {
            return _Name;
        }
    }
}
