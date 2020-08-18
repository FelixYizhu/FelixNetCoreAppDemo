using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FelixNetCoreAppDemo.Models;
using FelixNetCoreAppDemo.Services;

namespace FelixNetCoreAppDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        // Constructor
        public EmployeeController(IDepartmentService departmentService, IEmployeeService employeeService) {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }


    }
}
