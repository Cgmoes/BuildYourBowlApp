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
        [Fact]
        public void DefaultPropertiesAreCorrect() 
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();

            Assert.Equal((uint)5, c.Count);
            Assert.False(c.DrinkChoice.Chocolate);
            Assert.False(c.SideChoice.Curly);
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
        /// Unit test to ensure side choice property is correct
        /// </summary>
        [Fact]
        public void ChickenNuggetsMealSideChoiceTest() 
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();
            Fries fries = new Fries() { FrySize = Size.Kids };

            Assert.Equal(fries, c.SideChoice);
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
            Fries f = new Fries() { FrySize = size};
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
        [InlineData(5, Size.Kids, false, 510 + 200)]
        [InlineData(6, Size.Kids, false, 570 + 200)]
        [InlineData(7, Size.Kids, false, (60 * 7) + (350 * .6) + 200)]
        [InlineData(8, Size.Kids, false, 690 + 200)]
        [InlineData(6, Size.Small, false, 360 + (350 * .75) + 200)]

        //2 Unit test below are failing
        [InlineData(7, Size.Medium, true, 420 + 350 + 270)]
        [InlineData(8, Size.Large, true, 480 + (350 * 1.5) + 270)]

        [InlineData(5, Size.Large, false, 300 + (350 * 1.5) + 200)]
        public void ChickenNuggetsMealCaloriesAreCorrectTest(uint count, Size size, bool chocolate, double expectedCals)
        {
            ChickenNuggetsMeal c = new ChickenNuggetsMeal();
            c.Count = count;
            Fries f = new Fries() { FrySize = size };
            Milk m = new Milk() { Chocolate = chocolate };
            c.SideChoice = f;

            //Want to assert that kids meal calories really is "main " calories + 
            //SideChoice.Calories + DrinkChoice.Calories
            Assert.Equal((uint)expectedCals, c.Calories);
        }
    }
}
