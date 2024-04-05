using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the sliders meal class
    /// </summary>
    public class SlidersMeal : KidsMeal, IMenuItem
    {

        private bool _americanCheese = true;
        /// <summary>
        /// Whether the sliders contain cheese
        /// </summary>
        public bool AmericanCheese 
        {
            get => _americanCheese;
            set 
            {
                _americanCheese = value;
                OnPropertyChanged(nameof(AmericanCheese));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The total price for this meal
        /// </summary>
        public override decimal Price 
        {
            get
            {
                decimal totalPrice = 5.99m;
                if (KidsCount > 2)
                {
                    uint numNugs = KidsCount - 2;
                    totalPrice += numNugs * 2m;
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
        /// The total amount of calories for this meal
        /// </summary>
        public override uint Calories 
        {
            get
            {
                uint cals = 0;

                if(AmericanCheese) cals = KidsCount * 150;
                if (!AmericanCheese) cals = KidsCount * 110;

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

                if (KidsCount != 2) instructions.Add($"{KidsCount} Sliders");
                if (!AmericanCheese) instructions.Add("Hold American Cheese");
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
        /// constructor for sliders meal
        /// </summary>
        public SlidersMeal() 
        {
            Name = "Sliders Kids Meal";
            Description = "Sliders with side and drink";
            _defaultKidsCount = 2;
            _minCount = 2;
            _maxCount = 4;
            _sideChoiceBacking = new Fries() { Size = Size.Kids };
            _drinkBacking = new Milk() { Size = Size.Kids };


            _drinkBacking.PropertyChanged += HandleItemPropertyChanged;
            _sideChoiceBacking.PropertyChanged += HandleItemPropertyChanged;
        }
    }
}
