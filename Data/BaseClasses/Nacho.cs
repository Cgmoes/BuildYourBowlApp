using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Class definition for Nacho
    /// </summary>
    public class Nacho : Entree
    {
        /// <summary>
        /// The name of this entree
        /// </summary>
        public override string Name { get; } = "Build-Your-Own Nachos";

        /// <summary>
        /// The description of this entree
        /// </summary>
        public override string Description { get; } = "Nachos you get to build";

        public Nacho()
        {
            BaseIngredient = new IngredientItem(Ingredient.Chips);
            _salsa = Salsa.Medium;
        }

        /// <summary>
        /// method to override toString
        /// </summary>
        /// <returns>the name of the object</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
