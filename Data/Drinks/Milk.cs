using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the milk class
    /// </summary>
    public class Milk : Drink, IMenuItem
    {
        /// <summary>
        /// The name of the Milk instance
        /// </summary>
        public override string Name { get; } = "Milk";

        /// <summary>
        /// The definition of the drink
        /// </summary>
        public override string Description { get; } = "Creamy beverage in plain or chocolate";

        private bool _chocolate = false;
        /// <summary>
        /// Whether this drink contains chocolate
        /// </summary>
        public bool Chocolate 
        {
            get => _chocolate;
            set 
            {
                _chocolate = value;
                OnPropertyChanged(nameof(Chocolate));
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
                uint cals = 200;

                if (Chocolate) cals += 70;

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this drink
        /// </summary>
        public override IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new ();

                if (Chocolate) instructions.Add("Chocolate");
                instructions.Add($"{Size}");

                return instructions;
            }
        }

        /// <summary>
        /// Constructor for milk
        /// </summary>
        public Milk() 
        {
            _defaultPrice = 2.50m;
            _size = Size.Medium;
        }

        /// <summary>
        /// Override the equals method to compare properties
        /// </summary>
        /// <param name="o">The object to compare</param>
        /// <returns>if the objects are equal</returns>
        public override bool Equals(object? o)
        {
            Milk? m = o as Milk;
            if (m == null) return false;
            else if (m.Size.Equals(this.Size) && m.Chocolate.Equals(this.Chocolate))
            {
                return true;
            }
            else return false;
        }
    }
}
