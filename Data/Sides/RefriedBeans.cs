using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the RefriedBeans class
    /// </summary>
    public class RefriedBeans : Side, IMenuItem
    {
        /// <summary>
        /// The name of the RefriedBeans instance
        /// </summary>
        public override string Name { get; } = "Refried Beans";

        /// <summary>
        /// The description of this side
        /// </summary>
        public override string Description { get; } = "Beans fried not just once but twice";

        private bool _onions = true;
        /// <summary>
        /// Whether this side contains onions
        /// </summary>
        public bool Onions 
        {
            get => _onions;
            set 
            {
                _onions = value;
                OnPropertyChanged(nameof(Onions));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        private bool _cheese = true;
        /// <summary>
        /// Whether this side contains cheddar cheese
        /// </summary>
        public bool CheddarCheese 
        {
            get => _cheese;
            set 
            {
                _cheese = value;
                OnPropertyChanged(nameof(CheddarCheese));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// Total amount of calories in this side
        /// </summary>
        public override uint Calories 
        {
            get 
            {
                double cals = 300;

                if (!CheddarCheese) cals -= 90;
                if (!Onions) cals -= 5;

                if (Size == Size.Kids) cals *= .6;
                if (Size == Size.Small) cals *= .75;
                if (Size == Size.Large) cals *= 1.5;

                return (uint)cals;
            }
        }

        /// <summary>
        /// Information for preparation of this side
        /// </summary>
        public override IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new List<string>();

                if (!Onions) instructions.Add("Hold Onions");
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                instructions.Add($"{Size}");

                return instructions;
            }
        }

        /// <summary>
        /// refried beans constructor
        /// </summary>
        public RefriedBeans() 
        {
            _size = Size.Medium;
            _defaultPrice = 3.75m;
        }

        /// <summary>
        /// Override the equals method to compare properties
        /// </summary>
        /// <param name="o">The object to compare</param>
        /// <returns>if the objects are equal</returns>
        public override bool Equals(object? o)
        {
            RefriedBeans? r = o as RefriedBeans;
            if (r == null) return false;
            else if (r.Size.Equals(this.Size) && r.CheddarCheese.Equals(this.CheddarCheese) && r.Onions.Equals(this.Onions))
            {
                return true;
            }
            else return false;
        }
    }
}
