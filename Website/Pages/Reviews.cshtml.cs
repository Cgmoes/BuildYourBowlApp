using BuildYourBowl.Data;
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

        [BindProperty]
        public string ReviewText { get; set; }

        public IEnumerable<Review> AllReviews => ReviewDatabase.Reviews.OrderByDescending(review => review.ReviewDate);
    }
}
