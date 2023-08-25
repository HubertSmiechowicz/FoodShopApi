using Castle.Components.DictionaryAdapter.Xml;
using FoodShop.Entities;
using FoodShop.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Tests.Services
{
    public class CategoryCommandServiceTests
    {

        private Mock<FoodShopDbContext> dbContextMock = new FoodShopDbContextMock().DbContextMock;

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void AddCategory_ForGivenEmptyStringName_ThrowArgumentNullException(string name)
        {
            // arrange

            var categoryCommandService = new CategoryCommandService(dbContextMock.Object);

            // assert

            Assert.Throws<ArgumentNullException>(() => categoryCommandService.AddCategory(name));
        }

        [Fact]
        public void AddCategory_ForGivenAnyName_ReturnEmptyProductsList()
        {
            // arrange

            var categoryCommandService = new CategoryCommandService(dbContextMock.Object);

            // act

            var productsListLength = categoryCommandService.AddCategory("Category x").Products.Count;

            // assert

            Assert.Equal(0, productsListLength);


        }

        [Theory]
        [InlineData(13)]
        [InlineData(15)]
        [InlineData(17)]
        public void DeleteCategoryById_ForGivenIdsOutOfRange_ThrowArgumentNullException(int id)
        {
            // arrange

            var categoryCommandService = new CategoryCommandService(dbContextMock.Object);

            // assert

            Assert.Throws<ArgumentNullException>(() => categoryCommandService.DeleteCategoryById(id));  
        }

        [Theory]
        [InlineData(13)]
        [InlineData(15)]
        [InlineData(17)]
        public void UpdateCategory_ForGivenIdsOutOfRange_ThrowArgumentNullException(int id)
        {
            // arrange

            var categoryCommandService = new CategoryCommandService(dbContextMock.Object);

            // assert

            Assert.Throws<ArgumentNullException>(() => categoryCommandService.UpdateCategory(id, "Category x"));
        }

        [Theory]
        [InlineData("Category x")]
        [InlineData("Category y")]
        [InlineData("Category z")]
        public void UpdateCategory_ForGivenNames_ReturnCategoryWithCorrectName(string name)
        {
            // arrange

            var categoryCommandService = new CategoryCommandService(dbContextMock.Object);

            // act

            var newCategoryName = categoryCommandService.UpdateCategory(1, name).Name;

            // assert

            Assert.Equal(name, newCategoryName);
        }
    }
}
