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
        static void Main(string[] args)
        {
            try
            {
                SqlHelper helper = new SqlHelper();
                //UserInfo user = helper.Get<UserInfo>(1);
                //Company company = helper.Get<Company>(6);
                helper.GetAll<Company>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
