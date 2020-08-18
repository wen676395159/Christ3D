using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christ3D.UI.Web.Models
{
    public class CustomerDao
    {
        public static Customer GetCustomer(string id)
        {
            return new Customer() { Id = "1", Name = "christ", Email = "qq.com" };
        }

        public static string SaveCustomer(Customer customer)
        {
            return "保存成功";
        }
    }
}
