using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Test class for Menu.cs
    /// </summary>
    public class MenuUnitTests
    {
        /// <summary>
        /// Unit test to ensure that the property entrees is correct
        /// </summary>
        [Fact]
        public void EntreesIsCorrectTest() 
        {
            Assert.Equal(1 * (1 + 1 + 1 + 1 + 1 + 1 + 1), Menu.Entrees.Count());   
        }

        /// <summary>
        /// Unit test to ensure that the property sides is correct
        /// </summary>
        [Fact]
        public void SidesIsCorrectTest() 
        {
            Assert.Equal(4 * (2 + 2 * 2 + 2 * 2), Menu.Sides.Count());
        }

        /// <summary>
        /// Unit test to ensure that the property drinks is correct
        /// </summary>
        [Fact]
        public void DrinksIsCorrectTest() 
        {
            Assert.Equal(4 * (2 * 2 + 1 * 2 + 2 * 2), Menu.Drinks.Count());
        }

        /// <summary>
        /// Unit test to ensure that the property kids meals is correct
        /// </summary>
        [Fact]
        public void KidsMealsIsCorrectTest()
        {
            Assert.Equal(1 * (3 * 3 + 3 * 3 + 2 * 3 * 3), Menu.KidsMeals.Count());
        }
    }
}
