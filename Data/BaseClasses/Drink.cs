using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    public abstract class Drink : IMenuItem, INotifyPropertyChanged
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
        /// The name of this drink
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of this drink
        /// </summary>
        public abstract string Description { get; }

        public Size _size;
        /// <summary>
        /// The size of the side
        /// </summary>
        public virtual Size Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Price));
            }
        }

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

        /// <summary>
        /// method to override toString
        /// </summary>
        /// <returns>the name of the object</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
