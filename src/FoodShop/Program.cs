
using FoodShop.Entities;
using FoodShop.Services;
using FoodShop.Services.Interfaces;

namespace FoodShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<FoodShopDbContext>();
            builder.Services.AddTransient<ICategoryCommandService, CategoryCommandService>();
            builder.Services.AddTransient<ICategoryQueryService, CategoryQueryService>();
            builder.Services.AddTransient<IProductCommandService, ProductCommandService>();
            builder.Services.AddTransient<IProductQueryService, ProductQueryService>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
    }
}