using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definitiona of the Fries class
    /// </summary>
    public class Fries : Side
    {
        /// <summary>
        /// The name of the Fries instance
        /// </summary>
        public override string Name { get; } = "Fries";

        /// <summary>
        /// The description of this side
        /// </summary>
        public override string Description { get; } = "Crispy, salty sticks of deliciousness";

        private bool _isCurly = false;
        /// <summary>
        /// Whether the fries are curly
        /// </summary>
        public bool Curly 
        {
            get => _isCurly;
            set 
            {
                _isCurly = value;
                OnPropertyChanged(nameof(Curly));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The total amount of calories for this side
        /// </summary>
        public override uint Calories 
        {
            get 
            {
                double cals = 350;

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
                List<string> instructions = new();

                if (Curly) instructions.Add("Curly");
                instructions.Add($"{Size}");

                return instructions;
            }
        }

        /// <summary>
        /// fries constructor
        /// </summary>
        public Fries() 
        {
            _size = Size.Medium;
            _defaultPrice = 3.50m;
        }
    }
}
