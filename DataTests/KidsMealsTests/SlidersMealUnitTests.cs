using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Class for sliders meal unit tests
    /// </summary>
    public class SlidersMealUnitTests
    {
        /// <summary>
        /// Unit tests for all default values
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            SlidersMeal s = new SlidersMeal();

            Assert.Equal((uint)2, s.Count);
            Assert.True(s.AmericanCheese);
            //Assert.False(s.DrinkChoice.Chocolate);
            //Assert.False(s.SideChoice.Curly);
            Assert.Equal(5.99m, s.Price);
        }

        /// <summary>
        /// Unit test to ensure boundaries of count are enforced
        /// </summary>
        /// <param name="count">count of sliders in the meal</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void SlidersMealCountPropertyTest(uint count)
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();
            c.Count = count;

            Assert.Equal((uint)5, c.Count);
        }

        /// <summary>
        /// Unit test to ensure price is being calculated correctly
        /// </summary>
        /// <param name="count">number of sliders</param>
        /// <param name="size">size of side</param>
        /// <param name="expectedPrice">expected price of the meal</param>
        [Theory]
        [InlineData(false, 2, Size.Kids, 5.99)]
        [InlineData(false, 3, Size.Kids, 7.99)]
        [InlineData(true, 4, Size.Kids, 9.99)]
        [InlineData(false, 2, Size.Small, 6.49)]
        [InlineData(true, 3, Size.Small, 8.49)]
        [InlineData(true, 4, Size.Small, 10.49)]
        [InlineData(true, 2, Size.Medium, 6.99)]

        //Specific required test case
        [InlineData(false, 3, Size.Large, 9.49)]

        public void SlidersPriceIsCorrectTest(bool cheese, uint count, Size size, decimal expectedPrice) 
        {
            SlidersMeal s = new SlidersMeal();
            s.AmericanCheese = cheese;
            s.Count = count;
            Fries f = new Fries() { Size = size };
            s.SideChoice = f;

            Assert.Equal(expectedPrice, s.Price);
        }

        /// <summary>
        /// Unit test to ensure the calories are calculated correctly
        /// </summary>
        /// <param name="cheese">Whether or not the sliders have cheese</param>
        /// <param name="count">Number of sliders</param>
        /// <param name="expectedCals">expected calories of the meal</param>
        [Theory]
        [InlineData(false, 2, Size.Kids, 2 * (150 - 40) + (350 * .6) + 200)]
        [InlineData(true, 2, Size.Small, 2 * (150) + (350 * .75) + 200)]
        [InlineData(true, 3, Size.Medium, 3 * 150 + 350 + 200)]

        //Specific required test case
        [InlineData(false, 3, Size.Large, 3 * (150-40) + (350 * 1.5) + 200)]

        [InlineData(false, 4, Size.Kids, 4 * (150 - 40) + (350 * .6) + 200)]
        [InlineData(true, 4, Size.Small, 4 * (150) + (350 * .75) + 200)]
        [InlineData(true, 2, Size.Large, 2 * (150) + (350 * 1.5) + 200)]
        [InlineData(false, 3, Size.Small, 3 * (150 - 40) + (350 * .75) + 200)]
        public void SlidersCaloriesAreCorrectTest(bool cheese, uint count, Size sideSize, double expectedCals) 
        {
            SlidersMeal s = new SlidersMeal();
            s.AmericanCheese = cheese;
            s.Count = count;
            Fries f = new Fries() { Size = sideSize };
            s.SideChoice = f;

            Assert.Equal((uint)expectedCals, s.Calories);
        }

        /// <summary>
        /// Unit test to ensure the calories are calculated correctly
        /// </summary>
        /// <param name="cheese">Whether or not the sliders have cheese</param>
        /// <param name="count">Number of sliders</param>
        [Theory]
        [InlineData(false, 2, Size.Kids)]
        [InlineData(true, 2, Size.Small)]

        //Specific required test case
        [InlineData(false, 3, Size.Large)]

        [InlineData(true, 3, Size.Medium)]
        [InlineData(false, 4, Size.Kids)]
        [InlineData(true, 4, Size.Small)]
        [InlineData(true, 2, Size.Large)]
        [InlineData(false, 3, Size.Small)]
        public void PrepInfoIsCorrectTest(bool cheese, uint count, Size sideSize)
        {
            SlidersMeal s = new SlidersMeal();
            s.AmericanCheese = cheese;
            s.Count = count;
            Fries f = new Fries() { Size = sideSize };
            s.SideChoice = f;

            if (s.Count != 2) Assert.Contains($"{s.Count} Sliders", s.PreparationInformation);
            if (!s.AmericanCheese) Assert.Contains($"Hold American Cheese", s.PreparationInformation);
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            SlidersMeal s = new SlidersMeal();
            Assert.IsAssignableFrom<IMenuItem>(s);
            Assert.IsAssignableFrom<KidsMeal>(s);

            Fries f = new Fries();
            Assert.IsAssignableFrom<IMenuItem>(f);
            Assert.IsAssignableFrom<Side>(f);

            Milk m = new Milk();
            Assert.IsAssignableFrom<IMenuItem>(m);
            Assert.IsAssignableFrom<Drink>(m);
        }
    }
}
