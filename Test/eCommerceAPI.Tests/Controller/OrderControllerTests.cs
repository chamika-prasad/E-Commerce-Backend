using Assignment.Controller;
using Assignment.Error;
using Assignment.Interface;
using Assignment.Request;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServiceStack;

namespace eCommerceAPI.Tests.Controller
{
    public class OrderControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IOrderService> _serviceMock;
        private readonly OderController _sut;

        public OrderControllerTests()
        {
            _fixture= new Fixture();
            _serviceMock= _fixture.Freeze<Mock<IOrderService>>();
            _sut = new OderController(_serviceMock.Object);

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

        }

        [Fact]
        public void PlaceOrder_ShouldReturnOkResponse_WhenOrderPlaceSuccessfully()
        {
            //Arrange

            var request = new OrderRequest
            {
                quantity = 10,
                userEmail = "example@gmail.com",
            };

            var responseMock = _fixture.Build<OrderErrorResponseHandler>().With(p => p.State, true).Create();

            _serviceMock.Setup(x => x.PlaceOrdersDirect(10,request)).Returns(responseMock);

            //Act
            var result = _sut.PlaceOrdersDirectly(10,request);
            OkObjectResult okResult = result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.GetType().Should().Be(typeof(OkObjectResult));
            Assert.Equal(200, okResult.StatusCode);
            _serviceMock.Verify(x => x.PlaceOrdersDirect(10,request),Times.Once);
        }

        [Fact]
        public void PlaceOrder_ShouldReturnBadRequestResponse_WhenOrderPlaceFaild()
        {
            //Arrange

            var request = new OrderRequest
            {
                quantity = 10,
                userEmail = "example@gmail.com",
            };

            var responseMock = _fixture.Build<OrderErrorResponseHandler>().With(p => p.State, false).Create();

            _serviceMock.Setup(x => x.PlaceOrdersDirect(10, request)).Returns(responseMock);

            //Act
            var result = _sut.PlaceOrdersDirectly(10, request);
            BadRequestObjectResult badResult = result as BadRequestObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            Assert.Equal(400, badResult.StatusCode);
            _serviceMock.Verify(x => x.PlaceOrdersDirect(10, request), Times.Once);
        }
      
        [Fact]
        public void UpdateOrdersState_ShouldReturnOkResponse_WhenOrderStateUpdateSuccessfully()
        {
            //Arrange

            var state = "accepted";

            var responseMock = _fixture.Build<OrderErrorResponseHandler>().With(p => p.State, true).Create();

            _serviceMock.Setup(x => x.UpdateOrderState(10, state)).Returns(responseMock);

            //Act
            var result = _sut.UpdateOrdersState(10, state);
            OkObjectResult okResult = result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.GetType().Should().Be(typeof(OkObjectResult));
            Assert.Equal(200, okResult.StatusCode);
            _serviceMock.Verify(x => x.UpdateOrderState(10, state), Times.Once);
        }

        [Fact]
        public void UpdateOrdersState_ShouldReturnBadRequestResponse_WhenOrderStateUpdateFaild()
        {
            //Arrange

            var state = "accepted";

            var responseMock = _fixture.Build<OrderErrorResponseHandler>().With(p => p.State, false).Create();

            _serviceMock.Setup(x => x.UpdateOrderState(10, state)).Returns(responseMock);

            //Act
            var result = _sut.UpdateOrdersState(10, state);
            BadRequestObjectResult badResult = result as BadRequestObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            Assert.Equal(400, badResult.StatusCode);
            _serviceMock.Verify(x => x.UpdateOrderState(10, state), Times.Once);
        }
    }
}