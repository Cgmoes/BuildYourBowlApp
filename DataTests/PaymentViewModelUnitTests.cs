using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Unit testing class for payment view model
    /// </summary>
    public class PaymentViewModelUnitTests
    {
        /// <summary>
        /// Tests the paymentviewmodel integration
        /// </summary>
        [Fact]
        public void PaymentViewModelIntegrationTest() 
        {
            Order order = new Order();
            Assert.Equal((uint)1, order.Number);

            order.Add(CreateSlidersMeal());
            order.Add(CreateBowl());
            order.Add(CreateChickenFajitaNachos());

            Assert.Equal(33.47m, order.Subtotal);
            Assert.Equal(3.06m, order.Tax);
            Assert.Equal(36.53m, order.Total);

            PaymentViewModel view = new PaymentViewModel(order);
            view.Paid = 40.00m;
            Assert.Equal(3.47m, view.Change);

            Order order2 = new Order();
            Assert.Equal((uint)2, order2.Number);

            order2.Add(CreateStreetCorn());
            order2.Add(CreateAguaFresca());
            order2.Add(CreateBuildYourOwnNacho());

            Assert.Equal(17.99m, order2.Subtotal);
            Assert.Equal(1.65m, order2.Tax);
            Assert.Equal(19.64m, order2.Total);

            PaymentViewModel view2 = new PaymentViewModel(order2);
            Assert.Throws<ArgumentException>(() => view2.Paid = 15.00m);
        }

        /// <summary>
        /// Creates a sliders meal to be used in an order
        /// </summary>
        /// <returns>the sliders meal</returns>
        public SlidersMeal CreateSlidersMeal() 
        {
            SlidersMeal s = new SlidersMeal() 
            {
                KidsCount = 3, 
                AmericanCheese = false,
                SideChoice = new RefriedBeans() {Size = Size.Medium, Onions = false},
                DrinkChoice = new AguaFresca() { _size = Size.Large, Ice = false}
            };
            return s;
        }

        /// <summary>
        /// Creates a custom bowl
        /// </summary>
        /// <returns>the custom bowl</returns>
        public Bowl CreateBowl() 
        {
            Bowl b = new Bowl();
            b.PossibleToppings[Ingredient.Steak].Included = true;
            b.PossibleToppings[Ingredient.Queso].Included = true;
            b.PossibleToppings[Ingredient.SourCream].Included = true;
            return b;
        }

        /// <summary>
        /// Creates chicken fajita nachos
        /// </summary>
        /// <returns>the chicken fajita nachos</returns>
        public ChickenFajitaNachos CreateChickenFajitaNachos() 
        {
            ChickenFajitaNachos cfn = new ChickenFajitaNachos();
            cfn.PossibleToppings[Ingredient.Guacamole].Included = true;
            cfn.PossibleToppings[Ingredient.SourCream].Included = false;
            cfn.SalsaType = Salsa.None;
            return cfn;
        }

        /// <summary>
        /// Creates street corn
        /// </summary>
        /// <returns>the street corn</returns>
        public StreetCorn CreateStreetCorn() 
        {
            StreetCorn s = new StreetCorn() 
            {
                _size = Size.Large,
                Cilantro = false 
            };

            return s;
        }

        /// <summary>
        /// Creates agua fresca drink
        /// </summary>
        /// <returns>the agua fres</returns>
        public AguaFresca CreateAguaFresca() 
        {
            AguaFresca af = new AguaFresca()
            {
                _size = Size.Kids,
                _drinkFlavor = Flavor.Tamarind
            };
            return af;
        }

        public Nacho CreateBuildYourOwnNacho() 
        {
            Nacho n = new Nacho();
            n.PossibleToppings[Ingredient.BlackBeans].Included = true;
            n.PossibleToppings[Ingredient.PintoBeans].Included = true;
            n.PossibleToppings[Ingredient.Veggies].Included = true;
            n.SalsaType = Salsa.Green;
            return n;
        }
    }
}
