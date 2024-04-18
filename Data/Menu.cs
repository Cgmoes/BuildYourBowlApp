using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// Class definition for menu
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// returns all the combinations of entrees
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees 
        {
            get 
            {
                yield return new Bowl();
                yield return new Nacho();
                yield return new CarnitasBowl();
                yield return new ChickenFajitaNachos();
                yield return new ClassicNachos();
                yield return new GreenChickenBowl();
                yield return new SpicySteakBowl();
            }
        }

        /// <summary>
        /// returns all the combinations of sides
        /// </summary>
        public static IEnumerable<IMenuItem> Sides 
        {
            get 
            {
                yield return new Fries() { Curly = false, Size = Size.Kids};
                yield return new Fries() { Curly = true, Size = Size.Kids };
                yield return new Fries() { Curly = false, Size = Size.Small };
                yield return new Fries() { Curly = true, Size = Size.Small };
                yield return new Fries() { Curly = false, Size = Size.Medium };
                yield return new Fries() { Curly = true, Size = Size.Medium };
                yield return new Fries() { Curly = false, Size = Size.Large };
                yield return new Fries() { Curly = true, Size = Size.Large };

                yield return new RefriedBeans() { CheddarCheese = false, Onions = false, Size = Size.Kids};
                yield return new RefriedBeans() { CheddarCheese = false, Onions = false, Size = Size.Small };
                yield return new RefriedBeans() { CheddarCheese = false, Onions = false, Size = Size.Medium };
                yield return new RefriedBeans() { CheddarCheese = false, Onions = false, Size = Size.Large };
                yield return new RefriedBeans() { CheddarCheese = false, Onions = true, Size = Size.Kids };
                yield return new RefriedBeans() { CheddarCheese = false, Onions = true, Size = Size.Small };
                yield return new RefriedBeans() { CheddarCheese = false, Onions = true, Size = Size.Medium };
                yield return new RefriedBeans() { CheddarCheese = false, Onions = true, Size = Size.Large };
                yield return new RefriedBeans() { CheddarCheese = true, Onions = false, Size = Size.Kids };
                yield return new RefriedBeans() { CheddarCheese = true, Onions = false, Size = Size.Small };
                yield return new RefriedBeans() { CheddarCheese = true, Onions = false, Size = Size.Medium };
                yield return new RefriedBeans() { CheddarCheese = true, Onions = false, Size = Size.Large };
                yield return new RefriedBeans() { CheddarCheese = true, Onions = true, Size = Size.Kids };
                yield return new RefriedBeans() { CheddarCheese = true, Onions = true, Size = Size.Small };
                yield return new RefriedBeans() { CheddarCheese = true, Onions = true, Size = Size.Medium };
                yield return new RefriedBeans() { CheddarCheese = true, Onions = true, Size = Size.Large };

                yield return new StreetCorn() { CotijaCheese = false, Cilantro = false, Size = Size.Kids};
                yield return new StreetCorn() { CotijaCheese = false, Cilantro = false, Size = Size.Small };
                yield return new StreetCorn() { CotijaCheese = false, Cilantro = false, Size = Size.Medium };
                yield return new StreetCorn() { CotijaCheese = false, Cilantro = false, Size = Size.Large };
                yield return new StreetCorn() { CotijaCheese = false, Cilantro = true, Size = Size.Kids };
                yield return new StreetCorn() { CotijaCheese = false, Cilantro = true, Size = Size.Small };
                yield return new StreetCorn() { CotijaCheese = false, Cilantro = true, Size = Size.Medium };
                yield return new StreetCorn() { CotijaCheese = false, Cilantro = true, Size = Size.Large };
                yield return new StreetCorn() { CotijaCheese = true, Cilantro = false, Size = Size.Kids };
                yield return new StreetCorn() { CotijaCheese = true, Cilantro = false, Size = Size.Small };
                yield return new StreetCorn() { CotijaCheese = true, Cilantro = false, Size = Size.Medium };
                yield return new StreetCorn() { CotijaCheese = true, Cilantro = false, Size = Size.Large };
                yield return new StreetCorn() { CotijaCheese = true, Cilantro = true, Size = Size.Kids };
                yield return new StreetCorn() { CotijaCheese = true, Cilantro = true, Size = Size.Small };
                yield return new StreetCorn() { CotijaCheese = true, Cilantro = true, Size = Size.Medium };
                yield return new StreetCorn() { CotijaCheese = true, Cilantro = true, Size = Size.Large };
            }
        }

        /// <summary>
        /// returns all types of drinks
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks 
        {
            get 
            {
                yield return new Milk() { Chocolate = false, Size = Size.Kids};
                yield return new Milk() { Chocolate = true, Size = Size.Kids };
                yield return new Milk() { Chocolate = false, Size = Size.Kids };
                yield return new Milk() { Chocolate = true, Size = Size.Kids };
                yield return new Milk() { Chocolate = false, Size = Size.Small };
                yield return new Milk() { Chocolate = true, Size = Size.Small };
                yield return new Milk() { Chocolate = false, Size = Size.Small };
                yield return new Milk() { Chocolate = true, Size = Size.Small };
                yield return new Milk() { Chocolate = false, Size = Size.Medium };
                yield return new Milk() { Chocolate = true, Size = Size.Medium };
                yield return new Milk() { Chocolate = false, Size = Size.Medium };
                yield return new Milk() { Chocolate = true, Size = Size.Medium };
                yield return new Milk() { Chocolate = false, Size = Size.Large };
                yield return new Milk() { Chocolate = true, Size = Size.Large };
                yield return new Milk() { Chocolate = false, Size = Size.Large };
                yield return new Milk() { Chocolate = true, Size = Size.Large };

                yield return new Horchata() { Size = Size.Kids };
                yield return new Horchata() { Size = Size.Small };
                yield return new Horchata() { Size = Size.Medium };
                yield return new Horchata() { Size = Size.Large };

                yield return new AguaFresca() { DrinkFlavor = Flavor.Limonada, Size = Size.Kids };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Tamarind, Size = Size.Kids };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Cucumber, Size = Size.Kids };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Lime, Size = Size.Kids };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Strawberry, Size = Size.Kids };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Limonada, Size = Size.Small };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Tamarind, Size = Size.Small };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Cucumber, Size = Size.Small };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Lime, Size = Size.Small };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Strawberry, Size = Size.Small };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Limonada, Size = Size.Medium };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Tamarind, Size = Size.Medium };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Cucumber, Size = Size.Medium };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Lime, Size = Size.Medium };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Strawberry, Size = Size.Medium };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Limonada, Size = Size.Large };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Tamarind, Size = Size.Large };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Cucumber, Size = Size.Large };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Lime, Size = Size.Large };
                yield return new AguaFresca() { DrinkFlavor = Flavor.Strawberry, Size = Size.Large };
            }
        }

        /// <summary>
        /// returns all the possible salsas
        /// </summary>
        public static IEnumerable<IMenuItem> KidsMeals 
        {
            get
            {
                yield return new ChickenNuggetsMeal() { SideChoice = new Fries(), DrinkChoice = new Milk() };
                yield return new ChickenNuggetsMeal() { SideChoice = new Fries(), DrinkChoice = new Horchata() };
                yield return new ChickenNuggetsMeal() { SideChoice = new Fries(), DrinkChoice = new AguaFresca() };
                yield return new ChickenNuggetsMeal() { SideChoice = new RefriedBeans(), DrinkChoice = new Milk() };
                yield return new ChickenNuggetsMeal() { SideChoice = new RefriedBeans(), DrinkChoice = new Horchata() };
                yield return new ChickenNuggetsMeal() { SideChoice = new RefriedBeans(), DrinkChoice = new AguaFresca() };
                yield return new ChickenNuggetsMeal() { SideChoice = new StreetCorn(), DrinkChoice = new Milk() };
                yield return new ChickenNuggetsMeal() { SideChoice = new StreetCorn(), DrinkChoice = new Horchata() };
                yield return new ChickenNuggetsMeal() { SideChoice = new StreetCorn(), DrinkChoice = new AguaFresca() };

                yield return new CornDogBitesMeal() { SideChoice = new Fries(), DrinkChoice = new Milk() };
                yield return new CornDogBitesMeal() { SideChoice = new Fries(), DrinkChoice = new Horchata() };
                yield return new CornDogBitesMeal() { SideChoice = new Fries(), DrinkChoice = new AguaFresca() };
                yield return new CornDogBitesMeal() { SideChoice = new RefriedBeans(), DrinkChoice = new Milk() };
                yield return new CornDogBitesMeal() { SideChoice = new RefriedBeans(), DrinkChoice = new Horchata() };
                yield return new CornDogBitesMeal() { SideChoice = new RefriedBeans(), DrinkChoice = new AguaFresca() };
                yield return new CornDogBitesMeal() { SideChoice = new StreetCorn(), DrinkChoice = new Milk() };
                yield return new CornDogBitesMeal() { SideChoice = new StreetCorn(), DrinkChoice = new Horchata() };
                yield return new CornDogBitesMeal() { SideChoice = new StreetCorn(), DrinkChoice = new AguaFresca() };

                yield return new SlidersMeal() { AmericanCheese = false, SideChoice = new Fries(), DrinkChoice = new Milk() };
                yield return new SlidersMeal() { AmericanCheese = false, SideChoice = new Fries(), DrinkChoice = new Horchata() };
                yield return new SlidersMeal() { AmericanCheese = false, SideChoice = new Fries(), DrinkChoice = new AguaFresca() };
                yield return new SlidersMeal() { AmericanCheese = false, SideChoice = new RefriedBeans(), DrinkChoice = new Milk() };
                yield return new SlidersMeal() { AmericanCheese = false, SideChoice = new RefriedBeans(), DrinkChoice = new Horchata() };
                yield return new SlidersMeal() { AmericanCheese = false, SideChoice = new RefriedBeans(), DrinkChoice = new AguaFresca() };
                yield return new SlidersMeal() { AmericanCheese = false, SideChoice = new StreetCorn(), DrinkChoice = new Milk() };
                yield return new SlidersMeal() { AmericanCheese = false, SideChoice = new StreetCorn(), DrinkChoice = new Horchata() };
                yield return new SlidersMeal() { AmericanCheese = false, SideChoice = new StreetCorn(), DrinkChoice = new AguaFresca() };
                yield return new SlidersMeal() { AmericanCheese = true, SideChoice = new Fries(), DrinkChoice = new Milk() };
                yield return new SlidersMeal() { AmericanCheese = true, SideChoice = new Fries(), DrinkChoice = new Horchata() };
                yield return new SlidersMeal() { AmericanCheese = true, SideChoice = new Fries(), DrinkChoice = new AguaFresca() };
                yield return new SlidersMeal() { AmericanCheese = true, SideChoice = new RefriedBeans(), DrinkChoice = new Milk() };
                yield return new SlidersMeal() { AmericanCheese = true, SideChoice = new RefriedBeans(), DrinkChoice = new Horchata() };
                yield return new SlidersMeal() { AmericanCheese = true, SideChoice = new RefriedBeans(), DrinkChoice = new AguaFresca() };
                yield return new SlidersMeal() { AmericanCheese = true, SideChoice = new StreetCorn(), DrinkChoice = new Milk() };
                yield return new SlidersMeal() { AmericanCheese = true, SideChoice = new StreetCorn(), DrinkChoice = new Horchata() };
                yield return new SlidersMeal() { AmericanCheese = true, SideChoice = new StreetCorn(), DrinkChoice = new AguaFresca() };
            }
        }

        private static List<IMenuItem> fullMenu;

        /// <summary>
        /// Returns all the items in the whole menu
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu 
        {
            get 
            {
                fullMenu.AddRange(Entrees);
                fullMenu.AddRange(Sides);
                fullMenu.AddRange(Drinks);
                fullMenu.AddRange(KidsMeals);

                return fullMenu;
            }
        }

        /// <summary>
        /// Returns all the possible ingredients
        /// </summary>
        public static IEnumerable<Ingredient> Ingredients
        {
            get
            {
                foreach (Ingredient i in Enum.GetValues(typeof(Ingredient))) yield return i;
            }
        }

        /// <summary>
        /// Returns all the possible salsas
        /// </summary>
        public static IEnumerable<Salsa> Salsas 
        {
            get 
            {
                foreach (Salsa s in Enum.GetValues(typeof(Salsa))) yield return s;
            }
        }
    }
}
