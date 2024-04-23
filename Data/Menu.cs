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
                foreach (Size size in Enum.GetValues(typeof(Size))) 
                {
                    yield return new Fries() { Curly = false, Size = size };
                    yield return new Fries() { Curly = true, Size = size };

                    yield return new RefriedBeans() { CheddarCheese = false, Onions = false, Size = size };
                    yield return new RefriedBeans() { CheddarCheese = true, Onions = false, Size = size };
                    yield return new RefriedBeans() { CheddarCheese = false, Onions = true, Size = size };
                    yield return new RefriedBeans() { CheddarCheese = true, Onions = true, Size = size };

                    yield return new StreetCorn() { CotijaCheese = false, Cilantro = false, Size = size };
                    yield return new StreetCorn() { CotijaCheese = true, Cilantro = false, Size = size };
                    yield return new StreetCorn() { CotijaCheese = false, Cilantro = true, Size = size };
                    yield return new StreetCorn() { CotijaCheese = true, Cilantro = true, Size = size };
                }
            }
        }

        /// <summary>
        /// returns all types of drinks
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks 
        {
            get 
            {
                foreach (Size size in Enum.GetValues(typeof(Size))) 
                {
                    yield return new Milk() { Chocolate = false, Size = size };
                    yield return new Milk() { Chocolate = true, Size = size };

                    yield return new Horchata() { Size = size };

                    foreach (Flavor flavor in Enum.GetValues(typeof(Flavor)))
                    {
                        yield return new AguaFresca() { DrinkFlavor = flavor, Size = size };
                    }
                }
            }
        }

        /// <summary>
        /// returns all the possible salsas
        /// </summary>
        public static IEnumerable<IMenuItem> KidsMeals 
        {
            get
            {
                List<Side> sides = new List<Side> { new Fries(), new RefriedBeans(), new StreetCorn() };
                List<Drink> drinks = new List<Drink> { new Milk(), new Horchata(), new AguaFresca() };

                foreach (Side side in sides) 
                {
                    foreach (Drink drink in drinks)
                    {
                        yield return new ChickenNuggetsMeal() { SideChoice = side, DrinkChoice = drink };

                        yield return new CornDogBitesMeal() { SideChoice = side, DrinkChoice = drink };

                        yield return new SlidersMeal() { AmericanCheese = false, SideChoice = side, DrinkChoice = drink };
                        yield return new SlidersMeal() { AmericanCheese = true, SideChoice = side, DrinkChoice = drink };
                    }
                }
            }
        }

        private static List<IMenuItem> fullMenu = new List<IMenuItem>();

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

        /// <summary>
        /// Filters the menu items to only show those within a given price range
        /// </summary>
        /// <param name="menuItems">the menu items to filter</param>
        /// <param name="min">minimum price of filter</param>
        /// <param name="max">maximum price of filter</param>
        /// <returns>The IEnumerable of filtered items</returns>
        public static IEnumerable<IMenuItem> FilterByPrice(IEnumerable<IMenuItem> menuItems, decimal? min, decimal? max) 
        {
            if (min == 0 && max == 0) return menuItems;

            return menuItems.Where(item => (min == null || item.Price >= min) &&
                (max == null || item.Price <= max)).OrderBy(item => item.Price);
        }

        /// <summary>
        /// Filters the menu items to only show those within a given calorie range
        /// </summary>
        /// <param name="menuItems">the menu items to filter</param>
        /// <param name="min">minimum calories of filter</param>
        /// <param name="max">maximum calories of filter</param>
        /// <returns>The IEnumerable of filtered items</returns>
        public static IEnumerable<IMenuItem> FilterByCalories(IEnumerable<IMenuItem> menuItems, decimal? min, decimal? max)
        {
            if (min == 0 && max == 0) return menuItems;

            return menuItems.Where(item => (min == null || item.Calories >= min) &&
                (max == null || item.Calories <= max)).OrderBy(item => item.Calories);
        }

        /// <summary>
        /// Filters the menu items to only show those with the given terms
        /// </summary>
        /// <param name="terms">the terms to filter by</param>
        /// <returns>the IEnumerable of filtered items</returns>
        public static IEnumerable<IMenuItem> Search(string terms) 
        {
            if (terms == null) return FullMenu;

            string[] splitTerms = terms.Split(' ');
            return FullMenu;
        }
    }
}
