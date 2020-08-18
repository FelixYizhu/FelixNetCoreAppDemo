using FelixNetCoreAppDemo.Models;
using FelixNetCoreAppDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelixNetCoreAppDemo.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IOptions<ConfigOptions> _configOptions;
        public DepartmentController(IDepartmentService departmentService,IOptions<ConfigOptions> configOptions)   
        {
            _departmentService = departmentService;
            _configOptions = configOptions;
        }

        public async Task<IActionResult> Index() 
        {
            ViewBag.title = "Department Index";
            var departments =await _departmentService.GetAll();
            return View(departments);
        }

        public IActionResult Add() 
        {
            ViewBag.title = "Add Department";
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Department model)
        {
            if (ModelState.IsValid) 
            {
                await _departmentService.Add(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
