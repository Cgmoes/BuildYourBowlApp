namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the GreenChickenBowl class
    /// </summary>
    public class GreenChickenBowl : Bowl, IMenuItem
    {
        /// <summary>
        /// The name of the green chicken bowl instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Green Chicken Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Rice bowl with chicken and green things";

        /// <summary>
        /// The price of this bowl
        /// </summary>
        public override decimal Price => 9.99m;


        /// <summary>
        /// Default constructor for green chicken bowl
        /// </summary>
        public GreenChickenBowl() 
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(Ingredient.Chicken, new IngredientItem(Ingredient.Chicken) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.Veggies, new IngredientItem(Ingredient.Veggies) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.Queso, new IngredientItem(Ingredient.Queso) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole) { Default = true, Included = true });
            PossibleToppings.Add(Ingredient.SourCream, new IngredientItem(Ingredient.SourCream) { Default = true, Included = true });

            //Pick Salsa Choice
            SalsaType = Salsa.Green;
            DefaultSalsa = Salsa.Green;

            foreach (IngredientItem ingredient in PossibleToppings.Values)
            {
                ingredient.PropertyChanged += OnToppingsChanged;
            }
        }
    }
}