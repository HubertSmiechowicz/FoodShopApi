﻿using AutoMapper;
using FoodShop.Entities;
using FoodShop.Entities.dtos;
using FoodShop.Exceptions;
using FoodShop.Services;
using FoodShop.Services.Tools;
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

            var productsLength = productsQueryService.GetAllProducts(Sorted.ASCENDING_ID).Count;

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

            var categoryNameResult = productsQueryService.GetAllProducts(Sorted.ASCENDING_ID)[listPosition].CategoryName;

            // assert

            Assert.Equal(categoryName, categoryNameResult);
        }

        [Theory]
        [InlineData(13)]
        [InlineData(16)]
        [InlineData(18)]
        [InlineData(23)]
        public void GetProductById_ForGivenIdOutOfListRange_ThrowEntityNullException(int id)
        {
            // arrange

            var productProfile = new ProductMappingProfile();
            productProfile._db = dbContext.Object;
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            IMapper mapper = new Mapper(configuration);

            var productsQueryService = new ProductQueryService(dbContext.Object, mapper);

            // assert

            Assert.Throws<EntityNotFoundException>(() => productsQueryService.GetProductById(id));
        }
    }
}
