using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the SpicySteakBowl class
    /// </summary>
    public class SpicySteakBowl : Bowl, IMenuItem
    {
        /// <summary>
        /// The name os the spicy steak bowl instance
        /// </summary>
        public override string Name { get; } = "Spicy Steak Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        public override string Description { get; } = "Spicy rice bowl with steak and fajita toppings";

        /// <summary>
        /// The price of these nachos
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 10.99m;

                if (PossibleToppings[Ingredient.Guacamole].Included)
                {
                    price = 11.99m;
                }
                return price;
            }
        }

        /// <summary>
        /// Default constructor for spicy steak bowl
        /// </summary>
        public SpicySteakBowl() 
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(Ingredient.Steak, new IngredientItem(Ingredient.Steak) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));
            PossibleToppings.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream) { Default = true, Included = true });

            //Pick Salsa Choice
            SalsaType = Salsa.Hot;
            DefaultSalsa = Salsa.Hot;

            foreach (IngredientItem ingredient in PossibleToppings.Values)
            {
                ingredient.PropertyChanged += OnToppingsChanged;
            }
        }
    }
}
