using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the bowl class
    /// </summary>
    public class Bowl : Entree
    {
        /// <summary>
        /// The name of this entree
        /// </summary>
        public override string Name { get; } = "Build-Your-Own Bowl";

        /// <summary>
        /// The description of this entree
        /// </summary>
        public override string Description { get; } = "A bowl you get to build";

        /// <summary>
        /// constructor for the bowl
        /// </summary>
        public Bowl() 
        {
            BaseIngredient = new IngredientItem(Ingredient.Rice);
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
