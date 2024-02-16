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
        /// Sets the value of default and included for ingredients in the bowl
        /// </summary>
        public void SetDefaultsAndIncluded() 
        {
            IngredientItem carnitas = new(Ingredient.Carnitas);
            carnitas.Default = true;
            carnitas.Included = true;
            IngredientItem veggies = new(Ingredient.Veggies);
            veggies.Default = false;
            veggies.Included = false;
            IngredientItem queso = new(Ingredient.Queso);
            queso.Default = true;
            queso.Included = true;
            IngredientItem beans = new(Ingredient.PintoBeans);
            beans.Default = true;
            beans.Included = true;
            IngredientItem guac = new(Ingredient.Guacamole);
            guac.Default = false;
            guac.Included = false;
            IngredientItem sourCream = new(Ingredient.SourCream);
            sourCream.Default = false;
            sourCream.Included = false;
        }

        /// <summary>
        /// Constructor for CarnitasBowl
        /// </summary>
        public CarnitasBowl() 
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(new IngredientItem(Ingredient.Carnitas));
            PossibleToppings.Add(new IngredientItem(Ingredient.Queso));
            PossibleToppings.Add(new IngredientItem(Ingredient.PintoBeans));
            PossibleToppings.Add(new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(new IngredientItem(Ingredient.SourCream));
            PossibleToppings.Add(new IngredientItem(Ingredient.Veggies));

            //Pick Salsa Choice
            SalsaType = Salsa.Medium;
            DefaultSalsa = Salsa.Medium;
        }
    }
}
