using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the bowl class
    /// </summary>
    public class Bowl : Entree
    {
        /// <summary>
        /// The name of this entree
        /// </summary>
        public override string Name { get; } = "Build-Your-Own Bowl";

        /// <summary>
        /// The description of this entree
        /// </summary>
        public override string Description { get; } = "A bowl you get to build";

        /// <summary>
        /// Price of this menu item
        /// </summary>
        public override decimal Price { get; } = 7.99m;

        /// <summary>
        /// Property for the salsa type of this entree
        /// </summary>
        public abstract Salsa SalsaType { get; set; }
    }
}
