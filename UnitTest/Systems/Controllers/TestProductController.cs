using Business.Abstract;
using Entity.Dto.Product;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTest.Fixtures;
using WebAPI.Controllers;
using Xunit;

namespace UnitTest.Systems.Controllers
{
    public class TestProductController
    {
        //GetById
        [Fact]
        public async Task GetById_OnSuccess_ReturnsStatusCode200()
        {
            int productId = 1;
            //Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(service => service.Get(productId)).ReturnsAsync(new ProductGetDto());
            var systemUnderTest = new ProductController(mockProductService.Object);
            //Act
            var result = (OkObjectResult)await systemUnderTest.GetById(productId);
            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesProductService()
        {
            int productId = 1;
            //Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(service => service.Get(productId)).ReturnsAsync(new ProductGetDto());
            var systemUnderTest = new ProductController(mockProductService.Object);
            //Act
            var result = await systemUnderTest.GetById(productId);
            //Assert
            mockProductService.Verify(service => service.Get(productId));
        }

        //GetList
        [Fact]
        public async Task GetList_OnSuccess_ReturnsListOfProducts()
        {
            //Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService
                .Setup(service => service.GetList())
                .ReturnsAsync(ProductFixtures.GetProductList());

            var sut = new ProductController(mockProductService.Object);
            //Act
            var result = await sut.GetList();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<ProductListDto>>();
        }

        [Fact]
        public async Task GetList_OnNoProductsFound_Returns404()
        {
            //Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService
                .Setup(service => service.GetList())
                .ReturnsAsync(new List<ProductListDto>());

            var sut = new ProductController(mockProductService.Object);
            //Act
            var result = await sut.GetList();

            //Assert
            result.Should().BeOfType<NotFoundResult>();

        }
    }
}
