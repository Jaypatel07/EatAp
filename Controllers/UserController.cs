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

    public class UserController : Controller {
        private Context dbContext;
        public UserController (Context context) {
            dbContext = context;
        }

        [HttpGet]
        [Route ("signin")]
        public ActionResult SignIn () {

            return View ("RegLog");
        }

        [HttpPost]
        [Route ("register")]
        public IActionResult register (User user) {

            if (ModelState.IsValid) {
                if (dbContext.Users.Any (u => u.Email == user.Email)) {
                    ModelState.AddModelError ("Email", "Email already in use!");

                    return View ("RegLog");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User> ();
                user.Password = Hasher.HashPassword (user, user.Password);
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                dbContext.Users.Add (user);
                dbContext.SaveChanges ();
                HttpContext.Session.SetInt32 ("UserId", user.UserId);
                ViewBag.UserId = HttpContext.Session.GetInt32 ("UserId");
                return RedirectToAction ("", "Home");
            }
            return View ("RegLog");
        }

        [HttpPost]
        [Route ("login")]
        public IActionResult login (LoginUser userSubmission) {
            if (ModelState.IsValid) {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Users.FirstOrDefault (u => u.Email == userSubmission.Email);
                // If no user exists with provided email
                if (userInDb == null) {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError ("Email", "Invalid Email/Password");
                    return View ("RegLog");
                }

                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser> ();

                // varify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword (userSubmission, userInDb.Password, userSubmission.Password);

                // result can be compared to 0 for failure
                if (result == 0) {
                    ModelState.AddModelError ("Password", "Invalid Email/Password");
                    return View ("RegLog");
                }

                HttpContext.Session.SetInt32 ("UserId", userInDb.UserId);
                
                return RedirectToAction ("", "Home");

            }

            return View ("RegLog");
        }
    


       
    

    }
}