using COCServer.Startup.SeedData;

namespace COCServer.Startup.Seeder;

public static class DataSeeder
{
    public static async Task SeedDataAsync(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var townHallSeederr = scope.ServiceProvider.GetRequiredService<TownHallSeeder>();
                await townHallSeederr.SeedDataAsync("TownHallLevelSeed.json");

                var authSeeder = services.GetRequiredService<SeedData.Seeder>();

                await authSeeder.SeedRolesAndUsersAsync();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<SeedData.Seeder>>(); // Use a real type here
                logger.LogError(ex, "An error occurred while seeding roles and users.");
            }
        }
    }
}