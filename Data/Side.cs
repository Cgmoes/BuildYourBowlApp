using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    public abstract class Side : IMenuItem
    {
        /// <summary>
        /// The name of the side
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the side
        /// </summary>
        public abstract string Description { get; }

        protected decimal _defaultPrice;

        /// <summary>
        /// The price for this side
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal price = _defaultPrice;

                if (Size == Size.Kids) price -= 1.25m;
                if (Size == Size.Small) price -= 0.75m;
                if (Size == Size.Large) price += 1m;

                return price;
            }
        }

        /// <summary>
        /// The calories of the side
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The preparation information of the side
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        /// <summary>
        /// The size of the side
        /// </summary>
        public virtual Size Size { get; set; }
    }
}
