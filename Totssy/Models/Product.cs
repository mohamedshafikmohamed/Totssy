using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Totssy.Models
{

    [FirestoreData]
    public class Product
    {
        [FirestoreProperty]
        public string Name { get; set; }
         [FirestoreProperty]
        public string Img { get; set; }

        [FirestoreProperty]
        public double Price { get; set; }
        [FirestoreProperty]
        public int Quantity { get; set; }
    }
    }
