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
    public class HomeController : Controller {
        private Context dbContext;
        public HomeController (Context context) {
            dbContext = context;

        }

        [HttpGet, HttpPost]
        [Route ("")]
        public IActionResult Index () {
            ViewBag.UserId = HttpContext.Session.GetInt32 ("UserId");
            ViewBag.AdminId = HttpContext.Session.GetInt32 ("AdminId");
            List<Admin> AllAdmins = dbContext.Admins.ToList ();
            ViewBag.AllAdmins = AllAdmins;
            return View ();

        }
        

        [HttpGet]
        [Route ("details/{AdminId}")]
        public IActionResult restaurant (int AdminId) {
            Admin CurrentAdmin = dbContext.Admins.SingleOrDefault (a => a.AdminId == AdminId);
            User CurrentUser = dbContext.Users.SingleOrDefault (user => user.UserId == HttpContext.Session.GetInt32 ("UserId"));
            List<Review> AllReviews = dbContext.Reviews.Where ((a => a.RestaurantId == AdminId))
                .Include (x => x.RestaurantNReview)
                .ThenInclude (y => y.User).OrderBy (a => a.UpdatedAt)
                .ToList ();
            ViewBag.AllReviews = AllReviews;
            ViewBag.UserId = HttpContext.Session.GetInt32 ("UserId");

            ViewBag.AdminId = HttpContext.Session.GetInt32 ("AdminId");
            ViewBag.CurrentUser = CurrentUser;
            ViewBag.CurrentAdmin = CurrentAdmin;
            return View ("Details");
        }

        [HttpGet]
        [Route ("/newreview/{AdminId}")]
        public IActionResult newreview (int AdminId) {
            if (HttpContext.Session.GetInt32 ("UserId") == null) {
                return RedirectToAction ("Index", "User");
            }
            Admin CurrentAdmin = dbContext.Admins.SingleOrDefault (a => a.AdminId == AdminId);
            User CurrentUser = dbContext.Users.SingleOrDefault (user => user.UserId == HttpContext.Session.GetInt32 ("UserId"));
            ViewBag.CurrentAdmin = CurrentAdmin;
            ViewBag.CurrentUser = CurrentUser;
            ViewBag.UserId = HttpContext.Session.GetInt32 ("UserId");
            return View ("newreview");
        }

        [HttpPost]
        [Route ("/addreview/{AdminId}")]
        public IActionResult addreview (Review review, int AdminId) {
            
            Admin CurrentAdmin = dbContext.Admins.SingleOrDefault (a => a.AdminId == AdminId);
            User CurrentUser = dbContext.Users.SingleOrDefault (user => user.UserId == HttpContext.Session.GetInt32 ("UserId"));
            ViewBag.CurrentAdmin = CurrentAdmin;
            ViewBag.CurrentUser = CurrentUser;
            if (HttpContext.Session.GetInt32 ("UserId") == null) {
                return RedirectToAction ("Index", "Home");
            }
            if (ModelState.IsValid) {
                dbContext.Add (review);
                dbContext.SaveChanges ();

                Review CurrentReview = review;
                RestaurantNReview n = new RestaurantNReview {
                    UserId = CurrentUser.UserId,
                    User = CurrentUser,
                    ReviewId = CurrentReview.ReviewId,
                    Review = CurrentReview
                };
                CurrentReview.RestaurantNReview.Add (n);
                dbContext.SaveChanges ();
                return RedirectToAction("");
            } else {
                ViewBag.errors = ModelState.Values;

                return View ("newreview");
            }

        }
        [HttpGet]
        [Route("/delete/{ReviewId}")]
        public IActionResult Delete(int ReviewId) {
            if(HttpContext.Session.GetInt32("UserId") == null) {
                return RedirectToAction("SignIn", "User");
            }
            Review CurrentReview = dbContext.Reviews.SingleOrDefault(Activity => Activity.ReviewId == ReviewId);
            dbContext.Reviews.Remove(CurrentReview);
            dbContext.SaveChanges();
            return RedirectToAction("");
        }

        [HttpGet]
        [Route("/about")]
        public IActionResult About () {
            return View ("About");
        }

        [HttpGet]
        [Route("/contact")]
        public IActionResult Contact () {
           

            return View ("Contact");
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}