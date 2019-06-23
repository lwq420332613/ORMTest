using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWQ.DAL;
using LWQ.Model;

namespace LWQ.ORMTest1
{
    public class Program
    {
        /// <summary>
        /// 1.从Ado.Net到通用数据库访问层
        /// 2.泛型+反射+Ado.Net完成通用主键查询&全表查询
        /// 3.通过特性Attribute完成映射
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                SqlHelper helper = new SqlHelper();
                //UserInfo user = helper.Get<UserInfo>(1);
                //Company company = helper.Get<Company>(6);
                helper.Get<UserInfoModel>(1);
                helper.GetAll<Company>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
