using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        /// <summary>
        /// Unit test to make sure the subtotal changes the NotifyProperty
        /// </summary>
        [Fact]
        public void ChangingSubtotalShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Subtotal", () => { order.Subtotal = 4.50m; });
        }

        /// <summary>
        ///Unit test to make sure the tax rate changes the NotifyProperty 
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => { order.TaxRate = 0.15m; });
            Assert.PropertyChanged(order, "Tax", () => { order.TaxRate = 0.15m; });
            Assert.PropertyChanged(order, "Total", () => { order.TaxRate = 0.15m; });
        }

        /// <summary>
        /// Unit test to ensure order is assignable from INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /// <summary>
        /// Unit test to ensure the number property updates if it is increased
        /// </summary>
        [Fact]
        public void NumberPropertyUpdatesTest() 
        {
            Order order1 = new Order();
            Order order2 = new Order();
            Assert.NotEqual(order1.Number, order2.Number);
            Assert.Equal(order1.Number+1, order2.Number);
        }

        /// <summary>
        /// Unit test to ensure the PlacedAt property is correct
        /// </summary>
        [Fact]
        public void PlacedAtPropertyTest()
        {
            Order order = new Order();
            Assert.NotStrictEqual(order.PlacedAt, DateTime.Now);
        }

        /// <summary>
        /// Unit test to ensure that the properties dont change if they are requested multiple times
        /// </summary>
        [Fact]
        public void PropertiesDontChangeIfRequestedMoreThanOnceTest() 
        {
            Order order = new Order();

            DateTime firstDate = order.PlacedAt;
            DateTime secondDate = order.PlacedAt;
            uint firstNumber = order.Number;
            uint secondNumber = order.Number;

            Assert.Equal(firstNumber, secondNumber);
            Assert.Equal(firstNumber, secondNumber);
        }
    }
}
