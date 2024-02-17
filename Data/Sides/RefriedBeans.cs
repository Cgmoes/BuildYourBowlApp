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
    public class RefriedBeans : Side, IMenuItem
    {
        /// <summary>
        /// The name of the RefriedBeans instance
        /// </summary>
        public override string Name { get; } = "Refried Beans";

        /// <summary>
        /// The description of this side
        /// </summary>
        public override string Description { get; } = "Beans fried not just once but twice";

        /// <summary>
        /// Whether this side contains onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this side contains cheddar cheese
        /// </summary>
        public bool CheddarCheese { get; set; } = true;

        /// <summary>
        /// Total amount of calories in this side
        /// </summary>
        public override uint Calories 
        {
            get 
            {
                double cals = 300;

                if (!CheddarCheese) cals -= 90;
                if (!Onions) cals -= 5;

                if (Size == Size.Kids) cals *= .6;
                if (Size == Size.Small) cals *= .75;
                if (Size == Size.Large) cals *= 1.5;

                return (uint)cals;
            }
        }

        /// <summary>
        /// Information for preparation of this side
        /// </summary>
        public override IEnumerable<string> PreparationInformation 
        {
            get 
            {
                List<string> instructions = new List<string>();

                if (!Onions) instructions.Add("Hold Onions");
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                instructions.Add($"{Size}");

                return instructions;
            }
        }

        /// <summary>
        /// refried beans constructor
        /// </summary>
        public RefriedBeans() 
        {
            Size = Size.Medium;
            _defaultPrice = 3.75m;
        }
    }
}
