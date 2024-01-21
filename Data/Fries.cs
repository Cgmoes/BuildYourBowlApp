using System;
using System.Collections.Generic;
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
        public bool Curly { get; } = false;

        /// <summary>
        /// The price for this side
        /// </summary>
        public decimal Price { get; } = 3.50m;

        /// <summary>
        /// The total amount of calories for this side
        /// </summary>
        public uint Calories { get; } = 350;

        /// <summary>
        /// Information for preparation of this side
        /// </summary>
        public IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new();

                if (Curly) instructions.Add("Curly");

                return instructions;
            }
        }
    }
}
