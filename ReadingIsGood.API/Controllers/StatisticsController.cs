using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Application.Features.BookFeature.Queries;
using ReadingIsGood.Application.Features.StatisticsFeature.Commands;
using ReadingIsGood.Application.Features.StatisticsFeature.Queries;

namespace ReadingIsGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : BaseController
    {
        [HttpPost("Get")]
        [Authorize]
        public async Task<IActionResult> Get(StatisticsQuery request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);

        }
        [HttpPost("Add")]
        [Authorize]
        public async Task<IActionResult> Add(StatisticsCommand request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);

        }
    }
}
