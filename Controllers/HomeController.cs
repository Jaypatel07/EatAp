using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EatAp.Models;

namespace EatAp.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
        public HomeController (Context context) {
            dbContext = context;
        }
        public IActionResult Index()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32 ("UserId");
            ViewBag.AdminId = HttpContext.Session.GetInt32 ("AdminId");
            List<Admin> AllAdmins = dbContext.Admins.ToList();
            ViewBag.AllAdmins = AllAdmins;
            return View();
            
        }
        

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
