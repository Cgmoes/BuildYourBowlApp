using System;
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
            Assert.Equal(Size.Medium, f.FrySize);
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
        [InlineData(Size.Kids, false, 2.50)]
        [InlineData(Size.Small, false, 3.00)]
        [InlineData(Size.Medium, false, 3.50)]
        [InlineData(Size.Large, false, 4.25)]
        [InlineData(Size.Kids, true, 2.50)]
        [InlineData(Size.Small, true, 3.00)]
        [InlineData(Size.Medium, true, 3.50)]
        [InlineData(Size.Large, true, 4.25)]
        public void FryPriceTest(Size size, bool curly, decimal expectedPrice) 
        {
            Fries f = new Fries();
            f.FrySize = size;
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
            f.FrySize = size;
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
            f.FrySize = size;
            f.Curly = curly;

            if(f.Curly) Assert.Contains("Curly", f.PreparationInformation);
            Assert.Contains($"{f.FrySize}", f.PreparationInformation);
        }
    }
}
