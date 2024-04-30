using BuildYourBowl.Data;
using BuildYourBowl.DataTests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class ReviewsModel : PageModel
    {
        public void OnPost()
        {
            ReviewDatabase.AddReview(ReviewText);
            ReviewText = null;
        }

        public string ReviewText { get; set; }
    }
}
