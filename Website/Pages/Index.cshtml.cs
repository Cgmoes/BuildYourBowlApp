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
            
        }

        public IEnumerable<IMenuItem> Entrees { get; private set; }
        public IEnumerable<IMenuItem> Sides { get; private set; }
        public IEnumerable<IMenuItem> Drinks { get; private set; }
        public IEnumerable<IMenuItem> KidsMeals { get; private set; }
        public IEnumerable<Ingredient> Ingredients { get; private set; }
        public IEnumerable<Salsa> Salsas { get; private set; }
    }
}
