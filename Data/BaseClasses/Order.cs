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
        /// <summary>
        /// Count of the order
        /// </summary>
        public int Count => throw new NotImplementedException();

        /// <summary>
        /// If the order is read only
        /// </summary>
        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Adds menu item to collection
        /// </summary>
        /// <param name="item">item to add</param>
        /// <exception cref="NotImplementedException">thrown if not implemented correctly</exception>
        public void Add(IMenuItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        /// <exception cref="NotImplementedException">thrown if not implemented correctly</exception>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if menu contains the item
        /// </summary>
        /// <param name="item">item to check</param>
        /// <returns>a bool if it is contained</returns>
        /// <exception cref="NotImplementedException">thrown if not implemented correctly</exception>
        public bool Contains(IMenuItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copies an array
        /// </summary>
        /// <param name="array">array to copy</param>
        /// <param name="arrayIndex">Array index to copy</param>
        /// <exception cref="NotImplementedException">thrown if not implemented correctly</exception>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// enumerates through the collection
        /// </summary>
        /// <returns>the enumeration</returns>
        /// <exception cref="NotImplementedException">thrown if not implemented correctly</exception>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// removes an item from the collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns>whether the item was removed</returns>
        /// <exception cref="NotImplementedException">thrown if not implemented correctly</exception>
        public bool Remove(IMenuItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an enumeration
        /// </summary>
        /// <returns>An enumeration</returns>
        /// <exception cref="NotImplementedException">thrown if not implemented correctly</exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// subtotal of the order
        /// </summary>
        public decimal Subtotal { get; }

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
