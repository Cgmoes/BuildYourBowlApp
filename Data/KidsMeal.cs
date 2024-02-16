using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Class definition for kids meal
    /// </summary>
    public abstract class KidsMeal : IMenuItem
    {
        /// <summary>
        /// Name of the kids meal
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Description of the kids meal
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// price of the meal
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// calories of the meal
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// preparation information for the kids meal
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        /// <summary>
        /// Backing field for drink choice
        /// </summary>
        protected Drink _drinkBacking = new Milk();

        /// <summary>
        /// the choice of drink for the meal
        /// </summary>
        public virtual Drink DrinkChoice 
        {
            get
            {
                return _drinkBacking;
            }
            set
            {
                _drinkBacking = value;
            }
        }

        /// <summary>
        /// backing field for side choice property
        /// </summary>
        protected Side _sideChoiceBacking = new Fries();

        /// <summary>
        /// Choice of side for the meal
        /// </summary>
        public Side SideChoice
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
        /// backing field for count property
        /// </summary>
        protected uint _countBacking;

        /// <summary>
        /// max count for the meal
        /// </summary>
        protected uint _maxCount;

        /// <summary>
        /// The count for the meal
        /// </summary>
        public uint Count
        {
            get
            {
                return _countBacking;
            }
            set
            {
                if (value >= _countBacking && value <= _maxCount) _countBacking = value;
            }
        }
    }
}
