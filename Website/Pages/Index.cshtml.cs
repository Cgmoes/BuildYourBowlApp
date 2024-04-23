using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BuildYourBowl.Data;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Entrees = Menu.Entrees;
            Sides = Menu.Sides;
            Drinks = Menu.Drinks;
            KidsMeals = Menu.KidsMeals;
            Ingredients = Menu.Ingredients;
            Salsas = Menu.Salsas;
            FullMenu = Menu.FullMenu;
        }

        public void OnGet()
        {
            FullMenu = Menu.FilterByPrice(FullMenu, PriceMin, PriceMax);
            FullMenu = Menu.FilterByCalories(FullMenu, CaloriesMin, CaloriesMax);

            Entrees = FullMenu.Where(item => item is Entree);
            Sides = FullMenu.Where(item => item is Side);
            Drinks = FullMenu.Where(item => item is Drink);
            KidsMeals = FullMenu.Where(item => item is KidsMeal);
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal PriceMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal PriceMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public uint CaloriesMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public uint CaloriesMax { get; set; }

        public IEnumerable<IMenuItem> FullMenu { get; private set; }
        public IEnumerable<IMenuItem> Entrees { get; private set; }
        public IEnumerable<IMenuItem> Sides { get; private set; }
        public IEnumerable<IMenuItem> Drinks { get; private set; }
        public IEnumerable<IMenuItem> KidsMeals { get; private set; }
        public IEnumerable<Ingredient> Ingredients { get; private set; }
        public IEnumerable<Salsa> Salsas { get; private set; }
    }
}
