using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// definition for order class
    /// </summary>
    public class Order : ICollection<IMenuItem>
    {
        private readonly List<IMenuItem> items = new List<IMenuItem>();

        /// <summary>
        /// Count of the order
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        /// If the order is read only
        /// </summary>
        public bool IsReadOnly => true;

        /// <summary>
        /// Adds menu item to collection
        /// </summary>
        /// <param name="item">item to add</param>
        public void Add(IMenuItem item)
        {
            items.Add(item);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        public void Clear()
        {
            items.Clear();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if menu contains the item
        /// </summary>
        /// <param name="item">item to check</param>
        /// <returns>a bool if it is contained</returns>
        public bool Contains(IMenuItem item)
        {
            return items.Contains(item);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Copies an array
        /// </summary>
        /// <param name="array">array to copy</param>
        /// <param name="arrayIndex">Array index to copy</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// enumerates through the collection
        /// </summary>
        /// <returns>the enumeration</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return items.GetEnumerator();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// removes an item from the collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns>whether the item was removed</returns>
        public bool Remove(IMenuItem item)
        {
            return items.Remove(item);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an enumeration
        /// </summary>
        /// <returns>An enumeration</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// subtotal of the order
        /// </summary>
        public decimal Subtotal 
        {
            get 
            {
                return items.Sum(item => item.Price);
            }
        }

        /// <summary>
        /// tax rate
        /// </summary>
        public decimal TaxRate { get; set; } = .0915m;

        /// <summary>
        /// tax of the order
        /// </summary>
        public decimal Tax 
        {
            get 
            {
                return Subtotal * TaxRate;
            }
        }

        /// <summary>
        /// total cost of the order
        /// </summary>
        public decimal Total 
        {
            get 
            {
                return Subtotal + Tax;
            }
        }
    }
}
