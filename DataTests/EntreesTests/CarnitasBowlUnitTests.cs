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
            Assert.True(cb.PossibleToppings[Ingredient.Carnitas].Included);
        }

        /// <summary>
        /// Unit test to make sure the default value of veggies is false
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultVeggiesIsCorrectTest() 
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.False(cb.PossibleToppings[Ingredient.Veggies].Included);
        }

        /// <summary>
        /// Unit test to make sure the default value of Queso is True
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultQuesoIsCorrectTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.True(cb.PossibleToppings[Ingredient.Queso].Included);
        }

        /// <summary>
        /// Unit test to make sure the default value of Pinto Beans is True
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultPintoBeansIsCorrectTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.True(cb.PossibleToppings[Ingredient.PintoBeans].Included);
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
            Assert.False(cb.PossibleToppings[Ingredient.Guacamole].Included);
        }

        /// <summary>
        /// Unit test to make sure the default value of sour cream is False
        /// </summary>
        [Fact]
        public void CarnitasBowlDefaultSourCreamIsCorrectTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.False(cb.PossibleToppings[Ingredient.SourCream].Included);
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
            if (cb.PossibleToppings != null)
            {
                cb.PossibleToppings[Ingredient.Carnitas].Included = carnitas;
                cb.PossibleToppings[Ingredient.Veggies].Included = veggies;
                cb.PossibleToppings[Ingredient.Queso].Included = queso;
                cb.PossibleToppings[Ingredient.PintoBeans].Included = pintoBeans;
                cb.SalsaType = salsa;
                cb.PossibleToppings[Ingredient.Guacamole].Included = guac;
                cb.PossibleToppings[Ingredient.SourCream].Included = sourCream;
            }

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
            if (cb.PossibleToppings != null)
            {
                cb.PossibleToppings[Ingredient.Carnitas].Included = carnitas;
                cb.PossibleToppings[Ingredient.Veggies].Included = veggies;
                cb.PossibleToppings[Ingredient.Queso].Included = queso;
                cb.PossibleToppings[Ingredient.PintoBeans].Included = pintoBeans;
                cb.SalsaType = salsa;
                cb.PossibleToppings[Ingredient.Guacamole].Included = guac;
                cb.PossibleToppings[Ingredient.SourCream].Included = sourCream;
            }

            Assert.Equal(expectedPrice, cb.Price);
        }

        /// <summary>
        /// Unit test to make sure the carnitas bowl has the correct prep information
        /// </summary>
        /// <param name="carnitas">Whether or not the bowl has carnitas</param>
        /// <param name="veggies">Whether or not the bowl has veggies</param>
        /// <param name="queso">Whether or not the bowl has queso</param>
        /// <param name="pintoBeans">Whether or not the bowl has pinto beans</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">Whether or not the bowl has guacamole</param>
        /// <param name="sourCream">Whether or not the bowl has sour cream</param>
        [Theory]

        //Specific required test case
        [InlineData(false, true, false, false, Salsa.Medium, true, true, new string[] { "Hold Carnitas", "Add Veggies", "Hold Queso", "Hold Pinto Beans"})]

        [InlineData(true, false, true, true, Salsa.Medium, false, false, new string[] {})]
        [InlineData(false, true, false, false, Salsa.None, true, true, new string[] { "Hold Carnitas", "Add Veggies", "Hold Queso", "Hold Pinto Beans", "Hold Salsa" })]
        [InlineData(false, true, true, false, Salsa.Medium, true, true, new string[] { "Hold Carnitas", "Add Veggies", "Hold Pinto Beans"})]
        [InlineData(false, false, true, true, Salsa.Hot, true, false, new string[] { "Hold Carnitas", "Swap Hot Salsa", "Add Guacamole" })]
        [InlineData(true, false, false, true, Salsa.Medium, false, false, new string[] { "Hold Queso"})]
        [InlineData(false, false, false, false, Salsa.None, false, false, new string[] { "Hold Carnitas", "Hold Queso", "Hold Pinto Beans", "Hold Salsa" })]
        [InlineData(true, true, true, true, Salsa.Medium, true, true, new string[] { "Add Veggies", "Add Guacamole", "Add Sour Cream"})]
        public void CarnitasBowlPrepInfoIsCorrectTest(bool carnitas, bool veggies, bool queso, bool beans, Salsa salsa, bool guac, bool sourCream, string[] prepInfo)
        {
            CarnitasBowl cb = new CarnitasBowl();
            if (cb.PossibleToppings != null) 
            {
                cb.PossibleToppings[Ingredient.Carnitas].Included = carnitas;
                cb.PossibleToppings[Ingredient.Veggies].Included = veggies;
                cb.PossibleToppings[Ingredient.Queso].Included = queso;
                cb.PossibleToppings[Ingredient.PintoBeans].Included = beans;
                cb.SalsaType = salsa;
                cb.PossibleToppings[Ingredient.Guacamole].Included = guac;
                cb.PossibleToppings[Ingredient.SourCream].Included = sourCream;
            }

            Assert.All(prepInfo, list => Assert.Contains(list, cb.PreparationInformation));
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.IsAssignableFrom<IMenuItem>(cb);
            Assert.IsAssignableFrom<Bowl>(cb);
        }

        /// <summary>
        /// Unit test to ensure to string is correct
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            CarnitasBowl cb = new CarnitasBowl();
            Assert.Equal(cb.Name, cb.ToString());
        }
    }
}
