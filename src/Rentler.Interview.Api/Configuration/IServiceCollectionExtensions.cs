using Microsoft.EntityFrameworkCore;
using Rentler.Interview.Api.Context;

namespace Rentler.Interview.Api.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            var appSettingsSection = config.GetSection("AppSettings");
            var connectionStringsSection = config.GetSection("ConnectionStrings");

            //var connString = connectionStringsSection.GetValue<string>("FoodContext");
            //services.AddDbContext<FoodContext>(options => options.UseSqlServer(connString));

            var connString = connectionStringsSection.GetValue<string>("SqliteConnection");            
            
            services.AddDbContext<FoodContext>(opt =>
            {
                opt.UseSqlite(connString);
            });

            services.Configure<AppSettings>(appSettingsSection);
            services.Configure<ConnectionStrings>(connectionStringsSection);
        }
    }
}
