﻿namespace SQLServerIntro
{
    public class Dish
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public int? Stars { get; set; }

        public List<DishIngredient> Ingredients { get; set; } = new();
    }
}
