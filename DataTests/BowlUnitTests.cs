using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit test classs for base bowl
    /// </summary>
    public class BowlUnitTests
    {
        /// <summary>
        /// Unit test to ensure to string is correct
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Bowl b = new Bowl();
            Assert.Equal(b.Name, b.ToString());
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            Bowl b = new Bowl();
            Assert.IsAssignableFrom<IMenuItem>(b);
            Assert.IsAssignableFrom<Entree>(b);
        }
    }
}
