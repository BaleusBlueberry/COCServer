using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AspNetCore.Identity.Mongo;
using COCServer.Startup.JWT;
using COCServer.Startup.SeedData;
using COCServer.Startup.Seeder;
using DLA.Interface;
using DLA.Models;
using DLA.Models.BuildingModels.DefensiveBuildingsModels;
using DLA.Models.BuildingModels.OtherBuildingsModels;
using DLA.Models.BuildingModels.ResourceBuildingsModels;
using DLA.Models.BuildingModels.TrapBuildingsModels;
using DLA.Models.TownHallModels;
using DLA.Repository;
using DLA.Repository.BuildingsRepositories;
using DLA.Repository.TownHallRepository;
using DLA.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
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
            builder.Services.AddSingleton<IRepository<OtherBuildingsModel>, OtherBuildingsRepository>();
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

            }, mongoOptions =>
            {
                mongoOptions.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            });

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

            builder.Services.AddScoped<JwtService>();

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
                    options.AddPolicy(name: corsPolicy, policy =>
                    {
                        var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ??
                                             new string[] { "http://localhost:3000", "http://localhost:5173" }; // Default to local origins
                        policy.WithOrigins(allowedOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
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
            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            if (builder.Environment.IsDevelopment())
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                    
                });
                app.UseSwagger();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
