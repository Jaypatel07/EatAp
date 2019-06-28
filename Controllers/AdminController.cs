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
            if (HttpContext.Session.GetInt32 ("AdminId") != null) {
                return RedirectToAction("");
            }
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
                var AdminInDb = dbContext.Admins.FirstOrDefault (u => u.Email == AdminSubmission.Email);
                if (AdminInDb == null) {
                    ModelState.AddModelError ("Email", "Invalid Email/Password");
                    return View ("BRegLog");
                }   
                var hasher = new PasswordHasher<LoginAdmin> ();
                var result = hasher.VerifyHashedPassword (AdminSubmission, AdminInDb.Password, AdminSubmission.Password);
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
            return RedirectToAction ("", "Home");

        }
    }
}