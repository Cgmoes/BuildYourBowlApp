using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the AguaFresca class
    /// </summary>
    public class AguaFresca : Drink, IMenuItem
    {
        /// <summary>
        /// The name of the agua fresca instance
        /// </summary>
        public override string Name { get; } = "Agua Fresca";

        /// <summary>
        /// The description of this drink
        /// </summary>
        public override string Description { get; } = "Refreshing lightly sweetened fruit drink";

        public Flavor _drinkFlavor = Flavor.Limonada;
        /// <summary>
        /// The flavor of this drink
        /// </summary>
        public Flavor DrinkFlavor 
        {
            get => _drinkFlavor;
            set 
            {
                _drinkFlavor = value;
                OnPropertyChanged(nameof(DrinkFlavor));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

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
        /// The price of this drink
        /// </summary>
        public override decimal Price 
        {
            get 
            {
                decimal price = 3.00m;

                if (Size == Size.Kids) price -= 1.00m;
                if (Size == Size.Small) price -= 0.50m;
                if (Size == Size.Large) price += 0.75m;
                if (DrinkFlavor == Flavor.Tamarind) price += 0.50m;

                return price;
            }
        }

        /// <summary>
        /// The total amount of calories for this drink
        /// </summary>
        public override uint Calories 
        {
            get 
            {
                double cals = 125;

                if (DrinkFlavor == Flavor.Tamarind || DrinkFlavor == Flavor.Strawberry) cals += 25;
                if (DrinkFlavor == Flavor.Cucumber) cals -= 50;
                if (!Ice) cals += 10;

                //Scale drink price according to size
                if (Size == Size.Kids) cals *= .60;
                if (Size == Size.Small) cals *= .75;
                if (Size == Size.Large) cals *= 1.50;

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

                instructions.Add($"{Size}");
                instructions.Add($"{DrinkFlavor}");
                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }

        /// <summary>
        /// Constructor for agua fresca
        /// </summary>
        public AguaFresca() 
        {
            _size = Size.Medium;
        }
    }
}
