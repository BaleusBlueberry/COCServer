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
                var seeder = services.GetRequiredService<Seeder>();
                await seeder.SeedRolesAndUsersAsync();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Seeder>>(); // Use a real type here
                logger.LogError(ex, "An error occurred while seeding roles and users.");
            }
        }
    }
}