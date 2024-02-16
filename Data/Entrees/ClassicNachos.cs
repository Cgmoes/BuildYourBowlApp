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
    public class ClassicNachos : Nacho, IMenuItem
    {
        /// <summary>
        /// The name of the classic nachos instance
        /// </summary>
        public override string Name { get; } = "Classic Nachos";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        public override string Description { get; } = "Standard nachos with steak, chicken, and cheese";

        /// <summary>
        /// The price of these nachos
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 12.99m;

                foreach (IngredientItem i in PossibleToppings)
                {
                    if (i.Included)
                    {
                        if (i.Equals(Ingredient.Guacamole))
                        {
                            price = 13.99m;
                        }
                    }
                }
                return price;
            }
        }

        /// <summary>
        /// Sets the default and included values for ingredients
        /// </summary>
        public void SetDefaultsAndIncluded() 
        {
            IngredientItem steak = new(Ingredient.Steak);
            steak.Default = true;
            steak.Included = true;

            IngredientItem chicken = new(Ingredient.Chicken);
            chicken.Default = true;
            chicken.Included = true;

            IngredientItem queso = new(Ingredient.Queso);
            queso.Default = true;
            queso.Included = true;

            IngredientItem guac = new(Ingredient.Guacamole);
            guac.Default = false;
            guac.Included = false;

            IngredientItem sourCream = new(Ingredient.SourCream);
            sourCream.Default = false;
            sourCream.Included = false;
        }

        /// <summary>
        /// Default Constructor for classic nachos
        /// </summary>
        public ClassicNachos()
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(new IngredientItem(Ingredient.Steak));
            PossibleToppings.Add(new IngredientItem(Ingredient.Chicken));
            PossibleToppings.Add(new IngredientItem(Ingredient.Queso));
            PossibleToppings.Add(new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(new IngredientItem(Ingredient.SourCream));

            //Pick Salsa Choice
            SalsaType = Salsa.Medium;
            DefaultSalsa = Salsa.Medium;
        }
    }
}
