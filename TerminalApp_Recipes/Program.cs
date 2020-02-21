using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TerminalApp_Recipes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Recipes Galore!\nDisclaimer: This app links to external websites for the methods");
            string continueSearch;
            do
            {
                string url = RecipesSearch.GetSearchParams();
                Console.WriteLine(url);
                DisplayRecipes.GetRecipesList(url);
                Console.WriteLine("Would you like to search again? y/n");
                continueSearch = Console.ReadLine().ToLower();

            } while (continueSearch == "y");



        }
    }
}
