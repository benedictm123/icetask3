using System;

namespace RecipeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            // User interaction loop
            bool continueExecution = true;
            while (continueExecution)
            {
                //Displaying menue to choose suitable option

                Console.WriteLine();
                Console.WriteLine("******************Welcome to the recipe system***********************");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display full recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                string userInput = Console.ReadLine();

                try
                {

                    switch (userInput)
                    {
                        case "1":
                            recipe.EnterRecipeDetails();
                            break;
                        case "2":
                            recipe.DisplayFullRecipe();
                            break;
                        case "3":
                            recipe.ScaleRecipe();
                            break;
                        case "4":
                            recipe.ResetQuantities();
                            break;
                        case "5":
                            recipe.ClearData();
                            break;
                        case "6":
                            continueExecution = false;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please select a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }

    class Recipe
    {
        // Automatic properties
        public int NumberOfIngredients { get; set; }
        public Ingredient[] Ingredients { get; set; } //Array to store ingredients
        public int NumberOfSteps { get; set; } //Array to store steps
        public string[] Steps { get; set; }

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.Write("Enter number of ingredients: ");
            NumberOfIngredients = int.Parse(Console.ReadLine());

            Ingredients = new Ingredient[NumberOfIngredients];
            for (int i = 0; i < NumberOfIngredients; i++)
            {
                Console.Write($"Enter name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                Ingredients[i] = new Ingredient(name, quantity, unit);
            }

            Console.Write("Enter number of steps: ");
            NumberOfSteps = int.Parse(Console.ReadLine());

            Steps = new string[NumberOfSteps];
            for (int i = 0; i < NumberOfSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                Steps[i] = Console.ReadLine();
            }
        }

        // Method to display full recipe
        public void DisplayFullRecipe()
        {
            Console.WriteLine();
            Console.WriteLine("***************Full Recipe***************");
            Console.WriteLine();
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine();
            Console.WriteLine("Steps:");
            for (int i = 0; i < NumberOfSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        // Method to scale recipe
        public void ScaleRecipe()
        {
            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
            double factor = double.Parse(Console.ReadLine());

            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to reset quantities
        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        // Method to clear all data
        public void ClearData()
        {
            NumberOfIngredients = 0;
            Ingredients = null;
            NumberOfSteps = 0;
            Steps = null;
        }
    }

    class Ingredient
    {
        // Automatic properties
        public string Name { get; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string Unit { get; } // Unit of measurement for the ingredient


        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        // Method to reset quantity
        public void ResetQuantity()
        {
            // Resetting quantity to default value
            Quantity = 1;
        }
    }
}
