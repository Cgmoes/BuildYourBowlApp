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

                if (PossibleToppings[Ingredient.Guacamole].Included)
                {
                    price = 13.99m;
                }
                return price;
            }
        }

        /// <summary>
        /// Default Constructor for classic nachos
        /// </summary>
        public ClassicNachos()
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(Ingredient.Steak, new IngredientItem(Ingredient.Steak) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.Chicken, new IngredientItem(Ingredient.Chicken) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));

            //Pick Salsa Choice
            SalsaType = Salsa.Medium;
            DefaultSalsa = Salsa.Medium;

            foreach (IngredientItem ingredient in PossibleToppings.Values)
            {
                ingredient.PropertyChanged += OnToppingsChanged;
            }
        }
    }
}
