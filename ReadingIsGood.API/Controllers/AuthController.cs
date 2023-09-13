using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Application.Features.AuthFeature.Commands;
using ReadingIsGood.Application.Responsed;

namespace ReadingIsGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            var result = await Mediator.Send(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand request)
        {
            var result = await Mediator.Send(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
     
    }
}
