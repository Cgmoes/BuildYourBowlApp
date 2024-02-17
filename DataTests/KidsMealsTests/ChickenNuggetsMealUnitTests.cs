using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class for chicken nuggets meal
    /// </summary>
    public class ChickenNuggetsMealUnitTests
    {
        /// <summary>
        /// Unit test to ensure all the default values are set correctly
        /// </summary>
        [Fact]
        public void DefaultPropertiesAreCorrectTest() 
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();

            Assert.Equal((uint)5, c.Count);
            //Assert.False(c.DrinkChoice.Chocolate);
            //Assert.False(c.SideChoice.Curly);
            Assert.Equal(5.99m, c.Price);
        }

        /// <summary>
        /// Unit test to ensure boundaries of count are enforced
        /// </summary>
        /// <param name="count">count of nuggets in the meal</param>
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(75)]
        public void ChickenNuggetsMealCountPropertyTest(uint count) 
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();
            c.Count = count;

            Assert.Equal((uint)5, c.Count);
        }

        /// <summary>
        /// Unit test to ensure price is being calculated correctly
        /// </summary>
        /// <param name="count">number of nuggets</param>
        /// <param name="size">size of side</param>
        /// <param name="expectedPrice">expected price of the meal</param>
        [Theory]
        [InlineData(5, Size.Kids, 5.99)]
        [InlineData(6, Size.Kids, 6.74)]
        [InlineData(7, Size.Kids, 7.49)]
        [InlineData(8, Size.Kids, 8.24)]
        [InlineData(6, Size.Small, 7.24)]
        [InlineData(7, Size.Medium, 8.49)]
        [InlineData(8, Size.Large, 9.74)]
        [InlineData(5, Size.Large, 7.49)]
        public void ChickenNuggetsMealPriceIsCorrectTest(uint count, Size size, decimal expectedPrice) 
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();
            c.Count = count;
            Fries f = new Fries() { Size = size};
            c.SideChoice = f;

            Assert.Equal(expectedPrice, c.Price);
        }

        /// <summary>
        /// Unit test to ensure the calories of the meal are calculated correctly
        /// </summary>
        /// <param name="count">count of nuggets in meal</param>
        /// <param name="size">size of side in meal</param>
        /// <param name="chocolate">whether or not the milk is chocolate</param>
        /// <param name="expectedCals">expected calories of the meal</param>
        [Theory]
        [InlineData(5, Size.Kids, (5 * 60) + (350 * .6) + 200)]
        [InlineData(6, Size.Small, (6 * 60) + (350 * .75) + 200)]
        [InlineData(7, Size.Medium, (7 * 60) + 350 + 200)]
        [InlineData(8, Size.Large, (8 * 60) + (350 * 1.5) + 200)]
        [InlineData(5, Size.Large, (5 * 60) + (350 * 1.5) + 200)]
        [InlineData(6, Size.Medium, (6 * 60) + 350 + 200)]
        [InlineData(7, Size.Small, (7 * 60) + (350 * .75) + 200)]
        [InlineData(8, Size.Kids, (8 * 60) + (350 * .6) + 200)]
        public void ChickenNuggetsMealCaloriesAreCorrectTest(uint count, Size size, double expectedCals)
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();
            c.Count = count;
            Fries f = new Fries() { Size = size };
            c.SideChoice = f;

            //Want to assert that kids meal calories really is "main " calories + 
            //SideChoice.Calories + DrinkChoice.Calories
            Assert.Equal((uint)expectedCals, c.Calories);
        }

        /// <summary>
        /// Unit test to ensure prep information is printed correctly
        /// </summary>
        /// <param name="count">how many nuggets in the meal</param>
        /// <param name="size">size of the side</param>
        [Theory]
        [InlineData(5, Size.Kids)]
        [InlineData(6, Size.Small)]
        [InlineData(7, Size.Medium)]
        [InlineData(8, Size.Large)]
        [InlineData(5, Size.Large)]
        [InlineData(6, Size.Medium)]
        [InlineData(7, Size.Small)]
        [InlineData(8, Size.Kids)]
        public void PrepInfoIsCorrectTest(uint count, Size size) 
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();
            c.Count = count;
            Fries f = new Fries() { Size = size };
            c.SideChoice = f;

            if(c.Count != 5) Assert.Contains($"{c.Count} Nuggets", c.PreparationInformation);
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<KidsMeal>(c);

            Fries f = new Fries();
            Assert.IsAssignableFrom<IMenuItem>(f);
            Assert.IsAssignableFrom<Side>(f);

            Milk m = new Milk();
            Assert.IsAssignableFrom<IMenuItem>(m);
            Assert.IsAssignableFrom<Drink>(m);
        }
    }
}
