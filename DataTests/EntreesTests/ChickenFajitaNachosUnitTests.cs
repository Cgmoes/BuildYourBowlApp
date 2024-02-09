﻿using BuildYourBowl.Data;
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
            Assert.True(c.Chicken);
        }

        /// <summary>
        /// Unit test to make sure the default value of veggies is true
        /// </summary>
        [Fact]
        public void ChickenFajitaNachosDefaultVeggiesIsCorrectTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.True(c.Veggies);
        }

        /// <summary>
        /// Unit test to make sure the default value of chicken is true
        /// </summary>
        [Fact]
        public void ChickenFajitaNachosDefaultQuesoIsCorrectTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.True(c.Queso);
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
            Assert.False(c.Guacamole);
        }

        /// <summary>
        /// Unit test to make sure the default value of sour cream is true
        /// </summary>
        [Fact]
        public void ChickenFajitaNachosDefaultSourCreamIsCorrectTest()
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            Assert.True(c.SourCream);
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
            c.Chicken = chicken;
            c.Veggies = veggies;
            c.Queso = queso;
            c.SalsaType = salsa;
            c.Guacamole = guac;
            c.SourCream = sourCream;

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
            c.Chicken = chicken;
            c.Veggies = veggies;
            c.Queso = queso;
            c.SalsaType = salsa;
            c.Guacamole = guac;
            c.SourCream = sourCream;

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
        [InlineData(false, false, true, Salsa.Hot, false, false)]

        [InlineData(true, true, true, Salsa.Medium, false, true)]
        [InlineData(true, true, true, Salsa.None, false, true)]
        [InlineData(false, false, true, Salsa.Medium, false, true)]
        [InlineData(true, true, true, Salsa.Medium, true, false)]
        [InlineData(false, true, false, Salsa.Mild, false, true)]
        [InlineData(true, true, true, Salsa.Medium, true, true)]
        [InlineData(false, false, false, Salsa.None, false, false)]
        public void ChickenFajitaPrepInformationIsCorrectTest(bool chicken, bool veggies, bool queso, Salsa salsa, bool guac, bool sourCream) 
        {
            ChickenFajitaNachos c = new ChickenFajitaNachos();
            c.Chicken = chicken;
            c.Veggies = veggies;
            c.Queso = queso;
            c.SalsaType = salsa;
            c.Guacamole = guac;
            c.SourCream = sourCream;

            if (!c.Chicken) Assert.Contains("Hold Chicken", c.PreparationInformation);
            if (!c.Veggies) Assert.Contains("Hold Veggies", c.PreparationInformation);
            if (!c.Queso) Assert.Contains("Hold Queso", c.PreparationInformation);
            if(c.SalsaType == Salsa.None) Assert.Contains($"Hold Salsa", c.PreparationInformation);
            else if (c.SalsaType != Salsa.Medium) Assert.Contains($"Swap {c.SalsaType} Salsa", c.PreparationInformation);
            if (c.Guacamole) Assert.Contains("Add Guacamole", c.PreparationInformation);
            if (!c.SourCream) Assert.Contains("Hold Sour Cream", c.PreparationInformation);
        }
    }
}
