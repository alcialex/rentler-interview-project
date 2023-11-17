using Rentler.Interview.Api.Entities;
using System.Text.Json;

namespace Rentler.Interview.Api.Context
{
    public class FoodContextSeed
    {
        public static async Task SeedAsync(FoodContext context)
        {
            if (!context.Foods.Any())
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var foodData = File.ReadAllText(".\\SeedData\\foods.json");
                var foods = JsonSerializer.Deserialize<List<Food>>(foodData, options);
                context.Foods.AddRange(foods);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}