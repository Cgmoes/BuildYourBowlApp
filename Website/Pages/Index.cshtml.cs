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

        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal PriceMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal PriceMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CaloriesMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CaloriesMax { get; set; }

        public IEnumerable<IMenuItem> FullMenu => Menu.FullMenu;
        public IEnumerable<IMenuItem> FilteredMenu { get; set; } = Menu.FullMenu;
        public IEnumerable<IMenuItem> Entrees => Menu.Entrees;
        public IEnumerable<IMenuItem> Sides => Menu.Sides;
        public IEnumerable<IMenuItem> Drinks => Menu.Drinks;
        public IEnumerable<IMenuItem> KidsMeals => Menu.KidsMeals;
        public IEnumerable<Ingredient> Ingredients => Menu.Ingredients;
        public IEnumerable<Salsa> Salsas => Menu.Salsas;


        public IEnumerable<IMenuItem> entreesList => FilteredMenu.OfType<Entree>();
        public IEnumerable<IMenuItem> sidesList => FilteredMenu.OfType<Side>();
        public IEnumerable<IMenuItem> drinksList => FilteredMenu.OfType<Drink>();
        public IEnumerable<IMenuItem> kidsMealsList => FilteredMenu.OfType<KidsMeal>();
    }
}