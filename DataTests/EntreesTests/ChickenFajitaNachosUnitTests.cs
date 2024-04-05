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
    /// Unit test class for chicken fajita nachos
    /// </summary>
    public class ChickenFajitaNachosUnitTests
    {
        /// <summary>
        /// Unit test to make sure the default value of chicken is true
        /// </summary>
        [Fact]
        public void ChickenFajitaNachosDefaultCarnitasIsCorrectTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.True(c.PossibleToppings[Ingredient.Chicken].Included);
        }

        /// <summary>
        /// Unit test to make sure the default value of veggies is true
        /// </summary>
        [Fact]
        public void ChickenFajitaNachosDefaultVeggiesIsCorrectTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.True(c.PossibleToppings[Ingredient.Veggies].Included);
        }

        /// <summary>
        /// Unit test to make sure the default value of chicken is true
        /// </summary>
        [Fact]
        public void ChickenFajitaNachosDefaultQuesoIsCorrectTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.True(c.PossibleToppings[Ingredient.Queso].Included);
        }

        /// <summary>
        /// Unit test to make sure the default value of salsa is correct
        /// </summary>
        [Fact]
        public void ChickenFajitaNachosDefaultSalsaIsCorrectTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.Equal(Salsa.Medium, c.SalsaType);
        }

        /// <summary>
        /// Unit test to make sure the default value of guac is false
        /// </summary>
        [Fact]
        public void ChickenFajitaNachosDefaultGuacIsCorrectTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.False(c.PossibleToppings[Ingredient.Guacamole].Included);
        }

        /// <summary>
        /// Unit test to make sure the default value of sour cream is true
        /// </summary>
        [Fact]
        public void ChickenFajitaNachosDefaultSourCreamIsCorrectTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.True(c.PossibleToppings[Ingredient.SourCream].Included);
        }

        /// <summary>
        /// Unit test to ensure the calories are calculated correctly
        /// </summary>
        /// <param name="chicken">Whether the bowl contains chicken</param>
        /// <param name="veggies">Whether the bowl contains veggies</param>
        /// <param name="queso">Whether the bowl contains queso</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">Whether the bowl contains guacamole</param>
        /// <param name="sourCream">Whether the bowl contains sour cream</param>
        /// <param name="expectedPrice">The expected amount of calories in the bowl</param>
        [Theory]

        //Specific required test case
        [InlineData(false, false, true, Salsa.Hot, false, false, 380)]

        [InlineData(true, true, true, Salsa.Medium, false, true, 650)]
        [InlineData(true, true, true, Salsa.None, false, true, 630)]
        [InlineData(false, false, true, Salsa.Medium, false, true, 480)]
        [InlineData(true, true, true, Salsa.Medium, true, false, 700)]
        [InlineData(false, true, false, Salsa.Mild, false, true, 390)]
        [InlineData(true, true, true, Salsa.Medium, true, true, 800)]
        [InlineData(false, false, false, Salsa.None, false, false, 250)]
        public void ChickenFajitaCaloriesAreCorrectTest(bool chicken, bool veggies, bool queso, Salsa salsa, bool guac, bool sourCream, uint expectedPrice) 
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            if (c.PossibleToppings != null)
            {
                c.PossibleToppings[Ingredient.Chicken].Included = chicken;
                c.PossibleToppings[Ingredient.Veggies].Included = veggies;
                c.PossibleToppings[Ingredient.Queso].Included = queso;
                c.SalsaType = salsa;
                c.PossibleToppings[Ingredient.Guacamole].Included = guac;
                c.PossibleToppings[Ingredient.SourCream].Included = sourCream;
            }
            Assert.Equal(expectedPrice, c.Calories);
        }

        /// <summary>
        /// Unit test to ensure the price is calculated correctly
        /// </summary>
        /// <param name="chicken">Whether the bowl contains chicken</param>
        /// <param name="veggies">Whether the bowl contains veggies</param>
        /// <param name="queso">Whether the bowl contains queso</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">Whether the bowl contains guacamole</param>
        /// <param name="sourCream">Whether the bowl contains sour cream</param>
        /// <param name="expectedPrice">The expected price in the bowl</param>
        [Theory]

        //Specific required test case
        [InlineData(false, false, true, Salsa.Hot, false, false, 10.99)]

        [InlineData(true, true, true, Salsa.Medium, false, true, 10.99)]
        [InlineData(true, true, true, Salsa.None, false, true, 10.99)]
        [InlineData(false, false, true, Salsa.Medium, false, true, 10.99)]
        [InlineData(true, true, true, Salsa.Medium, true, false, 11.99)]
        [InlineData(false, true, false, Salsa.Mild, false, true, 10.99)]
        [InlineData(true, true, true, Salsa.Medium, true, true, 11.99)]
        [InlineData(false, false, false, Salsa.None, false, false, 10.99)]
        public void ChickenFajitaPriceIsCorrectTest(bool chicken, bool veggies, bool queso, Salsa salsa, bool guac, bool sourCream, decimal expectedPrice)
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            if (c.PossibleToppings != null)
            {
                c.PossibleToppings[Ingredient.Chicken].Included = chicken;
                c.PossibleToppings[Ingredient.Veggies].Included = veggies;
                c.PossibleToppings[Ingredient.Queso].Included = queso;
                c.SalsaType = salsa;
                c.PossibleToppings[Ingredient.Guacamole].Included = guac;
                c.PossibleToppings[Ingredient.SourCream].Included = sourCream;
            }

            Assert.Equal(expectedPrice, c.Price);
        }

        /// <summary>
        /// Unit test to ensure the prep information is correct
        /// </summary>
        /// <param name="chicken">Whether the bowl contains chicken</param>
        /// <param name="veggies">Whether the bowl contains veggies</param>
        /// <param name="queso">Whether the bowl contains queso</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">Whether the bowl contains guacamole</param>
        /// <param name="sourCream">Whether the bowl contains sour cream</param>
        [Theory]
        //Specific required test case
        [InlineData(false, false, true, Salsa.Hot, false, false, new string[] { "Hold Chicken", "Hold Veggies", "Swap Hot Salsa", "Hold Sour Cream" })]

        [InlineData(true, true, true, Salsa.Medium, false, true, new string[] { })]
        [InlineData(true, true, true, Salsa.None, false, true, new string[] { "Hold Salsa" })]
        [InlineData(false, false, true, Salsa.Medium, false, true, new string[] { "Hold Chicken", "Hold Veggies" })]
        [InlineData(true, true, true, Salsa.Medium, true, false, new string[] { "Add Guacamole", "Hold Sour Cream" })]
        [InlineData(false, true, false, Salsa.Mild, false, true, new string[] { "Hold Chicken", "Hold Queso", "Swap Mild Salsa" })]
        [InlineData(true, true, true, Salsa.Medium, true, true, new string[] { "Add Guacamole" })]
        [InlineData(false, false, false, Salsa.None, false, false, new string[] { "Hold Chicken", "Hold Veggies", "Hold Queso", "Hold Salsa", "Hold Sour Cream" })]
        public void ChickenFajitaPrepInformationIsCorrectTest(bool chicken, bool veggies, bool queso, Salsa salsa, bool guac, bool sourCream, string[] prepInfo) 
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            if (c.PossibleToppings != null)
            {
                c.PossibleToppings[Ingredient.Chicken].Included = chicken;
                c.PossibleToppings[Ingredient.Veggies].Included = veggies;
                c.PossibleToppings[Ingredient.Queso].Included = queso;
                c.SalsaType = salsa;
                c.PossibleToppings[Ingredient.Guacamole].Included = guac;
                c.PossibleToppings[Ingredient.SourCream].Included = sourCream;
            }

            Assert.All(prepInfo, list => Assert.Contains(list, c.PreparationInformation));
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<Nacho>(c);
        }

        /// <summary>
        /// Unit test to ensure to string is correct
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.Equal(c.Name, c.ToString());
        }

        /// <summary>
        /// Unit test to ensure changing the salsa type changes the properties
        /// </summary>
        /// <param name="salsaType">the type of salsa</param>
        /// <param name="propertyName">the name of the property that should be changed</param>
        [Theory]
        [InlineData(Salsa.Medium, "SalsaType")]
        [InlineData(Salsa.None, "Calories")]
        [InlineData(Salsa.Green, "PreparationInformation")]
        [InlineData(Salsa.Hot, "SalsaType")]
        [InlineData(Salsa.Mild, "Calories")]
        [InlineData(Salsa.Mild, "PreparationInformation")]
        [InlineData(Salsa.None, "SalsaType")]
        [InlineData(Salsa.Green, "Calories")]
        public void SalsaTypeNotifiesOfPropertyChangedTest(Salsa salsaType, string propertyName)
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.PropertyChanged(c, propertyName, () => {
                c.SalsaType = salsaType;
            });
        }

        /// <summary>
        /// Tests if ingredients update properties
        /// </summary>
        /// <param name="ingredient">ingredient to test</param>
        /// <param name="included">whether or not the ingredient is included</param>
        /// <param name="propertyName">the name of the property that should be updated</param>
        [Theory]
        [InlineData(Ingredient.Chicken, false, "PreparationInformation")]
        [InlineData(Ingredient.Queso, true, "Calories")]
        [InlineData(Ingredient.SourCream, true, "Calories")]
        [InlineData(Ingredient.Guacamole, false, "PreparationInformation")]
        [InlineData(Ingredient.SourCream, true, "Price")]
        [InlineData(Ingredient.Veggies, true, "Price")]
        [InlineData(Ingredient.Chicken, true, "Calories")]
        [InlineData(Ingredient.Queso, true, "PreparationInformation")]
        public void ToppingsNotifiesOfPropertyChangedTest(Ingredient ingredient, bool included, string propertyName)
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.PropertyChanged(c, propertyName, () => {
                c.PossibleToppings[ingredient].Included = included;
            });
        }
    }
}
