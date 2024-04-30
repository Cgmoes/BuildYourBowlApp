using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// class definition for review
    /// </summary>
    public class Review
    {
        /// <summary>
        /// The review that was given
        /// </summary>
        public string ReviewText { get; set; }

        /// <summary>
        /// The date and time of the review
        /// </summary>
        public DateTime ReviewDate { get; set; }

        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="text">the text for the review</param>
        public Review(string text) 
        {
            ReviewText = text;
            ReviewDate = DateTime.Now;
        }
    }
}
