using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the StreetCorn class
    /// </summary>
    public class StreetCorn : Side, IMenuItem
    {
        /// <summary>
        /// The name of the street corn instance
        /// </summary>
        public override string Name { get; } = "Street Corn";

        /// <summary>
        /// The description of this side
        /// </summary>
        public override string Description { get; } = "The zestiest corn out there";

        private bool _cotijaCheese = true;
        /// <summary>
        /// Whether this side contains Cotija Cheese
        /// </summary>
        public bool CotijaCheese 
        {
            get => _cotijaCheese;
            set 
            {
                _cotijaCheese = value;
                OnPropertyChanged(nameof(CotijaCheese));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        private bool _cilantro = true;
        /// <summary>
        /// Whether this side contains Cilantro
        /// </summary>
        public bool Cilantro 
        {
            get => _cilantro;
            set 
            {
                _cilantro= value;
                OnPropertyChanged(nameof(Cilantro));
                OnPropertyChanged(nameof(Calories));
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
                double cals = 300;

                if (!CotijaCheese) cals -= 80;
                if (!Cilantro) cals -= 5;

                if (Size == Size.Kids) cals *= .6;
                if (Size == Size.Small) cals *= .75;
                if (Size == Size.Large) cals *= 1.5;

                return (uint)cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this side
        /// </summary>
        public override IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new ();

                if(!CotijaCheese) instructions.Add("Hold Cotija Cheese");
                if (!Cilantro) instructions.Add("Hold Cilantro");
                instructions.Add($"{Size}");

                return instructions;
            }
        }

        /// <summary>
        /// street corn constructor
        /// </summary>
        public StreetCorn() 
        {
            _size = Size.Medium;
            _defaultPrice = 4.50m;
        }
    }
}
