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
        /// Whether this bowl contains steak
        /// </summary>
        public bool Steak { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains Veggies
        /// </summary>
        public bool Veggies { get; set; } = false;

        /// <summary>
        /// Whether this bowl contains Queso
        /// </summary>
        public bool Queso { get; set; } = true;

        /// <summary>
        /// Whether this bowl contains Guacamole
        /// </summary>
        public bool Guacamole { get; set; } = false;

        /// <summary>
        /// Whether this bowl contains SourCream
        /// </summary>
        public bool SourCream { get; set; } = true;

        /// <summary>
        /// The price of these nachos
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 10.99m;

                foreach (IngredientItem i in PossibleToppings)
                {
                    if (i.Included)
                    {
                        if (i.Equals(Ingredient.Guacamole))
                        {
                            price = 11.99m;
                        }
                    }
                }
                return price;
            }
        }

        /// <summary>
        /// Seets the default and included values for ingredients
        /// </summary>
        public void SetDefaultsAndIncluded() 
        {
            IngredientItem steak = new(Ingredient.Steak);
            steak.Default = true;
            steak.Included = true;

            IngredientItem veggies = new(Ingredient.Veggies);
            veggies.Default = false;
            veggies.Included = false;

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
        /// Default constructor for spicy steak bowl
        /// </summary>
        public SpicySteakBowl() 
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(new IngredientItem(Ingredient.Steak));
            PossibleToppings.Add(new IngredientItem(Ingredient.Veggies));
            PossibleToppings.Add(new IngredientItem(Ingredient.Queso));
            PossibleToppings.Add(new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(new IngredientItem(Ingredient.SourCream));

            //Pick Salsa Choice
            SalsaType = Salsa.Hot;
            DefaultSalsa = Salsa.Hot;
        }
    }
}
