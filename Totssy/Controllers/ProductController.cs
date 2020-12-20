using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Totssy.Models;

namespace Totssy.Controllers
{
    public class ProductController : Controller
    {
        private readonly Iproduct productRepos;
        private static FirebaseAuthLink Auth = null;
        private static string Bucket = "totssy-test.appspot.com";
        private static string ApiKey = "AIzaSyCeEVEbEiThF8rybI66Hk2Ky4mz_uWt0ao";
        public ProductController(Iproduct _productRepos)
        {
             productRepos = _productRepos;
        }
        public async Task<IActionResult> products()
        {
            if (Auth == null)
            {
                return RedirectToAction("lOGIN");
            }
            else
            {

                var products = await productRepos.GetProducts();
                return View(products.ToList());
            }
        }
        public async Task<IActionResult> product(string Name)
        {
            if (Auth == null)
            {
                return RedirectToAction("lOGIN");
            }
            else
            {
                var product = await productRepos.GetProduct(Name);
                return View(product);
            }
        }
        public IActionResult Addproduct()
        {
            if (Auth == null)
            {
                return RedirectToAction("lOGIN");
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Addproduct(ProductViewModel product)
        {
            if (Auth == null)
            {
                return RedirectToAction("lOGIN");
            }
            else
            {
                var stream = product.Img.OpenReadStream();
                string r = "";
                if (product.Img.Length > 0)
                {
                    var upload = new FirebaseStorage(
                            Bucket

                            ).Child("Pics")
                            .Child(product.Name)
                           .PutAsync(stream);

                    r = await upload;
                }
                productRepos.Addproduct(product, r);


                return View();
            }
        }
        [HttpPost]
        public IActionResult Deleteproduct(string Name)
        {
          
            productRepos.DeleteProduct(Name);
            return RedirectToAction("Products");
        } 
        public async Task<IActionResult> Editproduct(string Name)
        {
            if (Auth == null)
            {
                return RedirectToAction("lOGIN");
            }
            else
            {
                var product = await productRepos.GetProduct(Name);
                ViewBag.name = Name;
                ViewBag.img = product.Img;
                ProductViewModel p = new ProductViewModel();
                p.Img = null;
                p.Name = product.Name;
                p.Price = product.Price;
                p.Quantity = product.Quantity;
                return View(p);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Editproduct(string n,string img, ProductViewModel product)
        {
            if (Auth == null)
            {
               return RedirectToAction("lOGIN");
            }
            else
            {
                var stream = product.Img.OpenReadStream();
                string r = "";
                if (product.Img.Length > 0)
                {
                    var upload = new FirebaseStorage(
                            Bucket

                            ).Child("Pics")
                            .Child(product.Name)
                           .PutAsync(stream);

                    r = await upload;
                }

                productRepos.EditProduct(n, r, product);
                return RedirectToAction("Products");
            }
        }
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            Auth = null;
            return RedirectToAction("Index","Home");
        }
        public IActionResult error()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                Auth = await auth.SignInWithEmailAndPasswordAsync(Model.Email, Model.Password);
                ViewBag.user = Auth.User.Email;
               return  RedirectToAction("Products");
            }
            catch
            {
                ViewBag.error = "Wrong Email or Password";
                return View();
            }
            
        }
    }
}
