﻿using Firebase.Auth;
using Firebase.Storage;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Totssy.Models
{
    public class ProductRepos : Iproduct
    {
        private readonly FirestoreDb db;
        
        private static string Bucket = "totssy-48fc7.appspot.com";
        private static string ApiKey = "AIzaSyBn4pshdZBeGf0DuoLPETyc6wjdYuRBzhc";
        public ProductRepos()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"totssy.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("totssy-48fc7");
        }
        async void Iproduct.Addproduct(ProductViewModel product,string url)
        {
            Product p = new Product();
            p.Name = product.Name;
            p.Img = url;
            p.Price = product.Price;
            p.Quantity = product.Quantity;
            await db.Collection("Products").Document(p.Name).SetAsync(p);
           

        }

        async  void Iproduct.DeleteProduct(string Name)
        {
            var upload = new FirebaseStorage(
                     Bucket

                     ).Child("Products")
                     .Child(Name)
                    .DeleteAsync();
            await db.Collection("Products").Document(Name).DeleteAsync();

        }

        async void Iproduct.EditProduct(string Name,string img, ProductViewModel product)
        {
            var upload = new FirebaseStorage(
                     Bucket

                     ).Child("Products")
                     .Child(Name)
                    .DeleteAsync();
            await db.Collection("Products").Document(Name).DeleteAsync();
            Product p = new Product();
            p.Name = product.Name;
            p.Img = img;
            p.Price = product.Price;
            p.Quantity = product.Quantity;
            await db.Collection("Products").Document(p.Name).SetAsync(p);
            
        }

        async Task<Product> Iproduct.GetProduct(string Name)
        {
            Query query = db.Collection("Products");
            QuerySnapshot Products = await query.GetSnapshotAsync();
            List<Product> products_List = new List<Product>();
            foreach (DocumentSnapshot product in Products)
            {
                Product p=product.ConvertTo<Product>();
                if (p.Name == Name) return p;
            }
            return null;
        }

        async Task<IEnumerable<Product>> Iproduct.GetProducts()
        {
            Query query = db.Collection("Products");
            QuerySnapshot Products = await query.GetSnapshotAsync();
            List<Product> products_List = new List<Product>();
            foreach (DocumentSnapshot product in Products)
            {

                Product p = product.ConvertTo<Product>();

                products_List.Add(p);
            }
            return products_List;
        }
        
    }
}
