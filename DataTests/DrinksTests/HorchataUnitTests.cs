using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class for horchata
    /// </summary>
    public class HorchataUnitTests
    {
        /// <summary>
        /// Unit test to make sure Horchata defaults to having ice
        /// </summary>
        [Fact]
        public void AguaFrescaHasIceDefaultTest()
        {
            Horchata h = new Horchata();
            Assert.True(h.Ice);
        }

        /// <summary>
        /// Unit test to make sure the default size is medium
        /// </summary>
        [Fact]
        public void DrinkSizeDefaultValueTest()
        {
            Horchata h = new Horchata();
            Assert.Equal(Size.Medium, h.HorchataSize);
        }

        /// <summary>
        /// Unit test to ensure the price is correct for given sizes
        /// </summary>
        /// <param name="size">Size of the drink</param>
        /// <param name="expectedPrice">Expected price of the drink</param>
        [Theory]
        [InlineData(Size.Kids, 3.50 - 1)]
        [InlineData(Size.Small, 3.50 - .5)]
        [InlineData(Size.Medium, 3.50)]
        [InlineData(Size.Large, 3.50 + .75)]
        public void DrinkSizePriceIsCorrectTest(Size size, decimal expectedPrice)
        {
            Horchata h = new Horchata();
            h.HorchataSize = size;

            Assert.Equal(expectedPrice, h.Price);
        }

        /// <summary>
        /// Unit test to ensure te calories is correct for any given drink
        /// </summary>
        /// <param name="size">Size of the drink</param>
        /// <param name="ice">Whether or not the drink has ice</param>
        /// <param name="expectedCals">Expected amount of calories for the drink</param>
        [Theory]
        [InlineData(Size.Kids, true, 280 * .6)]
        [InlineData(Size.Small, true, 280 * .75)]
        [InlineData(Size.Medium, true, 280)]
        [InlineData(Size.Large, true, 280 * 1.50)]
        [InlineData(Size.Kids, false, (280 - 30) * .6)]
        [InlineData(Size.Small, false, (280 - 30) * .75)]
        [InlineData(Size.Medium, false, (280 - 30))]
        [InlineData(Size.Large, false, (280 - 30) * 1.50)]
        public void CaloriesIsCorrectTest(Size size, bool ice, double expectedCals) 
        {
            Horchata h = new Horchata();
            h.HorchataSize = size;
            h.Ice = ice;

            Assert.Equal((uint)expectedCals, h.Calories);
        }

        /// <summary>
        /// Unit test to see if the prep information is working corrently
        /// </summary>
        [Fact]
        public void PrepInformationIsCorrectTest() 
        {
            Horchata h = new Horchata();
            h.HorchataSize = Size.Medium;
            h.Ice = false;

            Assert.Equal(new[] { "Hold Ice", "Medium"}, h.PreparationInformation);

            h.HorchataSize = Size.Small;
            h.Ice = true;

            Assert.Equal(new[] { "Small" }, h.PreparationInformation);
        }
    }
}
