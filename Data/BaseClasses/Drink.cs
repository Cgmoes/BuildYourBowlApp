using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    public abstract class Drink : IMenuItem
    {
        /// <summary>
        /// The name of this drink
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of this drink
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The size of the drink
        /// </summary>
        public virtual Size Size { get; set; }

        /// <summary>
        /// backing field for price property
        /// </summary>
        protected decimal _defaultPrice;

        /// <summary>
        /// price of the drink
        /// </summary>
        public virtual decimal Price 
        {
            get 
            {
                decimal price = _defaultPrice;

                if (Size == Size.Kids) price -= 1m;
                if (Size == Size.Small) price -= 0.50m;
                if (Size == Size.Large) price += 0.75m;

                return price;
            }
        }

        /// <summary>
        /// calories of the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// preparation information for the drink
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }
    }
}
