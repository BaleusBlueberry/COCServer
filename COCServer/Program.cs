using DLA.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace COCServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ContextDLA>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ContextDLA") ?? throw new InvalidOperationException("Connection string 'ContextDLA' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddDbContext<DALContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DALContext") ?? throw new InvalidOperationException("Connection string 'DALContext' not found.")));
            
            //builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options => {
            //    options.User.RequireUniqueEmail = true;
            //    options.Password.RequiredLength = 8;
            //}).AddEntityFrameworkStores<DALContext>();

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
                };
            });

            //builder.Services.AddScoped<JwtService>();

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

            var app = builder.Build();

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
            app.UseAuthorization();

            app.MapControllers();

            //app.MapStaticAssets();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}")
            //    .WithStaticAssets();

            app.Run();
        }
    }
}
