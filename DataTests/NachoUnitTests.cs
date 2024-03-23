using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// class definition for nacho unit tests
    /// </summary>
    public class NachoUnitTests
    {
        /// <summary>
        /// Unit test to ensure to string is correct
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Nacho n = new Nacho();
            Assert.Equal(n.Name, n.ToString());
        }

        /// <summary>
        /// Unit test to make sure this class can be casted to inherited classes
        /// </summary>
        [Fact]
        public void CanBeCastedTest()
        {
            Nacho n = new Nacho();
            Assert.IsAssignableFrom<IMenuItem>(n);
            Assert.IsAssignableFrom<SpicySteakBowl>(n);
        }
    }
}
