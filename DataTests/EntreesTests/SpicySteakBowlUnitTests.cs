using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    public class SpicySteakBowlUnitTests
    {
        /// <summary>
        /// Unit test to ensure the default value of steak is true
        /// </summary>
        [Fact]
        public void SpicySteakBowlDefaultSteakValueIsCorrectTest() 
        {
            SpicySteakBowl s = new SpicySteakBowl();

            Assert.True(s.Steak);
        }

        /// <summary>
        /// Unit test to ensure the default value of veggies is false
        /// </summary>
        [Fact]
        public void SpicySteakBowlDefaultVeggiesValueIsCorrectTest()
        {
            SpicySteakBowl s = new SpicySteakBowl();

            Assert.False(s.Veggies);
        }

        /// <summary>
        /// Unit test to ensure the default value of queso is true
        /// </summary>
        [Fact]
        public void SpicySteakBowlDefaultQuesoValueIsCorrectTest()
        {
            SpicySteakBowl s = new SpicySteakBowl();

            Assert.True(s.Queso);
        }

        /// <summary>
        /// Unit test to ensure the default value of salsa is hot
        /// </summary>
        [Fact]
        public void SpicySteakBowlDefaultSalsaValueIsCorrectTest()
        {
            SpicySteakBowl s = new SpicySteakBowl();

            Assert.Equal(Salsa.Hot, s.SalsaType);
        }

        /// <summary>
        /// Unit test to ensure the default value of guac is false
        /// </summary>
        [Fact]
        public void SpicySteakBowlDefaultGuacValueIsCorrectTest()
        {
            SpicySteakBowl s = new SpicySteakBowl();

            Assert.False(s.Guacamole);
        }

        /// <summary>
        /// Unit test to ensure the default value of sour cream is true
        /// </summary>
        [Fact]
        public void SpicySteakBowlDefaultSourCreamValueIsCorrectTest()
        {
            SpicySteakBowl s = new SpicySteakBowl();

            Assert.True(s.SourCream);
        }

        /// <summary>
        /// Unit test to ensure the price of the spicy steak bowl is calculated correctly
        /// </summary>
        /// <param name="steak">whether or not the bowl contains steak</param>
        /// <param name="veggies">whether or not the bowl contains veggies</param>
        /// <param name="queso">whether or not the bowl contains queso</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">whether or not the bowl contains quacamole</param>
        /// <param name="sourCream">whether or not the bowl contains sour cream</param>
        /// <param name="expectedPrice">expected price of the bowl</param>
        [Theory]
        [InlineData(true, false, true, Salsa.Hot, false, true, 10.99)]
        [InlineData(false, true, false, Salsa.None, true, false, 11.99)]
        public void SpicySteakBowlPriceIsCorrectTest(bool steak, bool veggies, bool queso, Salsa salsa, bool guac, bool sourCream, decimal expectedPrice) 
        {
            SpicySteakBowl s = new SpicySteakBowl();
            s.Steak = steak;
            s.Veggies = veggies;
            s.Queso = queso;
            s.SalsaType = salsa;
            s.Guacamole = guac;
            s.SourCream = sourCream;

            Assert.Equal(expectedPrice, s.Price);
        }

        /// <summary>
        /// Unit test to ensure the calories of the spicy steak bowl are calculated correctly
        /// </summary>
        /// <param name="steak">whether or not the bowl contains steak</param>
        /// <param name="veggies">whether or not the bowl contains veggies</param>
        /// <param name="queso">whether or not the bowl contains queso</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">whether or not the bowl contains quacamole</param>
        /// <param name="sourCream">whether or not the bowl contains sour cream</param>
        /// <param name="expectedCals">expected calories of the bowl</param>
        [Theory]
        [InlineData(true, false, true, Salsa.Hot, false, true, 620)]
        [InlineData(false, true, false, Salsa.None, true, false, 380)]
        [InlineData(true, false, true, Salsa.Mild, false, true, 620)]
        [InlineData(true, false, true, Salsa.Hot, false, false, 520)]
        [InlineData(true, true, true, Salsa.Hot, true, true, 790)]
        [InlineData(true, true, true, Salsa.Green, true, true, 790)]
        [InlineData(false, false, false, Salsa.Hot, false, false, 230)]
        [InlineData(false, false, false, Salsa.None, false, false, 210)]
        public void SpicySteakBowlCaloriesAreCorrectTest(bool steak, bool veggies, bool queso, Salsa salsa, bool guac, bool sourCream, uint expectedCals)
        {
            SpicySteakBowl s = new SpicySteakBowl();
            s.Steak = steak;
            s.Veggies = veggies;
            s.Queso = queso;
            s.SalsaType = salsa;
            s.Guacamole = guac;
            s.SourCream = sourCream;

            Assert.Equal(expectedCals, s.Calories);
        }

        /// <summary>
        /// Unit test to ensure the prep information is correct
        /// </summary>
        [Fact]
        public void SpicySteakBowlPrepInfoIsCorrectTest() 
        {
            SpicySteakBowl s = new SpicySteakBowl();
            s.SalsaType = Salsa.None;
            s.Queso = false;
            s.Guacamole = true;

            Assert.Equal(new[] { "Hold Queso", "Hold Salsa", "Add Guacamole"}, s.PreparationInformation);
        }
    }
}
