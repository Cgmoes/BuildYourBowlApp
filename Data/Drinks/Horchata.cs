using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the Horchata class
    /// </summary>
    public class Horchata : Drink, IMenuItem
    {
        /// <summary>
        /// The name of the horchata instance
        /// </summary>
        public override string Name { get; } = "Horchata";

        /// <summary>
        /// The description of this drink
        /// </summary>
        public override string Description { get; } = "Milky drink with cinnamon";

        private bool _ice = true;
        /// <summary>
        /// Whether this drink contains ice
        /// </summary>
        public bool Ice
        {
            get => _ice;
            set
            {
                _ice = value;
                OnPropertyChanged(nameof(Ice));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The total amount of calories in this drink
        /// </summary>
        public override uint Calories 
        {
            get 
            {
                double cals = 280;

                if (!Ice) cals -= 30;

                if (Size == Size.Kids) cals *= .6;
                if (Size == Size.Small) cals *= .75;
                if (Size == Size.Large) cals *= 1.5;

                return (uint)cals;
            }
        
        }

        /// <summary>
        /// The information for the preparation of this drink
        /// </summary>
        public override IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new List<string>();

                if (!Ice) instructions.Add("Hold Ice");
                instructions.Add($"{Size}");

                return instructions;
            }
        }

        /// <summary>
        /// Constructor for horchata
        /// </summary>
        public Horchata() 
        {
            _size = Size.Medium;
            _defaultPrice = 3.50m;
        }
    }
}
