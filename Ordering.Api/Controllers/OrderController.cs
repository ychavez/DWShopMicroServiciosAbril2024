﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Commands.Checkout;
using Ordering.Application.Features.Queries;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "OVNI")]
        public async Task<ActionResult<int>> CreateOrder([FromBody] CheckoutOrderCommand command)
            => await mediator.Send(command);

        [Authorize]
        [HttpGet("{userName}")]
        public async Task<ActionResult<List<OrdersViewModel>>> GetOrders(string userName)
            => Ok(await mediator.Send(new GetOrdersListQuery { UserName = userName }));
    }
}
