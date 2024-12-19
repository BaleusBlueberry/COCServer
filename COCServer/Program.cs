using System.Text;
using AspNetCore.Identity.Mongo;
using COCServer.Startup.JWT;
using COCServer.Startup.Seeder;
using DLA.Interface;
using DLA.Models;
using DLA.Repository;
using DLA.Servises;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentityMongoDbProvider<AppUser, AppRole>(identityOptions =>
            {
                identityOptions.Password.RequiredLength = 8;
                identityOptions.User.RequireUniqueEmail = true;
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequireNonAlphanumeric = true;  // Requires at least one special character
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? throw new InvalidOperationException("jwt string jwtSettings[\"SecretKey\"] not found.")))
                };
            });

            builder.Services.AddScoped<JwtService>();

            builder.Services.AddScoped<Seeder>();

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
                    policy.WithOrigins([
                            "http://localhost:3000",
                            "http://localhost:5173",
                            "http://localhost:5174",
                            "https://testwebsite.pleasecuddle.me",
                            /*host*/
                        ])
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole(); // Add console logging
            builder.Logging.AddDebug();

            var app = builder.Build();

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
                app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
