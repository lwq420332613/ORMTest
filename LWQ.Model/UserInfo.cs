using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWQ.Framework;

namespace LWQ.Model
{
    [Table("UserInfo")]
    public class UserInfoModel:BaseModel 
    {
        public string UserName { get; set; }

        public int Sex { get; set; }

        public DateTime Birthday { get; set; }

        public string Telephone { get; set; }

        [Column("Status")]
        public int State { get; set; }
    }
}
