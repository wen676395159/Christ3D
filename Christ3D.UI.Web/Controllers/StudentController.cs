using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Christ3D.Application.Interfaces;
using Christ3D.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Christ3D.UI.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }
        public IActionResult Index()
        {
            return View(_studentAppService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentViewModel studentViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(studentViewModel);
                }
                _studentAppService.Register(studentViewModel);
                ViewBag.success = "Student Registered!";
                return View(studentViewModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}
