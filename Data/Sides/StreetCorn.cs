using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the StreetCorn class
    /// </summary>
    public class StreetCorn
    {
        /// <summary>
        /// The name of the street corn instance
        /// </summary>
        public string Name { get; } = "Street Corn";

        /// <summary>
        /// The description of this side
        /// </summary>
        public string Description { get; } = "The zestiest corn out there";

        /// <summary>
        /// Whether this side contains Cotija Cheese
        /// </summary>
        public bool CotijaCheese { get; } = true;

        /// <summary>
        /// Whether this side contains Cilantro
        /// </summary>
        public bool Cilantro { get; } = true;

        /// <summary>
        /// Property for the size of corn
        /// </summary>
        public Size CornSize { get; set; } = Size.Medium;

        /// <summary>
        /// The price for this side
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal price = 4.50m;

                if (CornSize == Size.Kids) price -= 1.25m;
                if (CornSize == Size.Small) price -= 0.75m;
                if (CornSize == Size.Large) price += 1m;

                return price;
            }
        }

        /// <summary>
        /// The total amount of calories for this side
        /// </summary>
        public uint Calories 
        {
            get 
            {
                double cals = 300;

                if (!CotijaCheese) cals -= 80;
                if (!Cilantro) cals -= 5;

                if (CornSize == Size.Kids) cals *= .6;
                if (CornSize == Size.Small) cals *= .75;
                if (CornSize == Size.Large) cals *= 1.5;

                return (uint)cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this side
        /// </summary>
        public IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new ();

                if(!CotijaCheese) instructions.Add("Hold Cotija Cheese");
                if (!Cilantro) instructions.Add("Hold Cilantro");
                instructions.Add($"{CornSize}");

                return instructions;
            }
        }
    }
}
