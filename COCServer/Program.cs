using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AspNetCore.Identity.Mongo;
using COCServer.Startup.JWT;
using COCServer.Startup.SeedData;
using COCServer.Startup.Seeder;
using DLA.Interface;
using DLA.Models;
using DLA.Models.BuildingModels.ArmyBuildingsModels;
using DLA.Models.BuildingModels.DefensiveBuildingsModels;
using DLA.Models.BuildingModels.ResourceBuildingsModels;
using DLA.Models.BuildingModels.TrapBuildingsModels;
using DLA.Models.TownHallModels;
using DLA.Repository;
using DLA.Repository.BuildingsRepositories;
using DLA.Repository.TownHallRepository;
using DLA.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;

namespace COCServer
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<IMongoService, MongoService>();

            builder.Services.AddSingleton<IRepository<TownHallLevels>, TownHallRepositoryMongo>();

            builder.Services.AddSingleton<IRepository<TrapBuildingsModel>, TrapBuildingsRepository>();
            builder.Services.AddSingleton<IRepository<ResourceBuildingsModel>, ResourceBuildingsRepository>();
            builder.Services.AddSingleton<IRepository<ArmyBuildingsModel>, ArmyBuildingsRepository>();
            builder.Services.AddSingleton<IRepository<DefensiveBuildingsModel>, DefensiveBuildingsRepository>();

            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    // Add support for case-insensitive enum mapping
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

            builder.Services.AddIdentityMongoDbProvider<AppUser, AppRole>(identityOptions =>
            {
                identityOptions.Password.RequiredLength = 8;
                identityOptions.User.RequireUniqueEmail = true;
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequireNonAlphanumeric = true; // Requires at least one special character
                identityOptions.Password.RequireUppercase = true;
                identityOptions.Password.RequireLowercase = true;
            }, mongoOptions => mongoOptions.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection"));

            var jwtSettings = builder.Configuration.GetSection("JwtSettings");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? throw new InvalidOperationException("jwt string jwtSettings[\"SecretKey\"] not found."))),
                    ValidateLifetime = true
                };
                options.IncludeErrorDetails = true;
            });

            builder.Services.AddScoped<Seeder>();

            builder.Services.AddScoped<TownHallSeeder>();

            builder.Services.AddScoped<DefensiveBuildingsSeeder>();

            builder.Services.AddScoped<ArmyBuildingsSeeder>();

            builder.Services.AddScoped<ResourceBuildingsSeeder>();

            builder.Services.AddScoped<TrapBuildingsSeeder>();

            builder.Services.AddScoped<JwtService>();

            builder.Services.AddScoped<BuildingService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var corsPolicy = "CorsPolicy";

            /*var host = builder.Configuration.GetValue<string>("AllowedHosts") ?? throw new Exception("no valid string at AllowedHosts");*/

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicy, policy =>
                {
                    var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
                    policy.WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials(); // Ensure AllowCredentials is included if you're using cookies or credentials in requests
                });
            });

            builder.Logging.ClearProviders();
            builder.Logging.AddDebug();
            builder.Logging.AddConsole(); // Add console logging

            builder.Logging.SetMinimumLevel(builder.Environment.IsDevelopment()
                ? LogLevel.Debug
                : LogLevel.Information);

            var app = builder.Build();

            app.UseCors(corsPolicy);

            await DataSeeder.SeedDataAsync(app);

            if (builder.Environment.IsDevelopment())
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
                app.UseSwagger();
            }
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "An unexpected error occurred. Please try again later."
                        }.ToString());
                    }
                });
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
