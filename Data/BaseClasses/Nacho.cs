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

        /// <summary>
        /// Constructor for nacho class
        /// </summary>
        public Nacho()
        {
            BaseIngredient = new IngredientItem(Ingredient.Chips);
            _salsa = Salsa.Medium;

            PossibleToppings.Add(Ingredient.Steak, new IngredientItem(Ingredient.Steak));
            PossibleToppings.Add(Ingredient.Chicken, new IngredientItem(Ingredient.Chicken));
            PossibleToppings.Add(Ingredient.Carnitas, new IngredientItem(Ingredient.Carnitas));
            PossibleToppings.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso));
            PossibleToppings.Add(Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans));
            PossibleToppings.Add(Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans));
            PossibleToppings.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));
            PossibleToppings.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));

            foreach (IngredientItem ingredient in PossibleToppings.Values)
            {
                ingredient.PropertyChanged += OnToppingsChanged;
            }
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
