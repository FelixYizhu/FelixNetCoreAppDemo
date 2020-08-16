using FelixNetCoreAppDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelixNetCoreAppDemo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IClock clock)   
        {

        }
    }
}
