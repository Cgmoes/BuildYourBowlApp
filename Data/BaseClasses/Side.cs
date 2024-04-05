using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    public abstract class Side : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Implementation of Property changed event handler from interface
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Handles if a property was changed for children classes
        /// </summary>
        /// <param name="propertyName">name of property changed</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
        public virtual decimal Price
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

        public Size _size = Size.Medium;
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
        /// method to override toString
        /// </summary>
        /// <returns>the name of the object</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
