using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWQ.Model
{
    public class UserInfo:BaseModel 
    {
        public string UserName { get; set; }

        public int Sex { get; set; }

        public DateTime Birthday { get; set; }

        public string Telephone { get; set; }

        public int Status { get; set; }
    }
}
