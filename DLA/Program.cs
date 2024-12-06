using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DLA.Data;

namespace DLA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ContextDLA>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ContextDLA") ?? throw new InvalidOperationException("Connection string 'ContextDLA' not found.")));
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
