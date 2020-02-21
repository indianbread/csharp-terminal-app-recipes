using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace TerminalApp_Recipes
{
    public class DisplayRecipes
    {
        public static void GetRecipesList(string url)
        {
            string recipesListJSON = HttpRequest.MakeApiRequest(url);
            if (recipesListJSON == null || recipesListJSON.Contains("hits") == false)
            {
                Console.WriteLine("Sorry! No recipes match your search criteria");

            } else
            {
                RootObject recipesListObject = JsonConvert.DeserializeObject<RootObject>(recipesListJSON);

                List<Hit> recipesList = recipesListObject.hits;

                Console.Clear();
                Console.WriteLine("Hoorah! Here are the list of recipes. Type the number to view the full recipe details\n\n");
                for (int i = 0; i < recipesList.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + recipesList[i].recipe.label);
                }

                int recipeToView = Int32.Parse(Console.ReadLine()) - 1;

                Recipe targetRecipe = recipesList[recipeToView].recipe;

                Console.Clear();


                Console.WriteLine($"Viewing recipe details for {targetRecipe.label}\n");
                Console.WriteLine($"Serves: {targetRecipe.yield}\nTotal Time: {targetRecipe.totalTime} minutes\nCalories:{targetRecipe.calories} kJ\n");

                List<string> dietTypes = targetRecipe.dietLabels;

                Console.WriteLine("Diet Types:");
                foreach (string type in dietTypes)
                {
                    Console.WriteLine(type);
                }

                Console.WriteLine("\n");

                Console.WriteLine("Cautions:");
                List<string> cautions = targetRecipe.cautions;

                foreach (string caution in cautions)
                {
                    Console.WriteLine(caution);

                }

                Console.WriteLine("\n");

                Console.WriteLine("Health labels:");

                List<string> healthLabels = targetRecipe.healthLabels;

                foreach (string label in healthLabels)
                {
                    Console.WriteLine(label);
                }

                Console.WriteLine("\n");
                Console.WriteLine("Ingredients:");
                List<string> ingredients = targetRecipe.ingredientLines;
                foreach (string ingredient in ingredients)
                {
                    Console.WriteLine(ingredient);
                }

                Console.WriteLine("\n");

                Console.WriteLine($"For instructions, visit this website: {targetRecipe.url}\n");
            }
            //System.Environment.Exit(1);
 
        }

    }
}
