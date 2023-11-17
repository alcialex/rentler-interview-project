
using Microsoft.EntityFrameworkCore;
using Rentler.Interview.Api.Entities;

namespace Rentler.Interview.Api.Context
{
    public class FoodContext : DbContext
    {

        public FoodContext()
        { }
        public FoodContext(DbContextOptions<FoodContext> options)
            : base(options)
        { }
        public DbSet<Food> Foods { get; set; }

    }
}
