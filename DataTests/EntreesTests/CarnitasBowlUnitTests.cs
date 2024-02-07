using BuildYourBowl.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class for carnitas bowl
    /// </summary>
    public class CarnitasBowlUnitTests
    {
        /// <summary>
        /// Unit test to make sure the default value of carnitas is true
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultCarnitasIsCorrectTest() 
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.True(cb.Carnitas);
        }

        /// <summary>
        /// Unit test to make sure the default value of veggies is false
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultVeggiesIsCorrectTest() 
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.False(cb.Veggies);
        }

        /// <summary>
        /// Unit test to make sure the default value of Queso is True
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultQuesoIsCorrectTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.True(cb.Queso);
        }

        /// <summary>
        /// Unit test to make sure the default value of Pinto Beans is True
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultPintoBeansIsCorrectTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.True(cb.PintoBeans);
        }

        /// <summary>
        /// Unit test to make sure the default salsa type is medium
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultSalsaIsMediumTest() 
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.Equal(Salsa.Medium, cb.SalsaType);
        }

        /// <summary>
        /// Unit test to make sure the default value of guac is False
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultGuacIsCorrectTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.False(cb.Guacamole);
        }

        /// <summary>
        /// Unit test to make sure the default value of sour cream is False
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultSourCreamIsCorrectTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.False(cb.SourCream);
        }

        /// <summary>
        /// Unit test to make sure the total number of calories of the bowl is correct
        /// </summary>
        /// <param name="carnitas">Whether or not the bowl has carnitas</param>
        /// <param name="veggies">Whether or not the bowl has veggies</param>
        /// <param name="queso">Whether or not the bowl has queso</param>
        /// <param name="pintoBeans">Whether or not the bowl has pinto beans</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">Whether or not the bowl has guacamole</param>
        /// <param name="sourCream">Whether or not the bowl has sour cream</param>
        /// <param name="expectedCals">The expected amount of calories for the bowl</param>
        [Theory]

        //Specific required test case
        [InlineData(false, true, false, false, Salsa.Medium, true, true, 500)]

        [InlineData(true, false, true, true, Salsa.Medium, false, false, 680)]
        [InlineData(false, true, false, false, Salsa.None, true, true, 480)]
        [InlineData(false, true, true, false, Salsa.Medium, true, true, 610)]
        [InlineData(false, false, true, true, Salsa.Hot, true, false, 620)]
        [InlineData(true, false, false, true, Salsa.Medium, false, false, 570)]
        [InlineData(false, false, false, false, Salsa.None, false, false, 210)]
        [InlineData(true, true, true, true, Salsa.Medium, true, true, 950)]
        public void CarnitasBowlCaloriesIsCorrectTest(bool carnitas, bool veggies, bool queso, bool pintoBeans, Salsa salsa, bool guac, bool sourCream, uint expectedCals) 
        {
            CarnitasBowl cb = new CarnitasBowl();
            cb.Carnitas = carnitas;
            cb.Veggies = veggies;
            cb.Queso = queso;
            cb.PintoBeans = pintoBeans;
            cb.SalsaType = salsa;
            cb.Guacamole = guac;
            cb.SourCream = sourCream;

            Assert.Equal(expectedCals, cb.Calories);
        }

        /// <summary>
        /// Unit test to make sure the total price of the bowl is correct
        /// </summary>
        /// <param name="carnitas">Whether or not the bowl has carnitas</param>
        /// <param name="veggies">Whether or not the bowl has veggies</param>
        /// <param name="queso">Whether or not the bowl has queso</param>
        /// <param name="pintoBeans">Whether or not the bowl has pinto beans</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">Whether or not the bowl has guacamole</param>
        /// <param name="sourCream">Whether or not the bowl has sour cream</param>
        /// <param name="expectedPrice">The expected amount of calories for the bowl</param>
        [Theory]

        //Specific required test case
        [InlineData(false, true, false, false, Salsa.Medium, true, true, 10.99)]

        [InlineData(true, false, true, true, Salsa.Medium, false, false, 9.99)]
        [InlineData(false, true, false, false, Salsa.None, true, true, 10.99)]
        [InlineData(false, true, true, false, Salsa.Medium, true, true, 10.99)]
        [InlineData(false, false, true, true, Salsa.Hot, true, false, 10.99)]
        [InlineData(true, false, false, true, Salsa.Medium, false, false, 9.99)]
        [InlineData(false, false, false, false, Salsa.None, false, false, 9.99)]
        [InlineData(true, true, true, true, Salsa.Medium, true, true, 10.99)]
        public void CarnitasBowlPriceIsCorrectTest(bool carnitas, bool veggies, bool queso, bool pintoBeans, Salsa salsa, bool guac, bool sourCream, decimal expectedPrice)
        {
            CarnitasBowl cb = new CarnitasBowl();
            cb.Carnitas = carnitas;
            cb.Veggies = veggies;
            cb.Queso = queso;
            cb.PintoBeans = pintoBeans;
            cb.SalsaType = salsa;
            cb.Guacamole = guac;
            cb.SourCream = sourCream;

            Assert.Equal(expectedPrice, cb.Price);
        }

        /// <summary>
        /// Unit test to make sure A large tamarind agua fresca without ice has the correct prep information
        /// </summary>
        // Specific required test case
        [Fact]
        public void CarnitasBowlPrepInfoIsCorrectTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            cb.Carnitas = false;
            cb.Veggies = true;
            cb.Queso = false;
            cb.PintoBeans = false;
            cb.SalsaType = Salsa.Medium;
            cb.Guacamole = true;
            cb.SourCream = true;

            Assert.Equal(new[] { "Hold Carnitas", "Hold Queso", "Hold Pinto Beans", "Add Guacamole", "Add Sour Cream", "Add Veggies" }, cb.PreparationInformation);
        }
    }
}
