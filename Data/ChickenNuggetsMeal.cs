using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the chicken nuggets meal class
    /// </summary>
    public class ChickenNuggetsMeal
    {
        /// <summary>
        /// Then name of the chicken nuggets meal instance
        /// </summary>
        public string Name { get; } = "Chicken Nuggets Kids Meal";

        /// <summary>
        /// The description of this meal
        /// </summary>
        public string Description { get; } = "Chicken nuggets with side and drink";

        /// <summary>
        /// backing field for count property
        /// </summary>
        private uint _countBacking = 5;

        /// <summary>
        /// The number of nuggets that come in the meal
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
        private Fries _sideChoiceBacking = new Fries();
   
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
    }
}
