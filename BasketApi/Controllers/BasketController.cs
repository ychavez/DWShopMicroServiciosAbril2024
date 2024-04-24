using BasketApi.Entities;
using BasketApi.Repositories;
using EventBus.Messages.Events;
using Inventory.gRPC.Protos;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController(IBasketRepository basketRepository, 
        IPublishEndpoint publishEndpoint, Existence.ExistenceClient existenceService) : ControllerBase
    {
        [HttpGet("{userName}")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await basketRepository.GetBasket(userName);
            return Ok(basket ?? new(userName));
        }

        [HttpPost("Checkout")]
        public async Task<ActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            var basket = await basketRepository.GetBasket(basketCheckout.UserName);

            if (basket is null)
                return BadRequest();

            var eventMessage = new BasketCheckoutEvent
            {
                UserName = basket.Username,
                Address = basketCheckout.Address,
                FirstName = basketCheckout.FirstName,
                LastName = basketCheckout.LastName,
                PaymentMethod = basketCheckout.PaymentMethod,
                TotalPrice = basketCheckout.TotalPrice,
            };

            await publishEndpoint.Publish(eventMessage);

            await basketRepository.DeleteBasket(basketCheckout.UserName);

            return Accepted();

        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart shoppingCart)
        {

            foreach (var item in shoppingCart.CartItems)
            {
                var existence = await existenceService.checkExistenceAsync(new() { Id = item.ProductId });

                item.Quantity = item.Quantity > existence.ProductQTY ? existence.ProductQTY: item.Quantity;
            }

            await basketRepository.UpdateBasket(shoppingCart);
            return Ok(shoppingCart);
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult> DeleteBasket(string userName)
        {
            await basketRepository.DeleteBasket(userName);
            return NoContent();
        }

    }
}
