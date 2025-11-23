using IdealBizUI.Data;
using IdealBizUI.InterfaceServices;
using IdealBizUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // private readonly IdealBizContext _db;
        private readonly IUserManager _uManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Username", "JohnDoe");
            HttpContext.Session.SetInt32("Age", 30);

            string username = HttpContext.Session.GetString("Username");
            int? age = HttpContext.Session.GetInt32("Age");

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
    }
}
