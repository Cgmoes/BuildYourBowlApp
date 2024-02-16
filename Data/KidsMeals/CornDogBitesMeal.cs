using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the corn dog bites meal clss
    /// </summary>
    public class CornDogBitesMeal : KidsMeal, IMenuItem
    {
        /// <summary>
        /// The name of the corn dog bites meal instance
        /// </summary>
        public override string Name { get; } = "Corn Dog Bites Kids Meal";

        /// <summary>
        /// The description of this meal
        /// </summary>
        public override string Description { get; } = "Mini corn dogs with side and drink";

        /// <summary>
        /// The price of this meal
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal totalPrice = 5.99m;
                if (Count > 5)
                {
                    uint numNugs = Count - 5;
                    totalPrice += numNugs * .75m;
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
        /// The total number of calories in this meal
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = Count * 50;
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

                if (Count != 5) instructions.Add($"{Count} Bites");

                return instructions;
            }
        }

        public CornDogBitesMeal() 
        {
            _countBacking = 5;
            _maxCount = 8;
            _sideChoiceBacking = new Fries() { Size = Size.Kids };
            _drinkBacking = new Milk() { Size = Size.Kids };
        }
    }
}
