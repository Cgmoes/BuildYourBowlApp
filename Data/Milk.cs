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
        /// Property for the size of fries
        /// </summary>
        public Size MilkSize { get; } = Size.Kids;

        /// <summary>
        /// The price of this drink
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal price = 2.50m;

                if (MilkSize == Size.Kids) price -= 1m;
                if (MilkSize == Size.Small) price -= 0.50m;
                if (MilkSize == Size.Large) price += 0.75m;

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
                double cals = 200;

                if (Chocolate) cals = 270;

                if (MilkSize == Size.Kids) cals *= .6;
                if (MilkSize == Size.Small) cals *= .75;
                if (MilkSize == Size.Large) cals *= 1.5;

                return (uint)cals;
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
                instructions.Add($"{MilkSize}");

                return instructions;
            }
        }
    }
}
