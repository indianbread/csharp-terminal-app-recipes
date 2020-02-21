using System;
using System.Collections.Generic;

namespace TerminalApp_Recipes
{
    public class RootObject
    {
        public string q;
        public int from;
        public int to;
        public bool more;
        public int count;
        public List<Hit> hits;
    }

    public class Hit
    {
        public Recipe recipe;
        public bool bookmarked;
        public bool bought;

    }

    public class Recipe
    {
        public string uri;
        public string label;
        public string image;
        public string source;
        public string url;
        public string shareAs;
        public float yield;
        public List<string> dietLabels;
        public List<string> healthLabels;
        public List<string> cautions;
        public List<string> ingredientLines;
        public List<Ingredient> ingredients;
        public float calories;
        public float totalWeight;
        public float totalTime;

    }

    public class Ingredient
    {
        public string text;
        public float weight;

    }

}
