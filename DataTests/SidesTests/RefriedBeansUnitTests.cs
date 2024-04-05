using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class for refried beans
    /// </summary>
    public class RefriedBeansUnitTests
    {
        /// <summary>
        /// Test to ensure all default values are correct
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            RefriedBeans r = new RefriedBeans();

            Assert.True(r.Onions);
            Assert.True(r.CheddarCheese);
            Assert.Equal(Size.Medium, r.Size);
            Assert.Equal(3.75m, r.Price);
            Assert.Equal((uint)300, r.Calories);
        }

        /// <summary>
        /// Unit tests to ensure the price of refried beans is correct
        /// </summary>
        ///         /// <param name="cheese">whether or not it contains cheese</param>
        /// <param name="onions">whether or not it contains onions</param>
        /// <param name="size">Size of the side</param>
        /// <param name="expectedPrice">expected price of the side</param>
        [Theory]
        [InlineData(true, true, Size.Kids, 2.50)]
        [InlineData(true, false, Size.Small, 3.00)]
        [InlineData(false, true, Size.Medium, 3.75)]
        [InlineData(false, false, Size.Large, 4.75)]
        [InlineData(false, false, Size.Kids, 2.50)]
        [InlineData(false, true, Size.Small, 3.00)]
        [InlineData(true, false, Size.Medium, 3.75)]
        [InlineData(true, true, Size.Large, 4.75)]
        public void PriceIsCorrectTest(bool cheese, bool onions, Size size, decimal expectedPrice)
        {
            RefriedBeans r = new RefriedBeans();
            r.Size = size;
            r.CheddarCheese = cheese;
            r.Onions = onions;

            Assert.Equal(expectedPrice, r.Price);
        }

        /// <summary>
        /// Unit test to ensure calories are calculated correctly
        /// </summary>
        /// <param name="cheese">whether or not it contains cheese</param>
        /// <param name="onions">whether or not it contains onions</param>
        /// <param name="size">size of the side</param>
        /// <param name="expectedCals">expected calories</param>
        [Theory]
        [InlineData(true, true, Size.Large, 300 * 1.5)]
        [InlineData(false, false, Size.Kids, (300 - 90 - 5) * .6)]
        [InlineData(true, false, Size.Medium, (300 - 5))]
        [InlineData(false, true, Size.Small, (300-90) * .75)]
        [InlineData(true, true, Size.Small, (300) * .75)]
        [InlineData(true, false, Size.Large, (300-5) * 1.5)]
        [InlineData(false, true, Size.Kids, (300-90) * .6)]
        [InlineData(false, false, Size.Medium, (300-90-5))]
        public void CaloriesAreCorrectTest(bool cheese, bool onions, Size size, double expectedCals) 
        {
            RefriedBeans r = new RefriedBeans();
            r.CheddarCheese = cheese;
            r.Onions = onions;
            r.Size = size;

            Assert.Equal((uint)expectedCals, r.Calories);
        }

        /// <summary>
        /// Unit test to ensure prep information is correct
        /// </summary>
        /// <param name="cheese">whether or not it contains cheese</param>
        /// <param name="onions">whether or not it contains onions</param>
        /// <param name="size">size of the side</param>
        [Theory]
        [InlineData(true, true, Size.Large)]
        [InlineData(false, false, Size.Kids)]
        [InlineData(true, false, Size.Medium)]
        [InlineData(false, true, Size.Small)]
        [InlineData(true, true, Size.Small)]
        [InlineData(true, false, Size.Large)]
        [InlineData(false, true, Size.Kids)]
        [InlineData(false, false, Size.Medium)]
        public void PrepInfoIsCorrectTest(bool cheese, bool onions, Size size)
        {
            RefriedBeans r = new RefriedBeans();
            r.CheddarCheese = cheese;
            r.Onions = onions;
            r.Size = size;

            if(!r.Onions)Assert.Contains("Hold Onions", r.PreparationInformation);
            if (!r.CheddarCheese) Assert.Contains("Hold Cheddar Cheese", r.PreparationInformation);
            Assert.Contains($"{r.Size}", r.PreparationInformation);
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            RefriedBeans r = new RefriedBeans();
            Assert.IsAssignableFrom<IMenuItem>(r);
            Assert.IsAssignableFrom<Side>(r);
        }

        /// <summary>
        /// Unit test to ensure to string is correct
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            RefriedBeans r = new RefriedBeans();
            Assert.Equal(r.Name, r.ToString());
        }

        /// <summary>
        /// Unit test to ensure changing the size notifies the property changed
        /// </summary>
        /// <param name="size">size of the side</param>
        /// <param name="propertyName">the property that should be affected</param>
        [Theory]
        [InlineData(Size.Kids, "Size")]
        [InlineData(Size.Small, "Size")]
        [InlineData(Size.Medium, "Size")]
        [InlineData(Size.Large, "Size")]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Kids, "Calories")]
        [InlineData(Size.Small, "Calories")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Kids, "PreparationInformation")]
        [InlineData(Size.Small, "PreparationInformation")]
        [InlineData(Size.Medium, "PreparationInformation")]
        [InlineData(Size.Large, "PreparationInformation")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(Size size, string propertyName)
        {
            RefriedBeans r = new RefriedBeans();
            Assert.PropertyChanged(r, propertyName, () => {
                r.Size = size;
            });
        }

        /// <summary>
        /// Unit test to ensure changing the onions property affects others
        /// </summary>
        /// <param name="hasOnions">whether or not it has onions</param>
        /// <param name="propertyName">The property that should be affected</param>
        [Theory]
        [InlineData(true, "Onions")]
        [InlineData(false, "Onions")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingOnionsShouldNotifyOfPropertyChanges(bool hasOnions, string propertyName)
        {
            RefriedBeans r = new RefriedBeans();
            Assert.PropertyChanged(r, propertyName, () => {
                r.Onions = hasOnions;
            });
        }

        /// <summary>
        /// Unit test to ensure changing the cheese property affects others
        /// </summary>
        /// <param name="hasCheese">whether or not the it has cheese</param>
        /// <param name="propertyName">The property that should be affected</param>
        [Theory]
        [InlineData(true, "CheddarCheese")]
        [InlineData(false, "CheddarCheese")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingCheddarCheeseShouldNotifyOfPropertyChanges(bool hasCheese, string propertyName)
        {
            RefriedBeans r = new RefriedBeans();
            Assert.PropertyChanged(r, propertyName, () => {
                r.CheddarCheese = hasCheese;
            });
        }
    }
}
