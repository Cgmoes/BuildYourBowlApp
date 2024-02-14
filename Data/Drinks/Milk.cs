﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Definition of the milk class
    /// </summary>
    public class Milk : IMenuItem
    {
        /// <summary>
        /// The name of the Milk instance
        /// </summary>
        public string Name { get; } = "Milk";

        /// <summary>
        /// The definition of the drink
        /// </summary>
        public string Description { get; } = "Creamy beverage in plain or chocolate";

        /// <summary>
        /// Whether this drink contains chocolate
        /// </summary>
        public bool Chocolate { get; set; } = false;

        /// <summary>
        /// Property for the size of Milk
        /// </summary>
        public Size MilkSize { get; } = Size.Kids;

        /// <summary>
        /// The price of this drink
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal price = 2.50m;

                return price;
            }
        }

        /// <summary>
        /// The total amount of calories in this drink
        /// </summary>
        public uint Calories 
        {
            get 
            {
                uint cals = 200;

                if (Chocolate) cals += 70;

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this drink
        /// </summary>
        public IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new ();

                if (Chocolate) instructions.Add("Chocolate");
                instructions.Add($"{MilkSize}");

                return instructions;
            }
        }
    }
}
