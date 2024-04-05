﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Class for fries unit tests
    /// </summary>
    public class FriesUnitTests
    {
        /// <summary>
        /// Tests for all the default values in the class
        /// </summary>
        [Fact]
        public void DefaultValueTest() 
        {
            Fries f = new Fries();

            Assert.False(f.Curly);
            Assert.Equal(Size.Medium, f.Size);
            Assert.Equal(3.50m, f.Price);
            Assert.Equal((uint)350, f.Calories);
        }

        /// <summary>
        /// Unit test to ensure the price is being set correctly
        /// </summary>
        /// <param name="size">size of the fries</param>
        /// <param name="curly">whether or not the fry is curly</param>
        /// <param name="expectedPrice">expected price of the fries</param>
        [Theory]
        [InlineData(Size.Kids, false, 2.25)]
        [InlineData(Size.Small, false, 2.75)]
        [InlineData(Size.Medium, false, 3.50)]
        [InlineData(Size.Large, false, 4.50)]
        [InlineData(Size.Kids, true, 2.25)]
        [InlineData(Size.Small, true, 2.75)]
        [InlineData(Size.Medium, true, 3.50)]
        [InlineData(Size.Large, true, 4.50)]
        public void FryPriceTest(Size size, bool curly, decimal expectedPrice) 
        {
            Fries f = new Fries();
            f.Size = size;
            f.Curly = curly;

            Assert.Equal(expectedPrice, f.Price);
        }

        /// <summary>
        /// Unit test to ensure the calories property is being set correctly
        /// </summary>
        /// <param name="size">size of the fries</param>
        /// <param name="curly">whether or not the fry is curly</param>
        /// <param name="expectedCalories">expected calories of the fries</param>
        [Theory]
        [InlineData(Size.Kids, false, 350 * .6)]
        [InlineData(Size.Small, false, 350 * .75)]
        [InlineData(Size.Medium, false, 350)]
        [InlineData(Size.Large, false, 350 * 1.5)]
        [InlineData(Size.Kids, true, 350 * .6)]
        [InlineData(Size.Small, true, 350 * .75)]
        [InlineData(Size.Medium, true, 350)]
        [InlineData(Size.Large, true, 350 * 1.5)]
        public void FryCaloriesTest(Size size, bool curly, uint expectedCalories) 
        {
            Fries f = new Fries();
            f.Size = size;
            f.Curly = curly;

            Assert.Equal(expectedCalories, f.Calories);
        }

        /// <summary>
        /// Unit test to ensure prep information is printed correctly
        /// </summary>
        /// <param name="size">size of the fries</param>
        /// <param name="curly">whether or not the fry is curly</param>
        [Theory]
        [InlineData(Size.Kids, false)]
        [InlineData(Size.Small, false)]
        [InlineData(Size.Medium, false)]
        [InlineData(Size.Large, false)]
        [InlineData(Size.Kids, true)]
        [InlineData(Size.Small, true)]
        [InlineData(Size.Medium, true)]
        [InlineData(Size.Large, true)]
        public void PrepInforIsCorrectTest(Size size, bool curly)
        {
            Fries f = new Fries();
            f.Size = size;
            f.Curly = curly;

            if(f.Curly) Assert.Contains("Curly", f.PreparationInformation);
            Assert.Contains($"{f.Size}", f.PreparationInformation);
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            Fries f = new Fries();
            Assert.IsAssignableFrom<IMenuItem>(f);
            Assert.IsAssignableFrom<Side>(f);
        }

        /// <summary>
        /// Unit test to ensure to string is correct
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Fries f = new Fries();
            Assert.Equal(f.Name, f.ToString());
        }

        /// <summary>
        /// Unit test to ensure changing the size notifies the property changed
        /// </summary>
        /// <param name="size">size of the side</param>
        /// <param name="propertyName">the property that should be affected</param>
        [Theory]
        [InlineData(Size.Kids, "Size")]
        [InlineData(Size.Small, "Size")]
        [InlineData(Size.Medium, "Size")]
        [InlineData(Size.Large, "Size")]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Kids, "Calories")]
        [InlineData(Size.Small, "Calories")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Kids, "PreparationInformation")]
        [InlineData(Size.Small, "PreparationInformation")]
        [InlineData(Size.Medium, "PreparationInformation")]
        [InlineData(Size.Large, "PreparationInformation")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(Size size, string propertyName)
        {
            Fries f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Size = size;
            });
        }

        /// <summary>
        /// Unit test to ensure changing the curly property affects others
        /// </summary>
        /// <param name="isCurly">whether or not the fry is curly</param>
        /// <param name="propertyName">The property that should be affected</param>
        [Theory]
        [InlineData(true, "Curly")]
        [InlineData(false, "Curly")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingCurlyShouldNotifyOfPropertyChanges(bool isCurly, string propertyName) 
        {
            Fries f = new Fries();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Curly = isCurly;
            });
        }
    }
}
