using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Class definition for entree
    /// </summary>
    public abstract class Entree : IMenuItem
    {
        /// <summary>
        /// The name of this entree
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of this entree
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Price of this menu item
        /// </summary>
        public virtual decimal Price 
        { 
            get 
            {
                decimal price = 7.99m;
                foreach (IngredientItem i in PossibleToppings)
                {
                    if (i.Included) 
                    {
                        price += i.UnitCost;
                    }
                }

                return price;
            } 
        }

        /// <summary>
        /// Base ingredient of the menu item
        /// </summary>
        public virtual IngredientItem BaseIngredient { get; protected set; }

        /// <summary>
        /// Calories of this menu item
        /// </summary>
        public virtual uint Calories 
        {
            get
            {
                uint additionalToppingsCals = 0;
                
                foreach (IngredientItem i in PossibleToppings) 
                {
                    if (i.Included) 
                    {
                        additionalToppingsCals += i.Calories;
                    }
                }
                if (SalsaType != Salsa.None)
                {
                    additionalToppingsCals += 20;
                }
                return BaseIngredient.Calories + additionalToppingsCals;
            }
        }

        /// <summary>
        /// Property for the salsa type of this entree
        /// </summary>
        public virtual Salsa SalsaType { get; protected set; }

        /// <summary>
        /// Property for the salsa type of this entree
        /// </summary>
        public virtual Salsa DefaultSalsa { get; protected set; } = Salsa.Medium;

        /// <summary>
        /// Information for the preparation of this menu item
        /// </summary>
        public virtual IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new();

                foreach (IngredientItem i in PossibleToppings) 
                {
                    if (i.Included == true && i.Default == false)
                    {
                        instructions.Add($"Add {i.Name}");
                    }
                    else if (i.Included == false && i.Default == true) 
                    {
                        instructions.Add($"Hold {i.Name}");
                    }
                    if (SalsaType == Salsa.None)
                    {
                        instructions.Add($"Swap {SalsaType.ToString()}");
                    }
                    else if (SalsaType != DefaultSalsa) 
                    {
                        instructions.Add($"Swap {SalsaType.ToString()}");
                    }
                }

                return instructions;
            } 
        }

        /// <summary>
        /// Additional ingredients in the menu item
        /// </summary>
        public List<IngredientItem> PossibleToppings { get; } = new List<IngredientItem>();

        /// <summary>
        /// Constructor for entree object
        /// </summary>
        public Entree() 
        {
            foreach (Ingredient i in Enum.GetValues(typeof(Ingredient))) 
            {
                IngredientItem ingredient = new IngredientItem(i);
                PossibleToppings.Add(ingredient);
            }
        }
    }
}
