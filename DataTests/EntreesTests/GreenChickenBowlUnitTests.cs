using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class for green chicken bowl
    /// </summary>
    public class GreenChickenBowlUnitTests
    {
        /// <summary>
        /// Unit test to ensure that chicken default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultChickenValueIsCorrect() 
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.Chicken);
        }

        /// <summary>
        /// Unit test to ensure that black beans default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultBlackBeansIsCorrectTest() 
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.BlackBeans);
        }

        /// <summary>
        /// Unit test to ensure that veggies default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultVeggiesIsCorrectTest()
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.Veggies);
        }

        /// <summary>
        /// Unit test to ensure that queso default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultQuesoIsCorrectTest()
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.Queso);
        }

        /// <summary>
        /// Unit test to ensure that salsa default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultSalsaIsCorrectTest()
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.Equal(Salsa.Green, gcb.SalsaType);
        }

        /// <summary>
        /// Unit test to ensure that guac default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultGuacIsCorrectTest()
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.Guacamole);
        }

        /// <summary>
        /// Unit test to ensure that sour cream default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultSourCreamIsCorrectTest()
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.SourCream);
        }

        /// <summary>
        /// Unit test to ensure the price of the bowl is correct
        /// </summary>
        [Fact]
        public void GreenChickenBowlPriceIsCorrectTest() 
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.Equal(9.99m, gcb.Price);
        }

        /// <summary>
        /// Unit test to ensure the calories of a given bowl are correct
        /// </summary>
        /// <param name="chicken">whether or not the bowl contains chicken</param>
        /// <param name="beans">whether or not the bowl contains black beans</param>
        /// <param name="veggies">whether or not the bowl contains veggies</param>
        /// <param name="queso">whether or not the bowl contains queso</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">whether or not the bowl contains guacamole</param>
        /// <param name="sourCream">whether or not the bowl contains sour cream</param>
        /// <param name="expectedCals">the expected amount of calories in the bowl</param>
        [Theory]
        [InlineData(true, true, true, true, Salsa.Green, true, true, 890)]
        [InlineData(false, false, false, false, Salsa.None, false ,false, 210)]
        [InlineData(true, false, true, false, Salsa.Mild, true, false, 550)]
        [InlineData(false, true, false, true, Salsa.None, false, true, 550)]
        [InlineData(true, true, false, false, Salsa.Hot, true, false, 660)]
        [InlineData(false, false, true, true, Salsa.Green, false, true, 460)]
        [InlineData(false, true, true, false, Salsa.None, true, true, 610)]
        [InlineData(true, false, false, true, Salsa.Green, false, false, 490)]
        public void GreenChickenBowlCaloriesAreCorrectTest(bool chicken, bool beans, bool veggies, bool queso, Salsa salsa, bool guac, bool sourCream, uint expectedCals) 
        {
            GreenChickenBowl gcb = new GreenChickenBowl();
            gcb.Chicken = chicken;
            gcb.BlackBeans = beans;
            gcb.Veggies = veggies;
            gcb.Queso = queso;
            gcb.SalsaType = salsa;
            gcb.Guacamole = guac;
            gcb.SourCream = sourCream;

            Assert.Equal(expectedCals, gcb.Calories);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void GreenChickenBowlPrepInfoIsCorrectTest() 
        {
            GreenChickenBowl gcb = new GreenChickenBowl();
            gcb.Chicken = false;
            gcb.SalsaType = Salsa.Hot;
            gcb.Guacamole = false;

            Assert.Equal(new[] { "Hold Chicken", "Swap Hot Salsa", "Hold Guacamole"}, gcb.PreparationInformation);
        }
    }
}
