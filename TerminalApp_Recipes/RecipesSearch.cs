using System;
using System.Linq;
using System.Collections.Generic;


namespace TerminalApp_Recipes
{
    public class RecipesSearch
    {

      public static string GetSearchParams()
        {
            Console.WriteLine("\nEnter one or more keywords to search for a recipe");
            string keywords = Console.ReadLine().ToLower();
            while (String.IsNullOrWhiteSpace(keywords))
            {
                Console.WriteLine("You must enter at least one keyword");
                keywords = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"You are searching for {keywords}.");
            Console.WriteLine("Would you like to include additional search filters? Y/N");
            string addParams = Console.ReadLine().ToLower();
            if (addParams == "n")
            {
                return HttpRequest.GenerateUrl(keywords, null, null, null);
            } else
            {
                Console.WriteLine("Specify the maximum number of results. Press enter to skip this filter.");
                int? to = GetMaxNums();

                Console.WriteLine("Specify the maximum number of ingredients.");
                int? ingr = GetMaxNums();

                Console.WriteLine("Select the type of diet from the list or press enter to skip:");
                List<string> dietType = new List<string> { "balanced", "high fiber", "high protein", "low carb", "low fat", "low sodium" };

                for (int i = 0; i < dietType.Count; i++)
                {
                    Console.WriteLine(i+1 + ". " + dietType[i]);
                }
                
                string? diet = Console.ReadLine();
                switch (diet)
                {

                    case "1":
                        diet = "balanced";
                        break;
                    case "2":
                        diet = "high fiber";
                        break;
                    case "3":
                        diet = "high protein";
                        break;
                    case "4":
                        diet = "low carb";
                        break;
                    case "5":
                        diet = "low fat";
                        break;
                    case "6":
                        diet = "low sodium";
                        break;
                    default:
                        diet = null;
                        break;
                }
                Console.WriteLine($"You are searching for the following: \nKeywords:{keywords}\nmax results:{to}\nMax number of ingredients:{ingr}\nDiet type:{diet}");
                return HttpRequest.GenerateUrl(keywords, to, ingr, diet);
            }

        }

        public static int? GetMaxNums()
        {
            string numAsString = Console.ReadLine();
            bool numInt = Int32.TryParse(numAsString, out int intNum);
            while (numInt == false && numAsString != "")
            {
                Console.WriteLine("You must enter a number or press enter to skip");
                numAsString = Console.ReadLine();
            }
            int? num;
            if (numAsString == "")
            {
                num = null;
            }
            else
            {
                num = intNum;
            }
            return num;
        }

    }
}
