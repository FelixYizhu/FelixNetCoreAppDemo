using FelixNetCoreAppDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelixNetCoreAppDemo.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)   
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index() 
        {
            ViewBag.title = "Department Index";
            var departments = _departmentService.GetAll();
            return View(departments);
        }
    }
}
