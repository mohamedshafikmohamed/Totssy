using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Totssy.Models;

namespace Totssy.Controllers
{
    public class UserController : Controller
    {
        private readonly Iuser UserRepos;
        private static FirebaseAuthLink Auth = null;
        private static string ApiKey = "AIzaSyCeEVEbEiThF8rybI66Hk2Ky4mz_uWt0ao";
        public UserController(Iuser _UserRepos)
        {
            UserRepos = _UserRepos;
        }
        public IActionResult Index()
        {
            return View();
        } 
        
        
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        } 
        public IActionResult Settings()
        {
            return View();
        } 
        public IActionResult Phones()
        {
            return View();
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Registerviewmodel  x)
        {
            Models.User u = new Models.User();
            UserRepos.AddProfile(u, "hhh", x);
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(string x)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                Auth = await auth.SignInWithEmailAndPasswordAsync("Email", "Model.Password");
                ViewBag.user = Auth.User.Email;
                return RedirectToAction("Products");
            }
            catch
            {
                ViewBag.error = "Wrong Email or Password";
                return View();
            }
            
        }

    }
}
