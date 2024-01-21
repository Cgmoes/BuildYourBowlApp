using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the milk class
    /// </summary>
    public class Milk
    {
        /// <summary>
        /// The name of the Milk instance
        /// </summary>
        public string Name { get; } = "Milk";

        /// <summary>
        /// The definition of the drink
        /// </summary>
        public string Description { get; } = "Creamy beverage in plain or chocolate";

        /// <summary>
        /// Whether this drink contains chocolate
        /// </summary>
        public bool Chocolate { get; set; } = false;

        /// <summary>
        /// The price of this drink
        /// </summary>
        public decimal Price { get; } = 2.50m;

        /// <summary>
        /// The total amount of calories in this drink
        /// </summary>
        public uint Calories 
        {
            get 
            {
                uint cals = 200;

                if (Chocolate) cals = 270;

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this drink
        /// </summary>
        public IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new ();

                if (Chocolate) instructions.Add("Chocolate");

                return instructions;
            }
        }
    }
}
