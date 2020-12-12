using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Totssy.Models;

namespace Totssy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Iproduct productRepos;
        public HomeController(ILogger<HomeController> logger,Iproduct _productRepos)
        {
            productRepos = _productRepos;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var products= await productRepos.GetProducts();
            return View(products.ToList());
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
