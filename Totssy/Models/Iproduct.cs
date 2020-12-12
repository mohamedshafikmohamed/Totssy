using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Totssy.Models
{
    public interface Iproduct
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string Name);
        void Addproduct(ProductViewModel product,string r);
        void  DeleteProduct(string Name);
        void EditProduct(string Name,string img, ProductViewModel product);
    }
}
