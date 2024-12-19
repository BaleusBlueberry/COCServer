using DLA.Interface;
using DLA.Repository;
using DLA.Servises;
using DLA.Models.TownHallModels;

namespace DLA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddDbContext<ContextDLA>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("ContextDLA") ?? throw new InvalidOperationException("Connection string 'ContextDLA' not found.")));

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
