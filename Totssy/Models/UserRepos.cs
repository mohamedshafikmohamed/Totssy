using Firebase.Auth;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Totssy.Models
{
    public class UserRepos : Iuser
    {
        private static string Bucket = "totssy-48fc7.appspot.com";
        private static string ApiKey = "AIzaSyBn4pshdZBeGf0DuoLPETyc6wjdYuRBzhc";

        private readonly FirestoreDb db;
        public UserRepos()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"totssy.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("totssy-48fc7");
        }
        public async void  AddProfile(User u, string img, Registerviewmodel user)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            await auth.CreateUserWithEmailAndPasswordAsync("employee.Email", "employee.Password");
            await db.Collection("users").Document(user.Email).SetAsync(u);
        }

      

        public void EditProfile(string Name, string img, ProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}
