using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the ChickenFajitaNachos class
    /// </summary>
    public class ChickenFajitaNachos : Nacho, IMenuItem
    {
        /// <summary>
        /// The name of the chicken fajita nachos instance
        /// </summary>
        public override string Name { get; } = "Chicken Fajita Nachos";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        public override string Description { get; } = "Chicken fajitas but with chips";

        /// <summary>
        /// The price of these nachos
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 9.99m;

                foreach (IngredientItem i in PossibleToppings)
                {
                    if (i.Included)
                    {
                        if (i.Equals(Ingredient.Guacamole))
                        {
                            price = 10.99m;
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
            IngredientItem chicken = new(Ingredient.Chicken);
            chicken.Default = true;
            chicken.Included = true;

            IngredientItem veggies = new(Ingredient.Veggies);
            veggies.Default = true;
            veggies.Included = true;

            IngredientItem queso = new(Ingredient.Queso);
            queso.Default = true;
            queso.Included = true;

            IngredientItem guac = new(Ingredient.Guacamole);
            guac.Default = false;
            guac.Included = false;

            IngredientItem sourCream = new(Ingredient.SourCream);
            sourCream.Default = true;
            sourCream.Included = true;
        }

        /// <summary>
        /// Default constructor for chicken fajita nachos
        /// </summary>
        public ChickenFajitaNachos() 
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(new IngredientItem(Ingredient.Chicken));
            PossibleToppings.Add(new IngredientItem(Ingredient.Veggies));
            PossibleToppings.Add(new IngredientItem(Ingredient.Queso));
            PossibleToppings.Add(new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(new IngredientItem(Ingredient.SourCream));

            //Pick Salsa Choice
            SalsaType = Salsa.Medium;
            DefaultSalsa = Salsa.Medium;
        }
    }
}
