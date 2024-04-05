using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the CarnitasBowl class
    /// </summary>
    public class CarnitasBowl : Bowl, IMenuItem
    {
        /// <summary>
        /// The name of the carnitas bowl instance
        /// </summary>
        public override string Name { get; } = "Carnitas Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        public override string Description { get; } = "Rice bowl with carnitas and extras";

        /// <summary>
        /// The price of this bowl
        /// </summary>
        public override decimal Price 
        {
            get 
            {
                decimal price = 9.99m;

                if (PossibleToppings[Ingredient.Guacamole].Included)
                {
                    price = 10.99m;
                }
                return price;
            }
        }

        /// <summary>
        /// Constructor for CarnitasBowl
        /// </summary>
        public CarnitasBowl() 
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(Ingredient.Carnitas, new IngredientItem(Ingredient.Carnitas) { Default = true, Included = true}); ;
            PossibleToppings.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream));
            PossibleToppings.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies));

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
