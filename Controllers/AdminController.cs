 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EatAp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EatAp.Controllers {
    public class AdminController : Controller {
        private Context dbContext;
        public AdminController (Context context) {
            dbContext = context;
        }
        [HttpGet]
        [Route ("business")]
        public ActionResult business () {

            return View ("BRegLog");
        }

        [HttpPost]
        [Route ("bregister")]
        public IActionResult bregister (Admin Admin) {

            if (ModelState.IsValid) {
                if (dbContext.Admins.Any (u => u.Email == Admin.Email)) {
                    ModelState.AddModelError ("Email", "Email already in use!");

                    return View ("BRegLog");
                }
                PasswordHasher<Admin> Hasher = new PasswordHasher<Admin> ();
                Admin.Password = Hasher.HashPassword (Admin, Admin.Password);
                Admin.CreatedAt = DateTime.Now;
                Admin.UpdatedAt = DateTime.Now;
                dbContext.Admins.Add (Admin);
                dbContext.SaveChanges ();
                HttpContext.Session.SetInt32 ("AdminId", Admin.AdminId);
                ViewBag.AdminId = HttpContext.Session.GetInt32 ("AdminId");
                return RedirectToAction ("", "Home");
            }
            return View ("BRegLog");
        }

        [HttpPost]
        [Route ("blogin")]
        public IActionResult login (LoginAdmin AdminSubmission) {
            if (ModelState.IsValid) {
                // If inital ModelState is valid, query for a Admin with provided email
                var AdminInDb = dbContext.Admins.FirstOrDefault (u => u.Email == AdminSubmission.Email);
                // If no Admin exists with provided email
                if (AdminInDb == null) {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError ("Email", "Invalid Email/Password");
                    return View ("BRegLog");
                }

                // Initialize hasher object
                var hasher = new PasswordHasher<LoginAdmin> ();

                // varify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword (AdminSubmission, AdminInDb.Password, AdminSubmission.Password);

                // result can be compared to 0 for failure
                if (result == 0) {
                    ModelState.AddModelError ("Password", "Invalid Email/Password");
                    return View ("BRegLog");
                }

                HttpContext.Session.SetInt32 ("AdminId", AdminInDb.AdminId);
                ViewBag.AdminId = HttpContext.Session.GetInt32 ("AdminId");
                return RedirectToAction ("", "Home");

            }

            return View ("BRegLog");
        }
        

        [HttpGet]
        [Route ("/logout")]

        public IActionResult Logout () {
            HttpContext.Session.Clear ();
            return RedirectToAction ("business", "Admin");

        }
    }
}