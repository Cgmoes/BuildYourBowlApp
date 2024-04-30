using BuildYourBowl.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Pages
{
    public static class ReviewDatabase
    {
        private static List<Review> _reviews;
        public static IEnumerable<Review> Reviews => _reviews;

        static ReviewDatabase() 
        {
            if (File.Exists("reviews.json")) 
            {
                string json = File.ReadAllText("reviews.json");

                _reviews = JsonConvert.DeserializeObject<List<Review>>(json);
            }
            if (_reviews == null) _reviews = new List<Review>();
        }

        public static void AddReview(string text) 
        {
            if(text != null && text != "") 
            {
                _reviews.Add(new Review(text));

                File.WriteAllText("reviews.json", JsonConvert.SerializeObject(Reviews));
            }
        }
    }
}
