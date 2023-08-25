using AutoMapper;
using FoodShop.Entities;
using FoodShop.Entities.dtos;
using FoodShop.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Tests.Services
{
    public class ProductQueryServiceTests
    {
        private Mock<FoodShopDbContext> dbContext = new FoodShopDbContextMock().DbContextMock;

        [Fact]
        public void GetAllProducts_ForGivenTestsData_ReturnsCorrectLengthProductList()
        {
            // arrange
            var productProfile = new ProductMappingProfile();
            productProfile._db = dbContext.Object;
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            IMapper mapper = new Mapper(configuration);

            var productsQueryService = new ProductQueryService(dbContext.Object, mapper);

            // act

            var productsLength = productsQueryService.GetAllProducts().Count;

            // assert

            Assert.Equal(10, productsLength);
        }

        [Theory]
        [InlineData(0, "Category 1")]
        [InlineData(1, "Category 2")]
        [InlineData(2, "Category 3")]
        [InlineData(3, "Category 4")]
        [InlineData(4, "Category 5")]
        public void GetAllProducts_ForGivenIds_ReturnCorrectCategoryName(int listPosition, string categoryName)
        {
            // arrange
            var productProfile = new ProductMappingProfile();
            productProfile._db = dbContext.Object;
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            IMapper mapper = new Mapper(configuration);

            var productsQueryService = new ProductQueryService(dbContext.Object, mapper);

            // act

            var categoryNameResult = productsQueryService.GetAllProducts()[listPosition].CategoryName;

            // assert

            Assert.Equal(categoryName, categoryNameResult);
        }
    }
}
