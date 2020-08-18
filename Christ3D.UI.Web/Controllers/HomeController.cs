using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Christ3D.UI.Web.Models;

namespace Christ3D.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public void saveCustomer(string id, string name, string email, string birthDate)
        {
            Customer customer = CustomerDao.GetCustomer(id);
            if (customer == null)
            {
                customer = new Customer();
                customer.Id = id;
            }

            if (name != null)
            {
                customer.Name = name;
            }
            if (email != null)
            {
                customer.Email = email;
            }

            //...还有其他属性

            CustomerDao.SaveCustomer(customer);
        }
    }
}
