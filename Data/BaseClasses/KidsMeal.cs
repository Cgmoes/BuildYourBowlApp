using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Class definition for kids meal
    /// </summary>
    public abstract class KidsMeal : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Implementation of Property changed event handler from interface
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Handles if a property was changed for children classes
        /// </summary>
        /// <param name="propertyName">name of property changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Name of the kids meal
        /// </summary>
        public virtual string Name { get; set; } = "Kids Meal";

        /// <summary>
        /// Description of the kids meal
        /// </summary>
        public virtual string Description { get; set; } = "Kids Meal Description";

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
            get => _drinkBacking;
            set
            {
                _drinkBacking = value;
                OnPropertyChanged(nameof(DrinkChoice));
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                _drinkBacking.PropertyChanged += HandleItemPropertyChanged;
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
            get => _sideChoiceBacking;
            set
            {
                _sideChoiceBacking = value;
                OnPropertyChanged(nameof(SideChoice));
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                _sideChoiceBacking.PropertyChanged += HandleItemPropertyChanged;
            }
        }

        /// <summary>
        /// backing field for count property
        /// </summary>
        protected uint _minCount;

        /// <summary>
        /// max count for the meal
        /// </summary>
        protected uint _maxCount;

        /// <summary>
        /// The count for the meal
        /// </summary>
        public uint KidsCount
        {
            get => _minCount;
            set
            {
                if (value >= _minCount && value <= _maxCount) 
                {
                    _minCount = value;
                    OnPropertyChanged(nameof(KidsCount));
                    OnPropertyChanged(nameof(PreparationInformation));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        /// <summary>
        /// method to override toString
        /// </summary>
        /// <returns>the name of the object</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Handles the property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(Calories));
            OnPropertyChanged(nameof(PreparationInformation));
        }
    }
}
