using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// Implementation of Property changed event handler from interface
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Handles if a property was changed for children classes
        /// </summary>
        /// <param name="propertyName">name of property changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
                foreach (KeyValuePair<Ingredient, IngredientItem> i in PossibleToppings)
                {
                    if (i.Value.Included) 
                    {
                        price += i.Value.UnitCost;
                    }
                }

                return price;
            } 
        }

        /// <summary>
        /// Base ingredient of the menu item
        /// </summary>
        public virtual IngredientItem BaseIngredient { get; protected set; } = new IngredientItem(Ingredient.Rice);

        /// <summary>
        /// Calories of this menu item
        /// </summary>
        public virtual uint Calories 
        {
            get
            {
                uint additionalToppingsCals = 0;
                
                foreach (KeyValuePair<Ingredient, IngredientItem> i in PossibleToppings) 
                {
                    if (i.Value.Included) 
                    {
                        additionalToppingsCals += i.Value.Calories;
                    }
                }
                if (SalsaType != Salsa.None)
                {
                    additionalToppingsCals += 20;
                }
                return BaseIngredient.Calories + additionalToppingsCals;
            }
        }

        public Salsa _salsa;
        /// <summary>
        /// Property for the salsa type of this entree
        /// </summary>
        public virtual Salsa SalsaType 
        {
            get => _salsa;
            set 
            {
                _salsa = value;
                OnPropertyChanged(nameof(SalsaType));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

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

                foreach (KeyValuePair<Ingredient, IngredientItem> i in PossibleToppings) 
                {
                    if (i.Value.Included == true && i.Value.Default == false)
                    {
                        instructions.Add($"Add {i.Value.Name}");
                    }
                    else if (i.Value.Included == false && i.Value.Default == true) 
                    {
                        instructions.Add($"Hold {i.Value.Name}");
                    }
                }

                if (SalsaType == Salsa.None)
                {
                    instructions.Add($"Hold Salsa");
                }
                else if (SalsaType != DefaultSalsa)
                {
                    instructions.Add($"Swap {SalsaType.ToString()} Salsa");
                }

                return instructions;
            } 
        }

        /// <summary>
        /// Additional ingredients in the menu item
        /// </summary>
        public Dictionary<Ingredient, IngredientItem> PossibleToppings { get; } = new Dictionary<Ingredient, IngredientItem>();

        /// <summary>
        /// Constructor for entree object
        /// </summary>
        public Entree() 
        {
            foreach (Ingredient i in Enum.GetValues(typeof(Ingredient))) 
            {
                IngredientItem ingredient = new IngredientItem(i);
                PossibleToppings.Add(ingredient.IngredientType, new IngredientItem(i));
            }
        }
    }
}
