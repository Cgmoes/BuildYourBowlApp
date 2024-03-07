using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class for corn dog kids meal
    /// </summary>
    public class CornDogBitesMealUnitTests
    {
        /// <summary>
        /// Tests to ensure default values are correct
        /// </summary>
        [Fact]
        public void DefaultValuesTest() 
        {
            CornDogBitesMeal c = new CornDogBitesMeal();

            Assert.Equal((uint)5, c.Count);
            Assert.False((c.DrinkChoice as Milk)!.Chocolate);
            Assert.False((c.SideChoice as Fries)!.Curly);
            Assert.Equal(5.99m, c.Price);
        }

        /// <summary>
        /// Unit test to ensure bounds of count property are correct
        /// </summary>
        /// <param name="count"></param>
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(75)]
        public void CountPropertyIsCorrectTest(uint count) 
        {
            CornDogBitesMeal c = new CornDogBitesMeal();
            c.Count = count;

            Assert.Equal((uint) 5, c.Count);
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
        public void MealPriceIsCorrectTest(uint count, Size size, decimal expectedPrice)
        {
            CornDogBitesMeal c = new CornDogBitesMeal();
            c.Count = count;
            Fries f = new Fries() { Size = size };
            c.SideChoice = f;

            Assert.Equal(expectedPrice, c.Price);
        }

        /// <summary>
        /// Unit test to ensure the calories are being calculated correctly
        /// </summary>
        /// <param name="count">how many corn dog bites there are</param>
        /// <param name="expectedCals">expected calories of the meal</param>
        [Theory]
        [InlineData(5, Size.Kids, (5 * 50) + (350 * .6) + 200)]
        [InlineData(6, Size.Small, (6 * 50) + (350 * .75) + 200)]
        [InlineData(7, Size.Medium, (7 * 50) + 350 + 200)]
        [InlineData(8, Size.Large, (8 * 50) + (350 * 1.5) + 200)]
        [InlineData(5, Size.Large, (5 * 50) + (350 * 1.5) + 200)]
        [InlineData(6, Size.Medium, (6 * 50) + 350 + 200)]
        [InlineData(7, Size.Small, (7 * 50) + (350 * .75) + 200)]
        [InlineData(8, Size.Kids, (8 * 50) + (350 * .6) + 200)]
        public void CaloriesAreCorrectTest(uint count, Size frySize, uint expectedCals) 
        {
            CornDogBitesMeal c = new CornDogBitesMeal();
            c.Count = count;
            Fries f = new Fries() { Size = frySize };
            c.SideChoice = f;

            Assert.Equal(expectedCals, c.Calories);
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
            CornDogBitesMeal c = new CornDogBitesMeal();
            c.Count = count;
            Fries f = new Fries() { Size = size };
            c.SideChoice = f;

            if (c.Count != 5) Assert.Contains($"{c.Count} Bites", c.PreparationInformation);
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            CornDogBitesMeal c = new CornDogBitesMeal();
            Assert.IsAssignableFrom<IMenuItem>(c);
            Assert.IsAssignableFrom<KidsMeal>(c);

            Fries f = new Fries();
            Assert.IsAssignableFrom<IMenuItem>(f);
            Assert.IsAssignableFrom<Side>(f);

            Milk m = new Milk();
            Assert.IsAssignableFrom<IMenuItem>(m);
            Assert.IsAssignableFrom<Drink>(m);
        }

        /// <summary>
        /// Unit test to ensure to string is correct
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            CornDogBitesMeal c = new CornDogBitesMeal();
            Assert.Equal(c.Name, c.ToString());
        }
    }
}
