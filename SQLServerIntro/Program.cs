
using SQLServerIntro;

using System.Text.Json;

var factory = new CookbookContextFactory();
using var context = factory.CreateDbContext();

//bool dbExists = context.Database.EnsureCreated();


// Create, Read
var porridge = context.Dishes.FirstOrDefault(d => d.Title == "Breakfast Porridge");
if (porridge is null)
{
    Console.WriteLine("Breakfast porridge missing. Adding it...");
    porridge = new Dish { Title = "Breakfast Porridge", Notes = "This is sooo good", Stars = 4 };
    context.Dishes.Add(porridge);
    context.SaveChanges();

    Console.WriteLine($"\tAdded ({JsonSerializer.Serialize(porridge)})");
}

// Update
if (porridge.Stars == 4)
{
    Console.WriteLine("Adding a star to porridge");
    porridge.Stars = 5;
    context.SaveChanges();
}

if (context.Ingredients.Any(i => i.Dish == porridge) == false)
{
    Console.WriteLine("Adding ingredients");

    context.Add(new DishIngredient()
    {
        Dish = porridge,
        Description = "Havregryn",
        Amount = 5m,
        UnitOfMeasure = "dl"
    });

    var ingredients = new DishIngredient[]
    {
                    new() {Dish=porridge, Description="Vatten", Amount=5m, UnitOfMeasure="dl"},
                    new() {Dish=porridge, Description="Blandade nötter", Amount=1m, UnitOfMeasure="dl"},
                    new() {Dish=porridge, Description="Russin", Amount=3m, UnitOfMeasure="msk"}
    };
    context.AddRange(ingredients);
    context.SaveChanges();
}

// Delete
Console.WriteLine("Removing porridge and all its ingredients");
foreach (var ingredient in context.Ingredients.Where(i => i.DishId == porridge.Id).ToArray())
{
    context.Remove(ingredient);
}

context.Remove(porridge);
context.SaveChanges();


Console.Write("Press any key to continue . . . ");
Console.ReadKey();