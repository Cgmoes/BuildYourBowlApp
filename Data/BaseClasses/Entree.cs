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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SalsaType)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
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
                    i.Value.PropertyChanged += OnToppingsChanged;
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
        public Dictionary<Ingredient, IngredientItem> PossibleToppings { get; set; } = new Dictionary<Ingredient, IngredientItem>();

        /// <summary>
        /// Property to convert the dictionary to list
        /// </summary>
        public List<IngredientItem> PossibleToppingsList => PossibleToppings.Values.ToList();

        /// <summary>
        /// Constructor for entree object
        /// </summary>
        public Entree() 
        {
            foreach (IngredientItem ingredient in PossibleToppings.Values) 
            {
                ingredient.PropertyChanged += OnToppingsChanged;
            }
        }

        /// <summary>
        /// Invokes the properties changed for an item when toppings are changed
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        public void OnToppingsChanged(object? sender, PropertyChangedEventArgs e) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
        }
    }
}
