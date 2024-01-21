using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the SpicySteakBowl class
    /// </summary>
    public class SpicySteakBowl
    {
        /// <summary>
        /// The name os the spicy steak bowl instance
        /// </summary>
        public string Name { get; } = "Spicy Steak Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        public string Description { get; } = "Spicy rice bowl with steak and fajita toppings";

        /// <summary>
        /// Whether this bowl contains steak
        /// </summary>
        public bool Steak { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains Veggies
        /// </summary>
        public bool Veggies { get; set; } = false;

        /// <summary>
        /// Whether this bowl contains Queso
        /// </summary>
        public bool Queso { get; set; } = true;
        /// <summary>
        /// Whether this bowl contains hot salsa
        /// </summary>
        public bool HotSalsa { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains Guacamole
        /// </summary>
        public bool Guacamole { get; set; } = false;

        /// <summary>
        /// Whether this bowl contains SourCream
        /// </summary>
        public bool SourCream { get; set; } = true;

        /// <summary>
        /// The price of this bowl
        /// </summary>
        public decimal Price 
        {
            get 
            {
                if (Guacamole)
                {
                    return 11.99m;
                }
                else return 10.99m;
            }
        }

        /// <summary>
        /// The total number of calories in this bowl
        /// </summary>
        public uint Calories 
        {
            get 
            {
                uint cals = 640;

                if (!Steak) cals -= 180;
                if (!Queso) cals -= 110;
                if (!Veggies) cals -= 20;
                if (!SourCream) cals -= 100;
                if (!HotSalsa) cals -= 20;
                if (!Guacamole) cals -= 150;

                return cals;
            }
        }

        /// <summary>
        /// Information for preparation of this bowl
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (!Steak) instructions.Add("Hold Steak");
                if (!Queso) instructions.Add("Hold Queso");
                if (Veggies) instructions.Add("Add Veggies");
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (!HotSalsa) instructions.Add("Hold Hot Salse");
                if (Guacamole) instructions.Add("Add Guacamole");

                return instructions;
            }
        }
    }
}
