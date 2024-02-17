using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class
    /// </summary>
    public class StreetCornUnitTests
    {
        /// <summary>
        /// Unit tests to ensure the default values are correct
        /// </summary>
        [Fact]
        public void DefaultValuesAreCorrectTest() 
        {
            StreetCorn s = new StreetCorn();

            Assert.True(s.CotijaCheese);
            Assert.True(s.Cilantro);
            Assert.Equal(Size.Medium, s.Size);
            Assert.Equal(4.50m, s.Price);
            Assert.Equal((uint)300, s.Calories);
        }

        /// <summary>
        /// Unit test to ensure the price is being set correctly
        /// </summary>
        /// <param name="size">size of the corn</param>
        /// <param name="expectedPrice">expected price of the fries</param>
        [Theory]
        [InlineData(true, true, Size.Kids, 3.25)]

        //Specific required test case
        [InlineData(true, false, Size.Small, 3.75)]

        [InlineData(false, true, Size.Medium, 4.50)]
        [InlineData(false, false, Size.Large, 5.50)]
        [InlineData(false, false, Size.Kids, 3.25)]
        [InlineData(false, true, Size.Small, 3.75)]
        [InlineData(true, false, Size.Medium, 4.50)]
        [InlineData(true, true, Size.Large, 5.50)]
        public void CornPriceTest(bool cheese, bool cilantro, Size size, decimal expectedPrice)
        {
            StreetCorn s = new StreetCorn();
            s.Size = size;
            s.CotijaCheese = cheese;
            s.Cilantro = cilantro;

            Assert.Equal(expectedPrice, s.Price);
        }

        /// <summary>
        /// Unit test to ensure the calories are being set correctly
        /// </summary>
        /// <param name="cheese">whether or not the corn has american cheese</param>
        /// <param name="cilantro">whether or not the corn has cilantro</param>
        /// <param name="size">size of the side</param>
        /// <param name="expectedCals">expected calories of the side</param>
        [Theory]
        [InlineData(true, true, Size.Kids, (300) * .6)]

        //Specific required test case
        [InlineData(true, false, Size.Small, (300-5)*.75)]

        [InlineData(false, true, Size.Medium, (300-80))]
        [InlineData(false, false, Size.Large, (300-80-5)*1.5)]
        [InlineData(false, false, Size.Kids, (300-80-5) * .6)]
        [InlineData(false, true, Size.Small, (300-80)*.75)]
        [InlineData(true, false, Size.Medium, (300 - 5))]
        [InlineData(true, true, Size.Large, (300) * 1.5)]
        public void CornCaloriesTest(bool cheese, bool cilantro, Size size, double expectedCals) 
        {
            StreetCorn s = new StreetCorn();
            s.CotijaCheese = cheese;
            s.Cilantro = cilantro;
            s.Size = size;

            Assert.Equal((uint)expectedCals, s.Calories);
        }

        /// <summary>
        /// Unit test to ensure the calories are being set correctly
        /// </summary>
        /// <param name="cheese">whether or not the corn has american cheese</param>
        /// <param name="cilantro">whether or not the corn has cilantro</param>
        /// <param name="size">size of the side</param>
        /// <param name="expectedCals">expected calories of the side</param>
        [Theory]
        [InlineData(true, true, Size.Kids)]

        //Specific required test case
        [InlineData(true, false, Size.Small)]

        [InlineData(false, true, Size.Medium)]
        [InlineData(false, false, Size.Large)]
        [InlineData(false, false, Size.Kids)]
        [InlineData(false, true, Size.Small)]
        [InlineData(true, false, Size.Medium)]
        [InlineData(true, true, Size.Large)]
        public void CornPrepInfoTest(bool cheese, bool cilantro, Size size)
        {
            StreetCorn s = new StreetCorn();
            s.CotijaCheese = cheese;
            s.Cilantro = cilantro;
            s.Size = size;

            if(!s.CotijaCheese)Assert.Contains("Hold Cotija Cheese", s.PreparationInformation);
            if (!s.Cilantro) Assert.Contains("Hold Cilantro", s.PreparationInformation);
            Assert.Contains($"{s.Size}", s.PreparationInformation);
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            StreetCorn s = new StreetCorn();
            Assert.IsAssignableFrom<IMenuItem>(s);
            Assert.IsAssignableFrom<Side>(s);
        }
    }
}
