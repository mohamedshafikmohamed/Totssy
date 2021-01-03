using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Totssy.Models
{
    public interface Iuser
    {
        void EditProfile(string Name, string img, ProductViewModel product);
        void AddProfile(User u, string img, Registerviewmodel user);
    }
}
