using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// Testing class for IngredientItem
    /// </summary>
    public class IngredientItemUnitTests
    {
        /// <summary>
        /// Tests the default values of the ingredient
        /// </summary>
        /// <param name="ingredient">the ingredient to test</param>
        /// <param name="expectedName">expected name of the ingredient</param>
        /// <param name="expectedCalories">expected calories of the ingredient</param>
        /// <param name="expectedUnitCost">expected unit cost of the ingredient</param>
        [Theory]
        [InlineData(Ingredient.BlackBeans, "Black Beans", 130, 1.00)]
        [InlineData(Ingredient.PintoBeans, "Pinto Beans", 130, 1.00)]
        [InlineData(Ingredient.Queso, "Queso", 110, 1.00)]
        [InlineData(Ingredient.Veggies, "Veggies", 20, 0.00)]
        [InlineData(Ingredient.SourCream, "Sour Cream", 100, 0.00)]
        [InlineData(Ingredient.Guacamole, "Guacamole", 150, 1.00)]
        [InlineData(Ingredient.Chicken, "Chicken", 150, 2.00)]
        [InlineData(Ingredient.Steak, "Steak", 180, 2.00)]
        [InlineData(Ingredient.Carnitas, "Carnitas", 210, 2.00)]
        [InlineData(Ingredient.Rice, "Rice", 210, 0.00)]
        [InlineData(Ingredient.Chips, "Chips",250, 0.00)]
        public void DefaultValuesAreCorrectTest(Ingredient ingredient, string expectedName, uint expectedCalories, decimal expectedUnitCost)
        {
            IngredientItem item = new IngredientItem(ingredient);

            Assert.Equal(expectedName, item.Name);
            Assert.Equal(expectedCalories, item.Calories);
            Assert.Equal(expectedUnitCost, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests if the INotifyPropertyChanged is implemented
        /// </summary>
        /// <param name="ingredient">the ingredient to test</param>
        /// <param name="included">if the ingredient is included</param>
        [Theory]
        [InlineData(Ingredient.Veggies, true)]
        [InlineData(Ingredient.SourCream, false)]
        [InlineData(Ingredient.Guacamole, true)]
        [InlineData(Ingredient.Chicken, false)]
        [InlineData(Ingredient.Steak, true)]
        [InlineData(Ingredient.Carnitas, false)]
        [InlineData(Ingredient.Rice, true)]
        [InlineData(Ingredient.Chips, false)]
        public void IncludedNotifiesOfPropertChangedTest(Ingredient ingredient, bool included) 
        {
            IngredientItem item = new IngredientItem(ingredient);
            Assert.PropertyChanged(item, "Included", () => {
                item.Included = included;
            });
        }
    }
}
