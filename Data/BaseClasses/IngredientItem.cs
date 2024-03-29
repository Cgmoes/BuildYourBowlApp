using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Class definition for ingredient items
    /// </summary>
    public class IngredientItem : INotifyPropertyChanged
    {
        /// <summary>
        /// Event handler for changing properties
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The type of ingredient
        /// </summary>
        public Ingredient IngredientType { get; }

        /// <summary>
        /// The name of the ingredient
        /// </summary>
        public string Name
        {
            get
            {
                switch (IngredientType)
                {
                    case Ingredient.BlackBeans: return "Black Beans";
                    case Ingredient.PintoBeans: return "Pinto Beans";
                    case Ingredient.Queso: return "Queso";
                    case Ingredient.Veggies: return "Veggies";
                    case Ingredient.SourCream: return "Sour Cream";
                    case Ingredient.Guacamole: return "Guacamole";
                    case Ingredient.Chicken: return "Chicken";
                    case Ingredient.Steak: return "Steak";
                    case Ingredient.Carnitas: return "Carnitas";
                    case Ingredient.Rice: return "Rice";
                    case Ingredient.Chips: return "Chips";
                    default: return IngredientType.ToString();
                }
            }
        }

        /// <summary>
        /// The amount of calories in the ingredient
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (IngredientType)
                {
                    case Ingredient.BlackBeans: return 130;
                    case Ingredient.PintoBeans: return 130;
                    case Ingredient.Queso: return 110;
                    case Ingredient.Veggies: return 20;
                    case Ingredient.SourCream: return 100;
                    case Ingredient.Guacamole: return 150;
                    case Ingredient.Chicken: return 150;
                    case Ingredient.Steak: return 180;
                    case Ingredient.Carnitas: return 210;
                    case Ingredient.Rice: return 210;
                    case Ingredient.Chips: return 250;
                    default: return 0;
                }
            }
        }

        /// <summary>
        /// The unit cost of each ingredient
        /// </summary>
        public decimal UnitCost
        {
            get
            {
                if (IngredientType == Ingredient.Steak || IngredientType == Ingredient.Chicken || IngredientType == Ingredient.Carnitas) return 2.00m;
                else if (IngredientType == Ingredient.BlackBeans || IngredientType == Ingredient.PintoBeans || IngredientType == Ingredient.Queso || IngredientType == Ingredient.Guacamole) return 1.00m;
                else return 0.00m;
            }
        }

        private bool _included = false;
        /// <summary>
        /// whether the ingredient is included in a containing menu item
        /// </summary>
        public bool Included 
        {
            get => _included;
            set 
            {
                _included = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Included)));
            }
        }

        /// <summary>
        /// whether the ingredient is included in its containing menu item by default
        /// </summary>
        public bool Default { get; set; } = false;

        /// <summary>
        /// Constructor for ingredient item
        /// </summary>
        /// <param name="i">The type of ingredient</param>
        public IngredientItem(Ingredient i) 
        {
            IngredientType = i;
        }
    }
}
