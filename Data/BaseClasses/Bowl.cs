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
        /// method to override toString
        /// </summary>
        /// <returns>the name of the object</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// constructor for the bowl
        /// </summary>
        public Bowl()
        {
            BaseIngredient = new IngredientItem(Ingredient.Rice);
            _salsa = Salsa.Medium;

            PossibleToppings = new() 
            {
                { Ingredient.Steak, new IngredientItem(Ingredient.Steak)},
                { Ingredient.Chicken, new IngredientItem(Ingredient.Chicken)},
                { Ingredient.Carnitas, new IngredientItem(Ingredient.Carnitas)},
                { Ingredient.Queso, new IngredientItem(Ingredient.Queso)},
                { Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans)},
                { Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans)},
                { Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole)},
                { Ingredient.SourCream, new IngredientItem(Ingredient.SourCream)},
                { Ingredient.Veggies, new IngredientItem(Ingredient.Veggies)}
            };
            /*
            PossibleToppings.Clear();
            PossibleToppings.Add(Ingredient.Steak, new IngredientItem(Ingredient.Steak));
            PossibleToppings.Add(Ingredient.Chicken, new IngredientItem(Ingredient.Chicken));
            PossibleToppings.Add(Ingredient.Carnitas, new IngredientItem(Ingredient.Carnitas));
            PossibleToppings.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso));
            PossibleToppings.Add(Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans));
            PossibleToppings.Add(Ingredient.PintoBeans, new IngredientItem(Ingredient.BlackBeans));
            PossibleToppings.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));
            PossibleToppings.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));
            */
            foreach (IngredientItem ingredient in PossibleToppings.Values)
            {
                ingredient.PropertyChanged += OnToppingsChanged;
            }
        }
    }
}
