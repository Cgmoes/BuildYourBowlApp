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
        /// Property for the size of horchata
        /// </summary>
        public Size HorchataSize { get; set; } = Size.Medium;

        /// <summary>
        /// The price of this drink
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal price = 3.50m;

                if (HorchataSize == Size.Kids) price -= 1m;
                if (HorchataSize == Size.Small) price -= 0.50m;
                if (HorchataSize == Size.Large) price += 0.75m;

                return price;
            }
        }

        /// <summary>
        /// The total amount of calories in this drink
        /// </summary>
        public uint Calories 
        {
            get 
            {
                double cals = 280;

                if (!Ice) cals -= 30;

                if (HorchataSize == Size.Kids) cals *= .6;
                if (HorchataSize == Size.Small) cals *= .75;
                if (HorchataSize == Size.Large) cals *= 1.5;

                return (uint)cals;
            }
        
        }

        /// <summary>
        /// The information for the preparation of this drink
        /// </summary>
        public IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new List<string>();

                if (!Ice) instructions.Add("Hold Ice");
                instructions.Add($"{HorchataSize}");

                return instructions;
            }
        }
    }
}
