using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShop.Entities;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using FoodShop.Services;
using AutoMapper;
using FoodShop.Entities.dtos;

namespace FoodShop.Tests.Services
{
    public class CategoryQueryServiceTests
    {


        private Mock<FoodShopDbContext> dbContext = new FoodShopDbContextMock().DbContextMock;

        [Fact]
        public void GetCategories_ForGivenDataWith10Categories_ReturnListOfLength10()
        {
            // arrange

            var productProfile = new ProductMappingProfile();
            productProfile._db = dbContext.Object;
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            IMapper mapper = new Mapper(configuration);

            var categoryQueryService = new CategoryQueryService(dbContext.Object, mapper);

            // act

            var categoriesLength = categoryQueryService.GetCategories().Count;

            // assert

            Assert.Equal(10, categoriesLength);
        }

        [Theory]
        [InlineData(1, "Category 1")]
        [InlineData(3, "Category 3")]
        [InlineData(5, "Category 5")]
        [InlineData(7, "Category 7")]
        [InlineData(9, "Category 9")]
        public void GetCategoryById_ForGivenId_ReturnCorrectCategory(int id, string name)
        {
            // arrange
            var productProfile = new ProductMappingProfile();
            productProfile._db = dbContext.Object;
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            IMapper mapper = new Mapper(configuration);

            var categoryQueryService = new CategoryQueryService(dbContext.Object, mapper);

            // act

            var categoryName = categoryQueryService.GetCategoryById(id).Name;

            // assert

            Assert.Equal(name, categoryName);
        }
    }
}
