using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BuildYourBowl.Data;
using System.Security.Cryptography;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            FilteredMenu = Menu.Search(FullMenu, SearchTerms);
            FilteredMenu = Menu.FilterByPrice(FilteredMenu, PriceMin, PriceMax);
            FilteredMenu = Menu.FilterByCalories(FilteredMenu, CaloriesMin, CaloriesMax);
        }

        /// <summary>
        /// Gets the term the user wants to search by
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        /// <summary>
        /// Gets the minimum price filter
        /// </summary>

        [BindProperty(SupportsGet = true)]
        public decimal PriceMin { get; set; }

        /// <summary>
        /// Gets the maximum price filter
        /// </summary>

        [BindProperty(SupportsGet = true)]
        public decimal PriceMax { get; set; }

        /// <summary>
        /// Gets the minimum calories filter
        /// </summary>

        [BindProperty(SupportsGet = true)]
        public int CaloriesMin { get; set; }

        /// <summary>
        /// Gets the maximum calories filter
        /// </summary>

        [BindProperty(SupportsGet = true)]
        public int CaloriesMax { get; set; }

        /// <summary>
        /// Gets the full menu from the Menu class
        /// </summary>
        public IEnumerable<IMenuItem> FullMenu => Menu.FullMenu;

        /// <summary>
        /// The filtered menu
        /// </summary>
        public IEnumerable<IMenuItem> FilteredMenu { get; set; } = Menu.FullMenu;

        /// <summary>
        /// Gets the entrees menu from the Menu class
        /// </summary>
        public IEnumerable<IMenuItem> Entrees => Menu.Entrees;

        /// <summary>
        /// Gets the sides menu from the Menu class
        /// </summary>
        public IEnumerable<IMenuItem> Sides => Menu.Sides;

        /// <summary>
        /// Gets the drinks menu from the Menu class
        /// </summary>
        public IEnumerable<IMenuItem> Drinks => Menu.Drinks;

        /// <summary>
        /// Gets the kids meal menu from the Menu class
        /// </summary>
        public IEnumerable<IMenuItem> KidsMeals => Menu.KidsMeals;

        /// <summary>
        /// Gets the ingredients from the Menu class
        /// </summary>
        public IEnumerable<Ingredient> Ingredients => Menu.Ingredients;

        /// <summary>
        /// Gets the salsa from the Menu class
        /// </summary>
        public IEnumerable<Salsa> Salsas => Menu.Salsas;

        /// <summary>
        /// Converts the filtered menu to only show entrees
        /// </summary>
        public IEnumerable<IMenuItem> entreesList => FilteredMenu.OfType<Entree>();

        /// <summary>
        /// Converts the filtered menu to only show sides
        /// </summary>
        public IEnumerable<IMenuItem> sidesList => FilteredMenu.OfType<Side>();

        /// <summary>
        /// Converts the filtered menu to only show drinks
        /// </summary>
        public IEnumerable<IMenuItem> drinksList => FilteredMenu.OfType<Drink>();

        /// <summary>
        /// Converts the filtered menu to only show kids meals
        /// </summary>
        public IEnumerable<IMenuItem> kidsMealsList => FilteredMenu.OfType<KidsMeal>();
    }
}