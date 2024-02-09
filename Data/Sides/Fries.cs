using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definitiona of the Fries class
    /// </summary>
    public class Fries
    {
        /// <summary>
        /// The name of the Fries instance
        /// </summary>
        public string Name { get; } = "Fries";

        /// <summary>
        /// The description of this side
        /// </summary>
        public string Description { get; } = "Crispy, salty sticks of deliciousness";

        /// <summary>
        /// Whether the fries are curly
        /// </summary>
        public bool Curly { get; set; } = false;

        /// <summary>
        /// Property for the size of fries
        /// </summary>
        public Size FrySize { get; set; } = Size.Medium;

        /// <summary>
        /// The price for this side
        /// </summary>
        public decimal Price 
        {
            get 
            {
                decimal price = 3.50m;

                if (FrySize == Size.Kids) price -= 1m;
                if (FrySize == Size.Small) price -= 0.50m;
                if (FrySize == Size.Large) price += 0.75m;

                return price;
            }
        }

        /// <summary>
        /// The total amount of calories for this side
        /// </summary>
        //public uint Calories { get; } = 350;
        public uint Calories 
        {
            get 
            {
                double cals = 350;

                if (FrySize == Size.Kids) cals *= .6;
                if (FrySize == Size.Small) cals *= .75;
                if (FrySize == Size.Large) cals *= 1.5;

                return (uint)cals;
            }
        }

        /// <summary>
        /// Information for preparation of this side
        /// </summary>
        public IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new();

                if (Curly) instructions.Add("Curly");
                instructions.Add($"{FrySize}");

                return instructions;
            }
        }
    }
}
