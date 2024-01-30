using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the Horchata class
    /// </summary>
    public class Horchata
    {
        /// <summary>
        /// The name of the horchata instance
        /// </summary>
        public string Name { get; } = "Horchata";

        /// <summary>
        /// The description of this drink
        /// </summary>
        public string Description { get; } = "Milky drink with cinnamon";

        /// <summary>
        /// Whether this drink contains ice
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// The price of this drink
        /// </summary>
        public decimal Price { get; } = 3.50m;

        /// <summary>
        /// The total amount of calories in this drink
        /// </summary>
        public uint Calories { get; } = 280;

        /// <summary>
        /// The information for the preparation of this drink
        /// </summary>
        public IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new List<string>();

                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }
    }
}
