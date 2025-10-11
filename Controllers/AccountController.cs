using IdealBizUI.Data;
using IdealBizUI.InterfaceServices;
using IdealBizUI.Models;
using IdealBizUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http;
using IdealBizUI.WebManager;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdealBizUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IdealBizContext _db;
        private readonly IUserManager _uManager;
       

        public AccountController(IConfiguration configuration, IdealBizContext db, IUserManager uManager) 
        {
            _configuration = configuration;
            _db = db;
            _db.configuration = _configuration;
            _uManager = uManager;
            _uManager.SetDbContext(_db);
            
            
        }
        public IActionResult Login()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel LVModel)
        {
            if (ModelState.IsValid)
            {
              var isAuthenticated =  await _uManager.LoginUser(LVModel);
                if (isAuthenticated) 
                {
                    
                    HttpContext.Session.Set("username", Encoding.ASCII.GetBytes(LVModel.UserName));
                    var _sessionManager = new SessionManager(HttpContext);
                    _sessionManager.SaveSessionObject(LVModel.UserName, "name");
                    return RedirectToAction("Index", "Home");
                    
                }
                else 
                {
                    ViewData["Message"] = "User name or Password is Incorrect";
                    return View();
                }
            }
            return View();


        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Account");

        }

        public void populateViewBags() {


            IEnumerable<SelectListItem> GetDesignations = _db.TblJournalDetails.Select(i => new SelectListItem
            {
                Text= i.TxtJournalCode,
                Value=i.TxtNarration.ToString()
            });

            //List<string> Gender = new List<string>()
            //{
            //    "Default",
            //    "Sales",
            //    "Manager",
            //    "Director",
            //    "Admin"
            //};




        }
        public IActionResult Register()
        {

            List<string> roles = new List<string>()
            {
                "Default",
                "Sales",
                "Manager",
                "Director",
                "Admin"
            };
            ViewBag.Roles = new SelectList(roles);

            populateViewBags();
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) 
            {
             
                
             var result =   await _uManager.CreateUser(model);
                if (result) {
                    
                    return RedirectToAction("Login", "Account");
                }
                else
                { 
                     return View();
                }
                
            }
            return View();
        }
        public IActionResult VerifyEmail()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
