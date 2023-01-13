﻿using Assignment.Controller;
using Assignment.Error;
using Assignment.Interface;
using Assignment.Request;
using AutoFixture;
using Azure.Core;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using ServiceStack;

namespace eCommerceAPI.Tests.Controller
{
    public class ProductControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IProductService> _serviceMock;
        private readonly ProductController _sut;

        public ProductControllerTests()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IProductService>>();
            _sut = new ProductController(_serviceMock.Object);

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

        }

        [Fact]
        public void SearchProduct_ShouldReturnOkResponseWithProduct_WhenSearchProductFound()
        {
            //Arrange

            var request = new SearchProductRequest
            {
                name = "chocolate",
            };

            var responseMock = _fixture.Create<List<Product>>();

            _serviceMock.Setup(x => x.SearchProduct(request)).Returns(responseMock);

            //Act
            var result = _sut.SearchProducts(request);
            OkObjectResult okResult = result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.GetType().Should().Be(typeof(OkObjectResult));
            Assert.Equal(200, okResult.StatusCode);
            _serviceMock.Verify(x => x.SearchProduct(request), Times.Once);
        }

        [Fact]
        public void SearchProduct_ShouldReturnBadRequestResponse_WhenSearchProductNotFound()
        {
            //Arrange

            var request = new SearchProductRequest
            {
                name = null,
            };

            List<Product> response = new List<Product>();


            _serviceMock.Setup(x => x.SearchProduct(request)).Returns(response);

            //Act
            var result = _sut.SearchProducts(request);
            BadRequestObjectResult badResult = result as BadRequestObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            Assert.Equal(400, badResult.StatusCode);
            _serviceMock.Verify(x => x.SearchProduct(request), Times.Once);
        }
    }
}
