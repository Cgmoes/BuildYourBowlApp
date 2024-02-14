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
    public class CornDogBitesMeal : IMenuItem
    {
        /// <summary>
        /// The name of the corn dog bites meal instance
        /// </summary>
        public string Name { get; set; } = "Corn Dog Bites Kids Meal";

        /// <summary>
        /// The description of this meal
        /// </summary>
        public string Description { get; } = "Mini corn dogs with side and drink";

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
                if (value >= 5 && value <= 8) _countBacking = value;
            }
        }

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
        /// The price of this meal
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal totalPrice = 5.99m;
                if (Count > 5)
                {
                    uint numNugs = Count - 5;
                    totalPrice += numNugs * .75m;
                }
                if (SideChoice.FrySize == Size.Small) totalPrice += 0.50m;
                if (SideChoice.FrySize == Size.Medium) totalPrice += 1.00m;
                if (SideChoice.FrySize == Size.Large) totalPrice += 1.50m;
                if (DrinkChoice.MilkSize == Size.Small) totalPrice += 0.50m;
                if (DrinkChoice.MilkSize == Size.Medium) totalPrice += 1.00m;
                if (DrinkChoice.MilkSize == Size.Large) totalPrice += 1.50m;

                return totalPrice;
            }
        }

        /// <summary>
        /// The total number of calories in this meal
        /// </summary>
        public uint Calories
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
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new List<string>();

                if (Count != 5) instructions.Add($"{Count} Bites");

                return instructions;
            }
        }
    }
}
