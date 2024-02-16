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
            Assert.Equal(Size.Medium, af.Size);
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
        /// <param name="ice">Whether or not the drink has ice</param>
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
            af.Size = size;
            af.DrinkFlavor = flavor;
            af.Ice = ice;

            Assert.Equal(expectedPrice, af.Price);
        }

        /// <summary>
        /// Unit teset to ensure calories are calculated correctly
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
            af.Size = size;
            af.Ice = ice;

            Assert.Equal((uint)expectedCals, af.Calories);
        }

        /// <summary>
        /// Unit test to make sure the drink has the correct prep information
        /// </summary>
        /// <param name="flavor">Flavor of the drink</param>
        /// <param name="size">Size of the drink</param>
        /// <param name="ice">Whether or not the drink contains ice</param>
        [Theory]
        [InlineData(Size.Kids, Flavor.Strawberry, false)]

        //Specific required test case
        [InlineData(Size.Large, Flavor.Tamarind, false)]

        [InlineData(Size.Medium, Flavor.Cucumber, true)]
        [InlineData(Size.Small, Flavor.Limonada, true)]
        [InlineData(Size.Kids, Flavor.Lime, true)]
        [InlineData(Size.Large, Flavor.Limonada, true)]
        [InlineData(Size.Medium, Flavor.Tamarind, false)]
        [InlineData(Size.Small, Flavor.Strawberry, false)]
        public void PrepInfoIsCorrectTest(Size size, Flavor flavor, bool ice)
        {
            AguaFresca af = new AguaFresca();
            af.DrinkFlavor = flavor;
            af.Size = size;
            af.Ice = ice;

            Assert.Contains(af.Size.ToString(), af.PreparationInformation);
            Assert.Contains(af.DrinkFlavor.ToString(), af.PreparationInformation);
            if (!af.Ice) Assert.Contains("Hold Ice", af.PreparationInformation);
        }
        
    }
}
