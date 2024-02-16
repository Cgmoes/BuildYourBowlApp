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
    public class SlidersMeal : KidsMeal, IMenuItem
    {
        /// <summary>
        /// The name of the sliders meal instance
        /// </summary>
        public override string Name { get; } = "Sliders Kids Meal";

        /// <summary>
        /// The description of this meal
        /// </summary>
        public override string Description { get; } = "Sliders with side and drink";

        /// <summary>
        /// Whether the sliders contain cheese
        /// </summary>
        public bool AmericanCheese { get; set; } = true;

        /// <summary>
        /// The total price for this meal
        /// </summary>
        public override decimal Price 
        {
            get
            {
                decimal totalPrice = 5.99m;
                if (Count > 2)
                {
                    uint numNugs = Count - 2;
                    totalPrice += numNugs * 2m;
                }
                if (_sideChoiceBacking.Size == Size.Small) totalPrice += 0.50m;
                if (_sideChoiceBacking.Size == Size.Medium) totalPrice += 1.00m;
                if (_sideChoiceBacking.Size == Size.Large) totalPrice += 1.50m;
                if (_sideChoiceBacking.Size == Size.Small) totalPrice += 0.50m;
                if (_sideChoiceBacking.Size == Size.Medium) totalPrice += 1.00m;
                if (_sideChoiceBacking.Size == Size.Large) totalPrice += 1.50m;

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
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new List<string>();

                if (Count != 2) instructions.Add($"{Count} Sliders");
                if (!AmericanCheese) instructions.Add("Hold American Cheese");

                return instructions;
            }
        }

        /// <summary>
        /// constructor for sliders meal
        /// </summary>
        public SlidersMeal() 
        {
            _countBacking = 2;
            _maxCount = 4;
            _sideChoiceBacking = new Fries() { Size = Size.Kids };
            _drinkBacking = new Milk() { Size = Size.Kids };
        }
    }
}
