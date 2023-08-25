using FoodShop.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using FoodShop.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoodShop.Entities.dtos;

namespace FoodShop.Tests.Services
{
    public class ProductCommandServiceTests
    {
        private Mock<FoodShopDbContext> dbContext = new FoodShopDbContextMock().DbContextMock;

        [Fact]
        public void AddProduct_ForGivenNullProductToSave_ThrowArgumentNullException()
        {
            // arrange

            var productProfile = new ProductMappingProfile();
            productProfile._db = dbContext.Object;
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            IMapper mapper = new Mapper(configuration);

            var productCommandService = new ProductCommandService(dbContext.Object, mapper);

            // Assert

            Assert.Throws<ArgumentNullException>(() => productCommandService.AddProduct(null));
        }
    }
}
