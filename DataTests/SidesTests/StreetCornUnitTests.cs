using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test class
    /// </summary>
    public class StreetCornUnitTests
    {
        /// <summary>
        /// Unit tests to ensure the default values are correct
        /// </summary>
        [Fact]
        public void DefaultValuesAreCorrectTest() 
        {
            StreetCorn s = new StreetCorn();

            Assert.True(s.CotijaCheese);
            Assert.True(s.Cilantro);
            Assert.Equal(Size.Medium, s.Size);
            Assert.Equal(4.50m, s.Price);
            Assert.Equal((uint)300, s.Calories);
        }

        /// <summary>
        /// Unit test to ensure the price is being set correctly
        /// </summary>
        /// <param name="size">size of the corn</param>
        /// <param name="expectedPrice">expected price of the fries</param>
        [Theory]
        [InlineData(true, true, Size.Kids, 3.25)]

        //Specific required test case
        [InlineData(true, false, Size.Small, 3.75)]

        [InlineData(false, true, Size.Medium, 4.50)]
        [InlineData(false, false, Size.Large, 5.50)]
        [InlineData(false, false, Size.Kids, 3.25)]
        [InlineData(false, true, Size.Small, 3.75)]
        [InlineData(true, false, Size.Medium, 4.50)]
        [InlineData(true, true, Size.Large, 5.50)]
        public void CornPriceTest(bool cheese, bool cilantro, Size size, decimal expectedPrice)
        {
            StreetCorn s = new StreetCorn();
            s.Size = size;
            s.CotijaCheese = cheese;
            s.Cilantro = cilantro;

            Assert.Equal(expectedPrice, s.Price);
        }

        /// <summary>
        /// Unit test to ensure the calories are being set correctly
        /// </summary>
        /// <param name="cheese">whether or not the corn has american cheese</param>
        /// <param name="cilantro">whether or not the corn has cilantro</param>
        /// <param name="size">size of the side</param>
        /// <param name="expectedCals">expected calories of the side</param>
        [Theory]
        [InlineData(true, true, Size.Kids, (300) * .6)]

        //Specific required test case
        [InlineData(true, false, Size.Small, (300-5)*.75)]

        [InlineData(false, true, Size.Medium, (300-80))]
        [InlineData(false, false, Size.Large, (300-80-5)*1.5)]
        [InlineData(false, false, Size.Kids, (300-80-5) * .6)]
        [InlineData(false, true, Size.Small, (300-80)*.75)]
        [InlineData(true, false, Size.Medium, (300 - 5))]
        [InlineData(true, true, Size.Large, (300) * 1.5)]
        public void CornCaloriesTest(bool cheese, bool cilantro, Size size, double expectedCals) 
        {
            StreetCorn s = new StreetCorn();
            s.CotijaCheese = cheese;
            s.Cilantro = cilantro;
            s.Size = size;

            Assert.Equal((uint)expectedCals, s.Calories);
        }

        /// <summary>
        /// Unit test to ensure the calories are being set correctly
        /// </summary>
        /// <param name="cheese">whether or not the corn has american cheese</param>
        /// <param name="cilantro">whether or not the corn has cilantro</param>
        /// <param name="size">size of the side</param>
        /// <param name="expectedCals">expected calories of the side</param>
        [Theory]
        [InlineData(true, true, Size.Kids)]

        //Specific required test case
        [InlineData(true, false, Size.Small)]

        [InlineData(false, true, Size.Medium)]
        [InlineData(false, false, Size.Large)]
        [InlineData(false, false, Size.Kids)]
        [InlineData(false, true, Size.Small)]
        [InlineData(true, false, Size.Medium)]
        [InlineData(true, true, Size.Large)]
        public void CornPrepInfoTest(bool cheese, bool cilantro, Size size)
        {
            StreetCorn s = new StreetCorn();
            s.CotijaCheese = cheese;
            s.Cilantro = cilantro;
            s.Size = size;

            if(!s.CotijaCheese)Assert.Contains("Hold Cotija Cheese", s.PreparationInformation);
            if (!s.Cilantro) Assert.Contains("Hold Cilantro", s.PreparationInformation);
            Assert.Contains($"{s.Size}", s.PreparationInformation);
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            StreetCorn s = new StreetCorn();
            Assert.IsAssignableFrom<IMenuItem>(s);
            Assert.IsAssignableFrom<Side>(s);
        }

        /// <summary>
        /// Unit test to ensure to string is correct
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            StreetCorn s = new StreetCorn();
            Assert.Equal(s.Name, s.ToString());
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
            StreetCorn s = new StreetCorn();
            Assert.PropertyChanged(s, propertyName, () => {
                s.Size = size;
            });
        }

        /// <summary>
        /// Unit test to ensure changing the cilantro property affects others
        /// </summary>
        /// <param name="hasCilantro">whether or not the it has cilantro</param>
        /// <param name="propertyName">The property that should be affected</param>
        [Theory]
        [InlineData(true, "Cilantro")]
        [InlineData(false, "Cilantro")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingCilantroShouldNotifyOfPropertyChanges(bool hasCilantro, string propertyName)
        {
            StreetCorn s = new StreetCorn();
            Assert.PropertyChanged(s, propertyName, () => {
                s.Cilantro = hasCilantro;
            });
        }

        /// <summary>
        /// Unit test to ensure changing the cheese property affects others
        /// </summary>
        /// <param name="hasCheese">whether or not it has cheese</param>
        /// <param name="propertyName">The property that should be affected</param>
        [Theory]
        [InlineData(true, "CotijaCheese")]
        [InlineData(false, "CotijaCheese")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingCotijaCheeseShouldNotifyOfPropertyChanges(bool hasCheese, string propertyName)
        {
            StreetCorn s = new StreetCorn();
            Assert.PropertyChanged(s, propertyName, () => {
                s.CotijaCheese = hasCheese;
            });
        }
    }
}
