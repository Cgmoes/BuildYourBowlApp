using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Class definition for order unit tests
    /// </summary>
    public class OrderUnitTests
    {
        /// <summary>
        /// Mock Menu item for testing
        /// </summary>
        internal class MockMenuItem : IMenuItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public uint Calories { get; set; }
            public IEnumerable<string> PreparationInformation { get; set; }
        }

        /// <summary>
        /// Unit test to ensure subtotal is calculated correctly
        /// </summary>git
        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }

        /// <summary>
        /// Unit test to ensure tax rate is set correctly
        /// </summary>
        [Fact]
        public void TaxRateIsCorrectTest() 
        {
            Order o = new Order();
            Assert.Equal(.0915m, o.TaxRate);
        }

        /// <summary>
        /// Unit test to ensure tax is calculated correctly
        /// </summary>
        [Fact]
        public void TaxIsCorrectTest() 
        {
            Order o = new Order();
            Assert.Equal(o.Subtotal * o.TaxRate, o.Tax);
        }

        /// <summary>
        /// Unit test to ensure total is calculated correctly
        /// </summary>
        [Fact]
        public void TotalIsCorrectTest()
        {
            Order o = new Order();
            Assert.Equal(o.Subtotal + o.Tax, o.Total);
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            Order o = new Order();
            Assert.IsAssignableFrom<ICollection<IMenuItem>>(o);
        }
    }
}
