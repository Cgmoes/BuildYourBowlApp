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
        }

        public void OnGet()
        {
            Entrees = Menu.FilterByPrice(Entrees, PriceMin, PriceMax);
            Sides = Menu.FilterByPrice(Sides, PriceMin, PriceMax);
            Drinks = Menu.FilterByPrice(Drinks, PriceMin, PriceMax);
            KidsMeals = Menu.FilterByPrice(KidsMeals, PriceMin, PriceMax);

            Entrees = Menu.FilterByCalories(Entrees, CaloriesMin, CaloriesMax);
            Sides = Menu.FilterByCalories(Sides, CaloriesMin, CaloriesMax);
            Drinks = Menu.FilterByCalories(Drinks, CaloriesMin, CaloriesMax);
            KidsMeals = Menu.FilterByCalories(KidsMeals, CaloriesMin, CaloriesMax);
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

        public IEnumerable<IMenuItem> Entrees { get; private set; }
        public IEnumerable<IMenuItem> Sides { get; private set; }
        public IEnumerable<IMenuItem> Drinks { get; private set; }
        public IEnumerable<IMenuItem> KidsMeals { get; private set; }
        public IEnumerable<Ingredient> Ingredients { get; private set; }
        public IEnumerable<Salsa> Salsas { get; private set; }
    }
}
