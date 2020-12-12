using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Totssy.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public IFormFile Img { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
