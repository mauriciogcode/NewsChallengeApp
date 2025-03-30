using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Application.Commands;
using NewsApi.Application.Queries;
using NewsApi.Domain.Entities;

namespace NewsApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<News>>> Get( [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] bool orderByDescending = true) 
        {
            var query = new GetNewsListQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                OrderByDescending = orderByDescending
            };
            var result = await _mediator.Send(query);
            if (result == null) return NoContent();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetById(int id)
        {
            var query = new GetNewsByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateNewsCommand command)
        {
            var newsId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = newsId }, newsId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateNewsCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteNewsCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("test-error")]
        public IActionResult TestError()
        {
            throw new Exception("Test exception to verify logging and exception handling.");
        }
    }
}
