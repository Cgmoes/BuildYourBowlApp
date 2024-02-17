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
        public void GreenChickenBowlDefaultChickenValueIsCorrectTest() 
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.PossibleToppings[Ingredient.Chicken].Included);
        }

        /// <summary>
        /// Unit test to ensure that black beans default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultBlackBeansIsCorrectTest() 
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.PossibleToppings[Ingredient.BlackBeans].Included);
        }

        /// <summary>
        /// Unit test to ensure that veggies default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultVeggiesIsCorrectTest()
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.PossibleToppings[Ingredient.Veggies].Included);
        }

        /// <summary>
        /// Unit test to ensure that queso default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultQuesoIsCorrectTest()
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.PossibleToppings[Ingredient.Queso].Included);
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

            Assert.True(gcb.PossibleToppings[Ingredient.Guacamole].Included);
        }

        /// <summary>
        /// Unit test to ensure that sour cream default value is set to true
        /// </summary>
        [Fact]
        public void GreenChickenBowlDefaultSourCreamIsCorrectTest()
        {
            GreenChickenBowl gcb = new GreenChickenBowl();

            Assert.True(gcb.PossibleToppings[Ingredient.SourCream].Included);
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
            if (gcb.PossibleToppings != null)
            {
                gcb.PossibleToppings[Ingredient.Chicken].Included = chicken;
                gcb.PossibleToppings[Ingredient.BlackBeans].Included = beans;
                gcb.PossibleToppings[Ingredient.Veggies].Included = veggies;
                gcb.PossibleToppings[Ingredient.Queso].Included = queso;
                gcb.SalsaType = salsa;
                gcb.PossibleToppings[Ingredient.Guacamole].Included = guac;
                gcb.PossibleToppings[Ingredient.SourCream].Included = sourCream;
            }

            Assert.Equal(expectedCals, gcb.Calories);
        }

        /// <summary>
        /// Unit tests to ensure the prep info is correct
        /// </summary>
        [Theory]
        [InlineData(true, true, true, true, Salsa.Green, true, true, new string[] { })]
        [InlineData(false, false, false, false, Salsa.None, false, false, new string[] { "Hold Chicken", "Hold Black Beans", "Hold Veggies", "Hold Queso", "Hold Salsa", "Hold Guacamole", "Hold Sour Cream" })]
        [InlineData(true, false, true, false, Salsa.Mild, true, false, new string[] { "Hold Black Beans", "Hold Queso", "Swap Mild Salsa", "Hold Sour Cream" })]
        [InlineData(false, true, false, true, Salsa.None, false, true, new string[] { "Hold Chicken", "Hold Veggies", "Hold Salsa", "Hold Guacamole" })]
        [InlineData(true, true, false, false, Salsa.Hot, true, false, new string[] { "Hold Veggies", "Hold Queso", "Swap Hot Salsa", "Hold Sour Cream" })]
        [InlineData(false, false, true, true, Salsa.Green, false, true, new string[] { "Hold Chicken", "Hold Black Beans", "Hold Guacamole" })]
        [InlineData(false, true, true, false, Salsa.Medium, true, true, new string[] { "Hold Chicken", "Hold Queso", "Swap Medium Salsa" })]
        [InlineData(true, false, false, true, Salsa.Green, false, false, new string[] { "Hold Black Beans", "Hold Veggies", "Hold Guacamole", "Hold Sour Cream" })]
        public void GreenChickenBowlPrepInfoIsCorrectTest(bool chicken, bool beans, bool veggies, bool queso, Salsa salsa, bool guac, bool sourCream, string[] prepInfo) 
        {
            GreenChickenBowl gcb = new GreenChickenBowl();
            if (gcb.PossibleToppings != null)
            {
                gcb.PossibleToppings[Ingredient.Chicken].Included = chicken;
                gcb.PossibleToppings[Ingredient.BlackBeans].Included = beans;
                gcb.PossibleToppings[Ingredient.Veggies].Included = veggies;
                gcb.PossibleToppings[Ingredient.Queso].Included = queso;
                gcb.SalsaType = salsa;
                gcb.PossibleToppings[Ingredient.Guacamole].Included = guac;
                gcb.PossibleToppings[Ingredient.SourCream].Included = sourCream;
            }

            Assert.All(prepInfo, list => Assert.Contains(list, gcb.PreparationInformation));
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            GreenChickenBowl gcb = new GreenChickenBowl();
            Assert.IsAssignableFrom<IMenuItem>(gcb);
            Assert.IsAssignableFrom<Bowl>(gcb);
        }
    }
}
