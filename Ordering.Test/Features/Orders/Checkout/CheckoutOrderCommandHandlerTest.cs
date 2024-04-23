using AutoMapper;
using Moq;
using Ordering.Application.Contracts;
using Ordering.Application.Features.Commands.Checkout;
using Ordering.Domain.Entities;

namespace Ordering.Test.Features.Orders.Checkout
{
    public class CheckoutOrderCommandHandlerTest
    {
        private readonly CheckoutOrderCommandHandler _handler;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IGenericRepository<Order>> _repository;

        public CheckoutOrderCommandHandlerTest()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IGenericRepository<Order>>();
            _handler = new CheckoutOrderCommandHandler(_repository.Object,_mapper.Object);
        }


        [Theory]
        [InlineData(100000)]
        [InlineData(12)]
        [InlineData(100)]
        public async Task Handle_ShouldAddNewOrderToRepository(int id) 
        {
            //Arrange
            var command = new CheckoutOrderCommand
            {
                Address = "hola@hola.com",
                FirstName = "Yael",
                LastName = "Chavez",
                PaymentMethod = 1,
                TotalPrice = 100,
                UserName = "ychavez"
            };

            var orderEntity = new Order { Id = id };
            _mapper.Setup(x => x.Map<Order>(command)).Returns(orderEntity);
            _repository.Setup(x => x.AddAsync(orderEntity)).ReturnsAsync(orderEntity);

            //Act
            var result = await _handler.Handle(command, default);
          

            //Assert
            Assert.Equal(result,orderEntity.Id); //verificamos que el resultado sea el ID
            _repository.Verify(x=> x.AddAsync(orderEntity), Times.Once); // verificamos que se haya ejecutado el AddAsync del repositorio
            _mapper.Verify(x=> x.Map<Order>(command), Times.Once);
        
        }
    }
}
