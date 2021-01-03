using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Totssy.Models
{
    [FirestoreData]
    public class User
    {
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string age { get; set; }
        [FirestoreProperty]
        public string gender { get; set; }
        [FirestoreProperty]
        public string image { get; set; }

        [FirestoreProperty]
        public bool HaveTotssy { get; set; }
        [FirestoreProperty] 
        public bool ispublic { get; set; }
        [FirestoreProperty]
        public string email { get; set; }
        [FirestoreProperty]
        public string password { get; set; }

        [FirestoreProperty]
        public string phone { get; set; }
        [FirestoreProperty]
        public string pops { get; set; } 
        [FirestoreProperty]
        public List<Links>Links { get; set; }

    }
}
