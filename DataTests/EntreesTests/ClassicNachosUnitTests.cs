﻿using BuildYourBowl.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// unit tests for classic nachos
    /// </summary>
    public class ClassicNachosUnitTests
    {
        /// <summary>
        /// Unit test to check if the steak default value is correct
        /// </summary>
        [Fact]
        public void ClassicNachosDefaultSteakIsCorrectTest() 
        {
            ClassicNachos cn = new ClassicNachos();
            Assert.True(cn.Steak);
        }

        /// <summary>
        /// Unit test to check if the Chicken default value is correct
        /// </summary>
        [Fact]
        public void ClassicNachosDefaultChickenIsCorrectTest()
        {
            ClassicNachos cn = new ClassicNachos();
            Assert.True(cn.Chicken);
        }

        /// <summary>
        /// Unit test to check if the queso default value is correct
        /// </summary>
        [Fact]
        public void ClassicNachosDefaultQuesoIsCorrectTest()
        {
            ClassicNachos cn = new ClassicNachos();
            Assert.True(cn.Queso);
        }

        /// <summary>
        /// Unit test to check if the salsa default value is correct
        /// </summary>
        [Fact]
        public void ClassicNachosDefaultSalsaTypeIsCorrectTest()
        {
            ClassicNachos cn = new ClassicNachos();
            Assert.Equal(Salsa.Medium, cn.SalsaType);
        }

        /// <summary>
        /// Unit test to check if the guacamole default value is correct
        /// </summary>
        [Fact]
        public void ClassicNachosDefaultGuacIsCorrectTest()
        {
            ClassicNachos cn = new ClassicNachos();
            Assert.False(cn.Guacamole);
        }

        /// <summary>
        /// Unit test to check if the sour cream default value is correct
        /// </summary>
        [Fact]
        public void ClassicNachosDefaultSourCreamIsCorrectTest()
        {
            ClassicNachos cn = new ClassicNachos();
            Assert.False(cn.SourCream);
        }

        [Fact]
        public void DefaultPriceAndCaloriesAreCorrectTest() 
        {
            ClassicNachos cn = new ClassicNachos();

            Assert.Equal(12.99m, cn.Price);
            Assert.Equal((uint)710, cn.Calories);
        }

        /// <summary>
        /// Unit test to check if the price is being calculated correctly
        /// </summary>
        /// <param name="steak">whether or not the bowl contains steak</param>
        /// <param name="chicken">whether or not the bowl contains chicken/param>
        /// <param name="queso">whether or not the bowl contains queso</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">whether or not the bowl contains guacamole</param>
        /// <param name="sourCream">whether or not the bowl contains sour cream</param>
        /// <param name="expectedPrice">expected price of the bowl</param>
        [Theory]
        [InlineData(true, true, true, Salsa.Medium, false, false, 12.99)]
        [InlineData(true, true, true, Salsa.Medium, true, false, 13.99)]
        [InlineData(false, true, true, Salsa.None, false, false, 12.99)]
        [InlineData(true, false, true, Salsa.Hot, false, false, 12.99)]
        [InlineData(true, true, false, Salsa.Medium, false, false, 12.99)]
        [InlineData(false, false, true, Salsa.Mild, false, true, 12.99)]
        [InlineData(true, true, true, Salsa.Medium, true, true, 13.99)]
        [InlineData(false, false, true, Salsa.None, false, false, 12.99)]
        public void ClassicNachosPriceIsCorrectTest(bool steak, bool chicken, bool queso, Salsa salsa, bool guac, bool sourCream, decimal expectedPrice) 
        {
            ClassicNachos cn = new ClassicNachos();
            cn.Steak = steak;
            cn.Chicken = chicken;
            cn.Queso = queso;
            cn.SalsaType = salsa;
            cn.Guacamole = guac;
            cn.SourCream = sourCream;

            Assert.Equal(expectedPrice, cn.Price);
        }

        /// <summary>
        /// Unit test to check if the calories are being calculated correctly
        /// </summary>
        /// <param name="steak">whether or not the bowl contains steak</param>
        /// <param name="chicken">whether or not the bowl contains chicken/param>
        /// <param name="queso">whether or not the bowl contains queso</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">whether or not the bowl contains guacamole</param>
        /// <param name="sourCream">whether or not the bowl contains sour cream</param>
        /// <param name="expectedCalories">expected price of the bowl</param>
        [Theory]
        [InlineData(true, true, true, Salsa.Medium, false, false, 710)]
        [InlineData(true, true, true, Salsa.Medium, true, false, 860)]
        [InlineData(false, true, true, Salsa.None, false, false, 510)]
        [InlineData(true, false, true, Salsa.Hot, false, false, 560)]
        [InlineData(true, true, false, Salsa.Medium, false, false, 600)]
        [InlineData(false, false, true, Salsa.Mild, false, true, 480)]
        [InlineData(true, true, true, Salsa.Medium, true, true, 960)]
        [InlineData(false, false, true, Salsa.None, false, false, 360)]
        public void ClassicNachosCaloriesAreCorrectTest(bool steak, bool chicken, bool queso, Salsa salsa, bool guac, bool sourCream, decimal expectedCalories)
        {
            ClassicNachos cn = new ClassicNachos();
            cn.Steak = steak;
            cn.Chicken = chicken;
            cn.Queso = queso;
            cn.SalsaType = salsa;
            cn.Guacamole = guac;
            cn.SourCream = sourCream;

            Assert.Equal(expectedCalories, cn.Calories);
        }

        /// <summary>
        /// Unit test to ensure prep infor is correct
        /// </summary>
        /// <param name="steak">whether or not the bowl contains steak</param>
        /// <param name="chicken">whether or not the bowl contains chicken/param>
        /// <param name="queso">whether or not the bowl contains queso</param>
        /// <param name="salsa">The type of salsa in the bowl</param>
        /// <param name="guac">whether or not the bowl contains guacamole</param>
        /// <param name="sourCream">whether or not the bowl contains sour cream</param>
        [Theory]
        [InlineData(true, true, true, Salsa.Medium, false, false)]
        [InlineData(true, true, true, Salsa.Medium, true, false)]
        [InlineData(false, true, true, Salsa.None, false, false)]
        [InlineData(true, false, true, Salsa.Hot, false, false)]
        [InlineData(true, true, false, Salsa.Medium, false, false)]
        [InlineData(false, false, true, Salsa.Mild, false, true)]
        [InlineData(true, true, true, Salsa.Medium, true, true)]
        [InlineData(false, false, true, Salsa.None, false, false)]
        public void ClassicNachosPrepInfoIsCorrectTest(bool steak, bool chicken, bool queso, Salsa salsa, bool guac, bool sourCream) 
        {
            ClassicNachos cn = new ClassicNachos();
            cn.Steak = steak;
            cn.Chicken = chicken;
            cn.Queso = queso;
            cn.SalsaType = salsa;
            cn.Guacamole = guac;
            cn.SourCream = sourCream;

            if(!cn.Chicken)Assert.Contains("Hold Chicken", cn.PreparationInformation);
            if(!cn.Steak)Assert.Contains("Hold Steak", cn.PreparationInformation);
            if(!cn.Queso)Assert.Contains("Hold Queso", cn.PreparationInformation);
            if(cn.SourCream)Assert.Contains("Add Sour Cream", cn.PreparationInformation);
            if (cn.SalsaType == Salsa.None) Assert.Contains($"Hold Salsa", cn.PreparationInformation);
            else if (cn.SalsaType != Salsa.Medium) Assert.Contains($"Swap {cn.SalsaType} Salsa", cn.PreparationInformation);
            if (cn.Guacamole) Assert.Contains("Add Guacamole", cn.PreparationInformation);
        }
    }
}
