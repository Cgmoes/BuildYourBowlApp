using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Class definition for entree
    /// </summary>
    public abstract class Entree : IMenuItem
    {
        /// <summary>
        /// The name of this entree
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of this entree
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Price of this menu item
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Calories of this menu item
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Property for the salsa type of this entree
        /// </summary>
        public abstract Salsa SalsaType { get; set; }

        /// <summary>
        /// Information for the preparation of this menu item
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        /// <summary>
        /// Base ingredient of the menu item
        /// </summary>
        public abstract Ingredient BaseIngredient { get; }

        /// <summary>
        /// Additional ingredients in the menu item
        /// </summary>
        public abstract List<IngredientItem> AdditionalIngredients { get; }
    }
}
