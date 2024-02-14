using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the CarnitasBowl class
    /// </summary>
    public class CarnitasBowl : IMenuItem
    {
        /// <summary>
        /// The name of the carnitas bowl instance
        /// </summary>
        public string Name { get; } = "Carnitas Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        public string Description { get; } = "Rice bowl with carnitas and extras";

        /// <summary>
        /// Whether this bowl contains carnitas
        /// </summary>
        public bool Carnitas { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains Veggies
        /// </summary>
        public bool Veggies { get; set; } = false;

        /// <summary>
        /// Whether this bowl contains Queso
        /// </summary>
        public bool Queso { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains pinto beans
        /// </summary>
        public bool PintoBeans { get; set; } = true;

        /// <summary>
        /// Property for the salsa type of this bowl
        /// </summary>
        public Salsa SalsaType { get; set; } = Salsa.Medium;

        /// <summary>
        /// Whether this bowl contains guacamole
        /// </summary>
        public bool Guacamole { get; set; } = false;

        /// <summary>
        /// Whether this bowl contains sour cream
        /// </summary>
        public bool SourCream { get; set; } = false;

        /// <summary>
        /// The price of this bowl
        /// </summary>
        public decimal Price 
        {
            get 
            {
                if (Guacamole)
                {
                    return 10.99m;
                }
                else return 9.99m;
            }
        }

        /// <summary>
        /// The total number of calories in this bowl
        /// </summary>
        public uint Calories 
        {
            get 
            {
                uint cals = 680;

                if (!Carnitas) cals -= 210;
                if (!Queso) cals -= 110;
                if (Veggies) cals += 20;
                if (SourCream) cals += 100;
                if (SalsaType == Salsa.None) cals -= 20;
                if (!PintoBeans) cals -= 130;
                if (Guacamole) cals += 150;

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

                if (!Carnitas) instructions.Add("Hold Carnitas");
                if (!Queso) instructions.Add("Hold Queso");
                if (!PintoBeans) instructions.Add("Hold Pinto Beans");
                if (Guacamole) instructions.Add("Add Guacamole");
                if (SourCream) instructions.Add("Add Sour Cream");
                if (SalsaType == Salsa.None) 
                {
                    instructions.Add("Hold Salsa");
                }
                else if(SalsaType != Salsa.Medium) 
                {
                    instructions.Add($"Swap {SalsaType} Salsa");
                }
                if (Veggies) instructions.Add("Add Veggies");

                return instructions;
            }
        }
    }
}
