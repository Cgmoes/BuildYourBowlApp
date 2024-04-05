﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// class definition for nacho unit tests
    /// </summary>
    public class NachoUnitTests
    {
        /// <summary>
        /// Unit test to ensure to string is correct
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Nacho n = new Nacho();
            Assert.Equal(n.Name, n.ToString());
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            Nacho n = new Nacho();
            Assert.IsAssignableFrom<IMenuItem>(n);
            Assert.IsAssignableFrom<Nacho>(n);
        }

        /// <summary>
        /// Unit test to ensure changing the salsa type changes the properties
        /// </summary>
        /// <param name="salsaType">the type of salsa</param>
        /// <param name="propertyName">the name of the property that should be changed</param>
        [Theory]
        [InlineData(Salsa.Medium, "SalsaType")]
        [InlineData(Salsa.None, "Calories")]
        [InlineData(Salsa.Green, "PreparationInformation")]
        [InlineData(Salsa.Hot, "SalsaType")]
        [InlineData(Salsa.Mild, "Calories")]
        [InlineData(Salsa.Mild, "PreparationInformation")]
        [InlineData(Salsa.None, "SalsaType")]
        [InlineData(Salsa.Green, "Calories")]
        public void SalsaTypeNotifiesOfPropertyChangedTest(Salsa salsaType, string propertyName)
        {
            Nacho n = new Nacho();
            Assert.PropertyChanged(n, propertyName, () => {
                n.SalsaType = salsaType;
            });
        }

        /// <summary>
        /// Tests if ingredients update properties
        /// </summary>
        /// <param name="ingredient">ingredient to test</param>
        /// <param name="included">whether or not the ingredient is included</param>
        /// <param name="propertyName">the name of the property that should be updated</param>
        [Theory]
        [InlineData(Ingredient.Carnitas, false, "PreparationInformation")]
        [InlineData(Ingredient.Veggies, true, "Calories")]
        [InlineData(Ingredient.Steak, true, "Price")]
        [InlineData(Ingredient.Guacamole, false, "Price")]
        [InlineData(Ingredient.PintoBeans, true, "Calories")]
        [InlineData(Ingredient.SourCream, true, "PreparationInformation")]
        [InlineData(Ingredient.Veggies, false, "PreparationInformation")]
        [InlineData(Ingredient.BlackBeans, false, "Calories")]
        public void ToppingsNotifiesOfPropertyChangedTest(Ingredient ingredient, bool included, string propertyName)
        {
            Nacho n = new Nacho();
            Assert.PropertyChanged(n, propertyName, () => {
                n.PossibleToppings[ingredient].Included = included;
            });
        }
    }
}
