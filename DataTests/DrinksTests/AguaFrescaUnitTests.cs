using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class for aqua fresca
    /// </summary>
    public class AguaFrescaUnitTests
    {
        /// <summary>
        /// Unit test to make sure the default flavor is limonada
        /// </summary>
        [Fact]
        public void DrinkFlavorDefaultValueTest() 
        {
            AguaFresca af = new AguaFresca();
            Assert.Equal(Flavor.Limonada, af.DrinkFlavor);
        }

        /// <summary>
        /// Unit test to make sure the default size is medium
        /// </summary>
        [Fact]
        public void DrinkSizeDefaultValueTest()
        {
            AguaFresca af = new AguaFresca();
            Assert.Equal(Size.Medium, af.DrinkSize);
        }

        /// <summary>
        /// Unit test to make sure Agua Fresca defaults to having ice
        /// </summary>
        [Fact]
        public void AguaFrescaHasIceDefaultTest() 
        {
            AguaFresca af = new AguaFresca();
            Assert.True(af.Ice);
        }

        /// <summary>
        /// Unit test to make sure the price is correct for every size drink
        /// </summary>
        /// <param name="flavor">Flavor of the drink</param>
        /// <param name="size">Size of the drink</param>
        /// <param name="expectedPrice">expected price of the drink</param>
        [Theory]
        [InlineData(Flavor.Limonada, Size.Kids, true, 2.00)]
        [InlineData(Flavor.Limonada, Size.Small, true, 2.50)]
        [InlineData(Flavor.Limonada, Size.Medium, false, 3.00)]
        [InlineData(Flavor.Limonada, Size.Large, false, 3.75)]
        [InlineData(Flavor.Tamarind, Size.Kids, false, 2.50)]
        [InlineData(Flavor.Tamarind, Size.Small, true, 3.00)]
        [InlineData(Flavor.Tamarind, Size.Medium, false, 3.50)]

        //Specific required test case
        [InlineData(Flavor.Tamarind, Size.Large, false, 4.25)]

        public void AguaFrescaPriceCheckTest(Flavor flavor, Size size, bool ice, decimal expectedPrice) 
        {
            AguaFresca af = new AguaFresca();
            af.DrinkSize = size;
            af.DrinkFlavor = flavor;
            af.Ice = ice;

            Assert.Equal(expectedPrice, af.Price);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flavor">Flavor of the drink</param>
        /// <param name="size">Size of the drink</param>
        /// <param name="ice">Whether or not the drink contains ice</param>
        /// <param name="expectedCals">The expected amount of calories for the drink</param>
        [Theory]

        //Specific required test case
        [InlineData(Flavor.Tamarind, Size.Large, false, 240)]

        [InlineData(Flavor.Cucumber, Size.Kids, false, (125 - 50 + 10) * .60)]
        [InlineData(Flavor.Lime, Size.Large, true, 125 * 1.50)]
        [InlineData(Flavor.Strawberry, Size.Small, true, (125 + 25) * .75)]
        [InlineData(Flavor.Limonada, Size.Large, false, (125 + 10) * 1.50)]
        [InlineData(Flavor.Cucumber, Size.Medium, false, (125 - 50 + 10))]
        [InlineData(Flavor.Lime, Size.Large, false, (125 + 10) * 1.50)]
        [InlineData(Flavor.Strawberry, Size.Kids, true, (125 + 25) * .60)]
        public void AguaFrescaCaloriesCheckTest(Flavor flavor, Size size, bool ice, double expectedCals) 
        {
            AguaFresca af = new AguaFresca();
            af.DrinkFlavor = flavor;
            af.DrinkSize = size;
            af.Ice = ice;

            Assert.Equal((uint)expectedCals, af.Calories);
        }

        /// <summary>
        /// Unit test to make sure A large tamarind agua fresca without ice has the correct prep information
        /// </summary>
        //Specific required test case
        [Fact]
        public void LargeTamarindAguaFrescaWithoutIcePrepInfoIsCorrectTest()
        {
            AguaFresca af = new AguaFresca();
            af.DrinkFlavor = Flavor.Tamarind;
            af.DrinkSize = Size.Large;
            af.Ice = false;

            Assert.Equal(new[] { "Large", "Tamarind", "Hold Ice" }, af.PreparationInformation);
        }
        
    }
}
