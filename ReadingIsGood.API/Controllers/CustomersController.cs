using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Application.Features.AuthFeature.Commands;
using ReadingIsGood.Application.Features.BookFeature.Queries;
using ReadingIsGood.Application.Features.CustomerFeature.Queries;

namespace ReadingIsGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        [HttpPost("GetCustomers")]
        public async Task<IActionResult> GetCustomers(GetCustomerQuery request)
        {
            var result = await Mediator.Send(request);
           
            return Ok(result);
            
        }
        [HttpPost("GetOrdersByCustomer")]
        [Authorize]
        public async Task<IActionResult> GetOrdersByCustomer(GetOrdersByCustomerQuery request)
        {
            request.CustomerId = getUserIdFromRequest();
            var result = await Mediator.Send(request);

            return Ok(result);

        }
    }
}
