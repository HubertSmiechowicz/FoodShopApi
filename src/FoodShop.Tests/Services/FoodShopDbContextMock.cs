using FoodShop.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Tests.Services
{
    public class FoodShopDbContextMock
    {
        public Mock<FoodShopDbContext> DbContextMock { get; set; }

        private IQueryable<Category> GetCategoriesTestData()
        {
            var categories = new List<Category>();
            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new Category()
                {
                    Id = i,
                    Name = "Category " + i,
                    Products = new List<Product>() { }
                });
            }
            return categories.AsQueryable();
        }

        private IQueryable<Product> GetProductsTestData()
        {
            var products = new List<Product>();
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product()
                {
                    Id = i,
                    CategoryId = i,
                    Name = "Product " + i,
                    Price = i + 1.5,
                    Description = "This is Product " + i
                }); ;
            }
            return products.AsQueryable();
        }


        public FoodShopDbContextMock() 
        {
            var categoriesData = GetCategoriesTestData();
            var productsData = GetProductsTestData();
            var dbContextMock = new Mock<FoodShopDbContext>();

            var categoriesMock = new Mock<DbSet<Category>>();
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categoriesData.Provider);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categoriesData.Expression);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categoriesData.ElementType);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => categoriesData.GetEnumerator());
            
            var productsMock = new Mock<DbSet<Product>>();
            productsMock.As <IQueryable<Product>>().Setup(m => m.Provider).Returns(productsData.Provider);
            productsMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(productsData.Expression);
            productsMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(productsData.ElementType);
            productsMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => productsData.GetEnumerator());

            dbContextMock.Setup(c => c.Categories).Returns(categoriesMock.Object);
            dbContextMock.Setup(c => c.Products).Returns(productsMock.Object);

            DbContextMock = dbContextMock;
        }
    }
}
