using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the AguaFresca class
    /// </summary>
    public class AguaFresca : IMenuItem
    {
        /// <summary>
        /// The name of the agua fresca instance
        /// </summary>
        public string Name { get; } = "Agua Fresca";

        /// <summary>
        /// The description of this drink
        /// </summary>
        public string Description { get; } = "Refreshing lightly sweetened fruit drink";

        /// <summary>
        /// The flavor of this drink
        /// </summary>
        public Flavor DrinkFlavor { get; set; } = Flavor.Limonada;

        /// <summary>
        /// The size of this drink
        /// </summary>
        public Size DrinkSize { get; set; } = Size.Medium;

        /// <summary>
        /// Whether this drink contains ice
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// The price of this drink
        /// </summary>
        public decimal Price 
        {
            get 
            {
                decimal price = 3.00m;

                if (DrinkSize == Size.Kids) price -= 1.00m;
                if (DrinkSize == Size.Small) price -= 0.50m;
                if (DrinkSize == Size.Large) price += 0.75m;
                if (DrinkFlavor == Flavor.Tamarind) price += 0.50m;

                return price;
            }
        }

        /// <summary>
        /// The total amount of calories for this drink
        /// </summary>
        public uint Calories 
        {
            get 
            {
                double cals = 125;

                if (DrinkFlavor == Flavor.Tamarind || DrinkFlavor == Flavor.Strawberry) cals += 25;
                if (DrinkFlavor == Flavor.Cucumber) cals -= 50;
                if (!Ice) cals += 10;

                //Scale drink price according to size
                if (DrinkSize == Size.Kids) cals *= .60;
                if (DrinkSize == Size.Small) cals *= .75;
                if (DrinkSize == Size.Large) cals *= 1.50;

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

                instructions.Add($"{DrinkSize}");
                instructions.Add($"{DrinkFlavor}");
                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }
    }
}
