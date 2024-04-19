using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            Assert.Contains(Menu.Entrees, item => item is Bowl && item is not CarnitasBowl && item is not GreenChickenBowl && item is not SpicySteakBowl);
            Assert.Contains(Menu.Entrees, item => item is CarnitasBowl && item is not GreenChickenBowl && item is not SpicySteakBowl);
            Assert.Contains(Menu.Entrees, item => item is not CarnitasBowl && item is GreenChickenBowl && item is not SpicySteakBowl);
            Assert.Contains(Menu.Entrees, item => item is not CarnitasBowl && item is not GreenChickenBowl && item is SpicySteakBowl);

            Assert.Contains(Menu.Entrees, item => item is Nacho && item is not ChickenFajitaNachos && item is not ClassicNachos);
            Assert.Contains(Menu.Entrees, item => item is ChickenFajitaNachos && item is not ClassicNachos);
            Assert.Contains(Menu.Entrees, item => item is not ChickenFajitaNachos && item is ClassicNachos);
        }

        /// <summary>
        /// Unit test to ensure that the property sides is correct
        /// </summary>
        [Fact]
        public void SidesIsCorrectTest() 
        {
            Assert.Equal(4 * (2 + 2 * 2 + 2 * 2), Menu.Sides.Count());

            foreach (Size size in Enum.GetValues(typeof(Size))) 
            {
                Assert.Contains(Menu.Sides, item => item is Fries f && f.Curly);
                Assert.Contains(Menu.Sides, item => item is Fries f && !f.Curly);

                Assert.Contains(Menu.Sides, item => item is RefriedBeans r && !r.CheddarCheese && !r.Onions);
                Assert.Contains(Menu.Sides, item => item is RefriedBeans r && !r.CheddarCheese && r.Onions);
                Assert.Contains(Menu.Sides, item => item is RefriedBeans r && r.CheddarCheese && !r.Onions);
                Assert.Contains(Menu.Sides, item => item is RefriedBeans r && r.CheddarCheese && r.Onions);

                Assert.Contains(Menu.Sides, item => item is StreetCorn s && !s.CotijaCheese && !s.Cilantro);
                Assert.Contains(Menu.Sides, item => item is StreetCorn s && s.CotijaCheese && !s.Cilantro);
                Assert.Contains(Menu.Sides, item => item is StreetCorn s && !s.CotijaCheese && s.Cilantro);
                Assert.Contains(Menu.Sides, item => item is StreetCorn s && s.CotijaCheese && s.Cilantro);
            }
        }

        /// <summary>
        /// Unit test to ensure that the property drinks is correct
        /// </summary>
        [Fact]
        public void DrinksIsCorrectTest() 
        {
            Assert.Equal(4 * (1 * 2 + 1 * 2 + 2 * 2), Menu.Drinks.Count());

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                Assert.Contains(Menu.Drinks, item => item is Milk m && !m.Chocolate);
                Assert.Contains(Menu.Drinks, item => item is Milk m && m.Chocolate);

                Assert.Contains(Menu.Drinks, item => item is Horchata);

                foreach (Flavor flavor in Enum.GetValues(typeof(Flavor))) Assert.Contains(Menu.Drinks, item => item is AguaFresca);
            }
        }

        /// <summary>
        /// Unit test to ensure that the property kids meals is correct
        /// </summary>
        [Fact]
        public void KidsMealsIsCorrectTest()
        {
            Assert.Equal(1 * (3 * 3 + 3 * 3 + 2 * 3 * 3), Menu.KidsMeals.Count());

            List<Side> sides = new List<Side> { new Fries(), new RefriedBeans(), new StreetCorn() };
            List<Drink> drinks = new List<Drink> { new Milk(), new Horchata(), new AguaFresca() };

            foreach (Side side in sides)
            {
                foreach (Drink drink in drinks)
                {
                    Assert.Contains(Menu.KidsMeals, item => item is ChickenNuggetsMeal k && k.SideChoice.Equals(side) && k.DrinkChoice.Equals(drink));
                    
                    Assert.Contains(Menu.KidsMeals, item => item is CornDogBitesMeal k && k.SideChoice.Equals(side) && k.DrinkChoice.Equals(drink));

                    Assert.Contains(Menu.KidsMeals, item => item is SlidersMeal k && k.AmericanCheese == true && k.SideChoice.Equals(side) && k.DrinkChoice.Equals(drink));
                    Assert.Contains(Menu.KidsMeals, item => item is SlidersMeal k && k.AmericanCheese == false && k.SideChoice.Equals(side) && k.DrinkChoice.Equals(drink));
                }
            }
        }
    }
}
