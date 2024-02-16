using System;
using System.Collections.Generic;
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

                foreach (IngredientItem i in PossibleToppings) 
                {
                    if (i.Included) 
                    {
                        if(i.Equals(Ingredient.Guacamole))
                        {
                            price = 10.99m;
                        }
                    }
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
            PossibleToppings.Add(new IngredientItem(Ingredient.Carnitas) { Default = true, Included = true}); ;
            PossibleToppings.Add(new IngredientItem(Ingredient.Queso) { Default = true, Included = true });
            PossibleToppings.Add(new IngredientItem(Ingredient.PintoBeans) { Default = true, Included = true });
            PossibleToppings.Add(new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(new IngredientItem(Ingredient.SourCream));
            PossibleToppings.Add(new IngredientItem(Ingredient.Veggies));

            //Pick Salsa Choice
            SalsaType = Salsa.Medium;
            DefaultSalsa = Salsa.Medium;
        }
    }
}
