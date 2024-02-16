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
        /// Sets the default and included values for ingredients
        /// </summary>
        public void SetDefaultsAndIncluded() 
        {
            IngredientItem chicken = new(Ingredient.Chicken);
            chicken.Default = true;
            chicken.Included = true;

            IngredientItem blackBeans = new(Ingredient.BlackBeans);
            blackBeans.Default = true;
            blackBeans.Included = true;

            IngredientItem veggies = new(Ingredient.Veggies);
            veggies.Default = true;
            veggies.Included = true;

            IngredientItem queso = new(Ingredient.Queso);
            queso.Default = true;
            queso.Included = true;

            IngredientItem guac = new(Ingredient.Guacamole);
            guac.Default = true;
            guac.Included = true;

            IngredientItem sourCream = new(Ingredient.SourCream);
            sourCream.Default = true;
            sourCream.Included = true;
        }

        /// <summary>
        /// Default constructor for green chicken bowl
        /// </summary>
        public GreenChickenBowl() 
        {
            //Clear toppings selection
            PossibleToppings.Clear();

            //Add back possible toppings
            PossibleToppings.Add(new IngredientItem(Ingredient.Chicken));
            PossibleToppings.Add(new IngredientItem(Ingredient.BlackBeans));
            PossibleToppings.Add(new IngredientItem(Ingredient.Veggies));
            PossibleToppings.Add(new IngredientItem(Ingredient.Queso));
            PossibleToppings.Add(new IngredientItem(Ingredient.Guacamole));
            PossibleToppings.Add(new IngredientItem(Ingredient.SourCream));

            //Pick Salsa Choice
            SalsaType = Salsa.Green;
            DefaultSalsa = Salsa.Green;
        }
    }
}