using AutoMapper;
using Moq;
using Ordering.Application.Contracts;
using Ordering.Application.Features.Queries;
using Ordering.Domain.Entities;
using System.Linq.Expressions;

namespace Ordering.Test.Features.Orders.Checkout
{
    public class GetOrdersListQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidUserName_ReturnsOrdersViewModelList()
        {
            // Arrange
            var userName = "testUser";
            var orders = new List<Order>
            {
                new Order { Id = 1, UserName = userName },
                new Order { Id = 2, UserName = userName }
            };

            var mockRepository = new Mock<IGenericRepository<Order>>();
            mockRepository.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<Order, bool>>>()))
                          .ReturnsAsync(orders);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(mapper => mapper.Map<List<OrdersViewModel>>(orders))
                      .Returns(new List<OrdersViewModel>
                      {
                          new OrdersViewModel { Id = 1, UserName = userName },
                          new OrdersViewModel { Id = 2, UserName = userName }
                      });

            var query = new GetOrdersListQuery { UserName = userName };
            var handler = new GetOrdersListQueryHandler(mockRepository.Object, mockMapper.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<OrdersViewModel>>(result);
            Assert.Equal(2, result.Count);
        }
    }
}
