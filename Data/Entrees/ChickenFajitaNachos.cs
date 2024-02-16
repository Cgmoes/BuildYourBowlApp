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
        /// Default constructor for chicken fajita nachos
        /// </summary>
        public ChickenFajitaNachos() 
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(new IngredientItem(Ingredient.Chicken) { Default = true, Included = true });
            PossibleToppings.Add(new IngredientItem(Ingredient.Veggies) { Default = true, Included = true });
            PossibleToppings.Add(new IngredientItem(Ingredient.Queso) { Default = true, Included = true });
            PossibleToppings.Add(new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(new IngredientItem(Ingredient.SourCream) { Default = true, Included = true });

            //Pick Salsa Choice
            SalsaType = Salsa.Medium;
            DefaultSalsa = Salsa.Medium;
        }
    }
}
