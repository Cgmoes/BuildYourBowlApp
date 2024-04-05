using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Specialized;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// definition for order class
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public readonly List<IMenuItem> _items = new List<IMenuItem>();

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Count of the order
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// If the order is read only
        /// </summary>
        public bool IsReadOnly => true;

        #region CollectionImplementation

        /// <summary>
        /// Adds menu item to collection
        /// </summary>
        /// <param name="item">item to add</param>
        public void Add(IMenuItem item)
        {
            _items.Add(item);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            item.PropertyChanged += HandleItemPropertyChanged;
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        public void Clear()
        {
            _items.Clear();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
        }

        /// <summary>
        /// Checks if menu contains the item
        /// </summary>
        /// <param name="item">item to check</param>
        /// <returns>a bool if it is contained</returns>
        public bool Contains(IMenuItem item)
        {
            return _items.Contains(item);
        }

        /// <summary>
        /// Copies an array
        /// </summary>
        /// <param name="array">array to copy</param>
        /// <param name="arrayIndex">Array index to copy</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// enumerates through the collection
        /// </summary>
        /// <returns>the enumeration</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// removes an item from the collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns>whether the item was removed</returns>
        public bool Remove(IMenuItem item)
        {
            int index = _items.IndexOf(item);
            if (index > -1)
            {
                _items.Remove(item);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                item.PropertyChanged += HandleItemPropertyChanged;

                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets an enumeration
        /// </summary>
        /// <returns>An enumeration</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        /// <summary>
        /// subtotal of the order
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                return Math.Round(_items.Sum(item => item.Price), 2);
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            }
        }

        /// <summary>
        /// tax rate
        /// </summary>
        public decimal TaxRate
        {
            get
            {
                return .0915m;
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            }
        }

        /// <summary>
        /// tax of the order
        /// </summary>
        public decimal Tax
        {
            get
            {
                return Math.Round(Subtotal * TaxRate, 2);
            }
        }

        /// <summary>
        /// total cost of the order
        /// </summary>
        public decimal Total
        {
            get
            {
                return Math.Round(Subtotal + Tax, 2);
            }
        }

        private static uint lastNumber = 1;

        /// <summary>
        /// The order number
        /// </summary>
        public uint Number { get; init; }

        /// <summary>
        /// The time the order was placed at
        /// </summary>
        public DateTime PlacedAt { get; init; }

        /// <summary>
        /// Constructor for orders
        /// </summary>
        public Order()
        {
            Number = lastNumber++;
            PlacedAt = DateTime.Now;
        }

        /// <summary>
        /// Handles the property changes to attach to item
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void HandleItemPropertyChanged(object? sender, PropertyChangedEventArgs e) 
        {
            if (e.PropertyName == "Price") 
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
        }
    }
}
