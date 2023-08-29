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

        private IMapper mapper()
        {
            var productProfile = new ProductMappingProfile();
            productProfile._db = dbContext.Object;
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void AddProduct_ForGivenNullProductToSave_ThrowArgumentNullException()
        {
            // arrange

            var productCommandService = new ProductCommandService(dbContext.Object, mapper());

            // Assert

            Assert.Throws<ArgumentNullException>(() => productCommandService.AddProduct(null));
        }

        [Theory]
        [InlineData(13)]
        [InlineData(16)]
        [InlineData(19)]
        [InlineData(21)]
        public void UpdateProductPrice_ForGivenIdOutOfListRange_ThrowArgumentNullException(int id)
        {
            // arrange

            var productCommandService = new ProductCommandService(dbContext.Object, mapper());

            // Assert

            Assert.Throws<ArgumentNullException>(() => productCommandService.UpdateProductPrice(id, 1.0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-3)]
        [InlineData(-5)]
        public void UpdateProductPrice_ForGivenPriceLessOrEqual0_ThrowArgumentException(double price)
        {
            // arrange

            var productCommandService = new ProductCommandService(dbContext.Object, mapper());

            // Assert

            Assert.Throws<ArgumentException>(() => productCommandService.UpdateProductPrice(1, price));
        }

        [Theory]
        [InlineData(13)]
        [InlineData(16)]
        [InlineData(19)]
        [InlineData(21)]
        public void UpdateProductDescription_ForGivenIdOutOfListRange_ThrowArgumentNullException(int id)
        {
            // arrange

            var productCommandService = new ProductCommandService(dbContext.Object, mapper());

            // Assert

            Assert.Throws<ArgumentNullException>(() => productCommandService.UpdateProductDescription(id, "New Description"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void UpdateProductDescription_ForGivenNullOrEmptyNewDescription_ThrowArgumentNullException(string newDescription)
        {
            // arrange

            var productCommandService = new ProductCommandService(dbContext.Object, mapper());

            // Assert

            Assert.Throws<ArgumentNullException>(() => productCommandService.UpdateProductDescription(1, newDescription));
        }
    }
}
