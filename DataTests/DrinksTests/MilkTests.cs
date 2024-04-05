using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class for milk
    /// </summary>
    public class MilkTests
    {
        /// <summary>
        /// Unit test to make sure Milk defaults to not having chocolate
        /// </summary>
        [Fact]
        public void MilkHasNoChocolateDefaultTest()
        {
            Milk m = new Milk();
            Assert.False(m.Chocolate);
        }

        /// <summary>
        /// Unit test to make sure the price of milk is correct
        /// </summary>
        [Fact]
        public void MilkPriceIsCorrectTest() 
        {
            Milk m = new Milk();
            Assert.Equal(2.50m, m.Price);
        }

        /// <summary>
        /// Unit test to make sure the calories is set correctly
        /// </summary>
        /// <param name="choc">whether or not the milk is chocolate</param>
        /// <param name="expectedCals">The expected amount of calories</param>
        [Theory]
        [InlineData(false, 200)]
        [InlineData(true, 270)]
        public void MilkCaloriesIsCorrectTest(bool choc, uint expectedCals) 
        {
            Milk m = new Milk();
            m.Chocolate = choc;
            Assert.Equal(expectedCals, m.Calories);
        }

        /// <summary>
        /// Unit test to ensure the prep info is calculated correctly
        /// </summary>
        /// <param name="choc"></param>
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void MilkPrepInfoIsCorrectTest(bool choc) 
        {
            Milk m = new Milk();
            m.Chocolate = choc;

            if(m.Chocolate) Assert.Contains("Chocolate", m.PreparationInformation);
            Assert.Contains(m.Size.ToString(), m.PreparationInformation);
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
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
            Milk m = new Milk();
            Assert.Equal(m.Name, m.ToString());
        }

        /// <summary>
        /// Unit test to ensure INotifyChanged is properly implemented for changing the size
        /// </summary>
        /// <param name="size">The size to test</param>
        /// <param name="propertyName">the property that should be changed</param>
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
        public void ChangingSizeShouldNotifyOfPropertyChangesTest(Size size, string propertyName)
        {
            AguaFresca af = new AguaFresca();
            Assert.PropertyChanged(af, propertyName, () => {
                af.Size = size;
            });
        }

        /// <summary>
        /// Unit test to ensure that changing the ice property affects the correct properties
        /// </summary>
        /// <param name="ice">whether or not the drink has ice</param>
        /// <param name="propertyName">the property that should be affected</param>
        [Theory]
        [InlineData(true, "Chocolate")]
        [InlineData(true, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Chocolate")]
        [InlineData(false, "Calories")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingChocolateShouldNotifyOfPropertyChangesTest(bool chocolate, string propertyName)
        {
            Milk m = new Milk();
            Assert.PropertyChanged(m, propertyName, () => {
                m.Chocolate = chocolate;
            });
        }
    }
}
