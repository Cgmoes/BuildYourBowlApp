using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the chicken nuggets meal class
    /// </summary>
    public class ChickenNuggetsMeal : KidsMeal, IMenuItem
    {
        /// <summary>
        /// The price of this meal
        /// </summary>
        public override decimal Price 
        {
            get 
            {
                decimal totalPrice = 5.99m;
                if (KidsCount > 5) 
                {
                    uint numNugs = KidsCount - 5;
                    totalPrice += numNugs * .75m;
                }
                if (_sideChoiceBacking.Size == Size.Small) totalPrice += 0.50m;
                if (_sideChoiceBacking.Size == Size.Medium) totalPrice += 1.00m;
                if (_sideChoiceBacking.Size == Size.Large) totalPrice += 1.50m;

                if (_drinkBacking.Size == Size.Small) totalPrice += 0.50m;
                if (_drinkBacking.Size == Size.Medium) totalPrice += 1.00m;
                if (_drinkBacking.Size == Size.Large) totalPrice += 1.50m;

                return totalPrice;
            }
        }

        /// <summary>
        /// The total number of calories in this meal
        /// </summary>
        public override uint Calories 
        {
            get 
            {
                uint cals = KidsCount * 60;
                cals += SideChoice.Calories;
                cals += DrinkChoice.Calories;

                return cals;
            }    
        }

        /// <summary>
        /// The information for preparation of this meal
        /// </summary>
        public override IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new List<string>();

                if (KidsCount != 5) instructions.Add($"{KidsCount} Nuggets");
                instructions.Add($"Side: {SideChoice}");
                foreach (string s in SideChoice.PreparationInformation) 
                {
                    instructions.Add($"\t{s}");
                }
                instructions.Add($"Drink: {DrinkChoice}");
                foreach (string s in DrinkChoice.PreparationInformation) 
                {
                    instructions.Add($"\t{s}");
                }

                return instructions;
            }
        }

        /// <summary>
        /// Handles the property
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void HandleItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(Calories));
            OnPropertyChanged(nameof(PreparationInformation));
        }

        /// <summary>
        /// Constructor for chicken nuggets meal
        /// </summary>
        public ChickenNuggetsMeal() 
        {
            Name = "Chicken Nuggets Kids Meal";
            Description = "Chicken nuggets with side and drink";
            _defaultKidsCount = 5;
            _minCount = 5;
            _maxCount = 8;
            _sideChoiceBacking = new Fries() { Size = Size.Kids};
            _drinkBacking = new Milk() { Size = Size.Kids};

            _drinkBacking.PropertyChanged += HandleItemPropertyChanged;
            _sideChoiceBacking.PropertyChanged += HandleItemPropertyChanged;
        }
    }
}
