using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Application.Features.BookFeature.Command;
using ReadingIsGood.Application.Features.BookFeature.Dtos;
using ReadingIsGood.Application.Features.BookFeature.Queries;
using ReadingIsGood.Application.Features.CustomerFeature.Queries;

namespace ReadingIsGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        [HttpPost("Add")]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] CreateBookCommand request)
        {
            CreateBookDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand request)
        {
            UpdateBookDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("GetBooks")]
        [Authorize]
        public async Task<IActionResult> GetBooks(GetBookQuery request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);

        }
    }
}
