using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the sliders meal class
    /// </summary>
    public class SlidersMeal
    {
        /// <summary>
        /// The name of the sliders meal instance
        /// </summary>
        public string Name { get; } = "Sliders Kids Meal";

        /// <summary>
        /// The description of this meal
        /// </summary>
        public string Description { get; } = "Sliders with side and drink";

        /// <summary>
        /// backing field for count property
        /// </summary>
        private uint _countBacking = 5;

        /// <summary>
        /// The number of sliders that come in this meal
        /// </summary>
        public uint Count
        {
            get 
            {
                return _countBacking;
            }
            set
            {
                if (value >= 2 && value <= 4) _countBacking = value;
            }
        }

        /// <summary>
        /// Whether the sliders contain cheese
        /// </summary>
        public bool AmericanCheese { get; set; } = true;

        /// <summary>
        /// backing field for drink choice property
        /// </summary>
        private Milk _drinkChoiceBacking = new Milk();

        /// <summary>
        /// Choice of drink for the meal
        /// </summary>
        public Milk DrinkChoice
        {
            get
            {
                return _drinkChoiceBacking;
            }
            set
            {
                _drinkChoiceBacking = value;
            }
        }

        /// <summary>
        /// backing field for side choice property
        /// </summary>
        private Fries _sideChoiceBacking = new Fries()
        {
            FrySize = Size.Kids
        };

        /// <summary>
        /// Choice of side for the meal
        /// </summary>
        public Fries SideChoice
        {
            get
            {
                return _sideChoiceBacking;
            }
            set
            {
                _sideChoiceBacking = value;
            }
        }

        /// <summary>
        /// The total price for this meal
        /// </summary>
        public decimal Price 
        {
            get
            {
                decimal totalPrice = 5.99m;
                if (Count > 2)
                {
                    uint numNugs = Count - 2;
                    totalPrice += numNugs * 2m;
                }
                if (SideChoice.FrySize == Size.Small) totalPrice += 0.50m;
                if (SideChoice.FrySize == Size.Medium) totalPrice += 1.00m;
                if (SideChoice.FrySize == Size.Large) totalPrice += 1.50m;

                return totalPrice;
            }
        }

        /// <summary>
        /// The total amount of calories for this meal
        /// </summary>
        public uint Calories 
        {
            get
            {
                uint cals = 0;

                if(AmericanCheese) cals = Count * 150;
                if (!AmericanCheese) cals = Count * 110;

                cals += SideChoice.Calories;
                cals += DrinkChoice.Calories;

                return cals;
            }
        }

        /// <summary>
        /// The information for preparation of this meal
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new List<string>();

                if (Count != 5) instructions.Add($"{Count} Sliders");
                if (!AmericanCheese) instructions.Add("Hold American Cheese");

                return instructions;
            }
        }
    }
}
