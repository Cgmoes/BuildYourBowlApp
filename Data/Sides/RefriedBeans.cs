﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the RefriedBeans class
    /// </summary>
    public class RefriedBeans
    {
        /// <summary>
        /// The name of the RefriedBeans instance
        /// </summary>
        public string Name { get; } = "Refried Beans";

        /// <summary>
        /// The description of this side
        /// </summary>
        public string Description { get; } = "Beans fried not just once but twice";

        /// <summary>
        /// Whether this side contains onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this side contains cheddar cheese
        /// </summary>
        public bool CheddarCheese { get; set; } = true;

        /// <summary>
        /// Property for the size of Beans
        /// </summary>
        public Size BeansSize { get; set; } = Size.Medium;

        /// <summary>
        /// The price of this side
        /// </summary>
        public decimal Price 
        {
            get
            {
                decimal price = 3.75m;

                if (BeansSize == Size.Kids) price -= 1m;
                if (BeansSize == Size.Small) price -= 0.50m;
                if (BeansSize == Size.Large) price += 0.75m;

                return price;
            }
        }

        /// <summary>
        /// Total amount of calories in this side
        /// </summary>
        public uint Calories 
        {
            get 
            {
                double cals = 300;

                if (!CheddarCheese) cals -= 90;
                if (!Onions) cals -= 5;

                if (BeansSize == Size.Kids) cals *= .6;
                if (BeansSize == Size.Small) cals *= .75;
                if (BeansSize == Size.Large) cals *= 1.5;

                return (uint)cals;
            }
        }

        /// <summary>
        /// Information for preparation of this side
        /// </summary>
        public IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new List<string>();

                if (!Onions) instructions.Add("Hold Onions");
                if (CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                instructions.Add($"{BeansSize}");

                return instructions;
            }
        }
    }
}
