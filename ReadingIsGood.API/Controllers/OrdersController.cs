using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Application.Features.BookFeature.Command;
using ReadingIsGood.Application.Features.BookFeature.Dtos;
using ReadingIsGood.Application.Features.BookFeature.Queries;
using ReadingIsGood.Application.Features.CustomerFeature.Queries;
using ReadingIsGood.Application.Features.OrderFeature.Commands;
using ReadingIsGood.Application.Features.OrderFeature.Dtos;
using ReadingIsGood.Application.Features.OrderFeature.Queries;

namespace ReadingIsGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        [HttpPost("Add")]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand request)
        {
            CreateOrderDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("GetOrder")]
        [Authorize]
        public async Task<IActionResult> GetOrder(GetOrderQuery request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);

        }
        [HttpPost("GetOrders")]
        [Authorize]
        public async Task<IActionResult> GetOrder(GetOrdersQuery request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);

        }
    }
}
