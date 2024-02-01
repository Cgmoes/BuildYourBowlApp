using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the ClassicNachos class
    /// </summary>
    public class ClassicNachos
    {
        /// <summary>
        /// The name of the classic nachos instance
        /// </summary>
        public string Name { get; } = "Classic Nachos";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        public string Description { get; } = "Standard nachos with steak, chicken, and cheese";

        /// <summary>
        /// Whether this bowl contains steak
        /// </summary>
        public bool Steak { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains Chicken
        /// </summary>
        public bool Chicken { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains Queso
        /// </summary>
        public bool Queso { get; set; } = true;

        /// <summary>
        /// Property for the salsa type of this bowl
        /// </summary>
        public Salsa SalsaType { get; set; } = Salsa.Medium;

        /// <summary>
        /// Whether this bowl contains Guacamole
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
                    return 13.99m;
                }
                else return 12.99m;
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

                if (!Chicken) cals -= 150;
                if (!Steak) cals -= 180;
                if (!Queso) cals -= 110;
                if (!SourCream) cals -= 100;
                if (SalsaType == Salsa.None) cals -= 20;
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

                if (!Chicken) instructions.Add("Hold Chicken");
                if (!Steak) instructions.Add("Hold Steak");
                if (!Queso) instructions.Add("Hold Queso");
                if (SourCream) instructions.Add("Add Sour Cream");
                if (SalsaType == Salsa.None)
                {
                    instructions.Add("Hold Salsa");
                }
                else if (SalsaType != Salsa.Medium)
                {
                    instructions.Add($"Swap {SalsaType} Salsa");
                }
                if (Guacamole) instructions.Add("Add Guacamole");

                return instructions;
            }
        }
    }
}
