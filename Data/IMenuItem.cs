using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Class definition for IMenuItem
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Name of this menu item
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Description of this menu item
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Price of this menu item
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Calories of this menu item
        /// </summary>
        public uint Calories { get; }

        /// <summary>
        /// Information for the preparation of this menu item
        /// </summary>
        public IEnumerable<string> PreparationInformation { get; }
    }
}
