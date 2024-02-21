using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.PublisherService;
using Application.Queries.PublisherService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PublisherServiceController> _logger;
        public PublisherServiceController(IMediator mediator, ILogger<PublisherServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreatePublisher")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreatePublisher([FromBody] CreatePublisherCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        
        [HttpGet(Name = "GetAllPublishers")]
        [ProducesResponseType(typeof(IEnumerable<List<PublisherResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<PublisherResponse>>> GetAllPublishers(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllPublishersQuery(), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpGet("{id}", Name = "GetPublisherById")]
        [ProducesResponseType(typeof(PublisherResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<PublisherResponse>> GetPublisherById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Publisher GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetPublisherByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpPut(Name = "UpdatePublisher")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePublisher([FromBody] UpdatePublisherCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        

        
        [HttpDelete("{id}", Name = "DeletePublisher")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePublisher(int id)
        {
            _logger.LogInformation("Publisher DELETE request received for ID {id}", id);
            var cmd = new DeletePublisherCommand() { Id = id };
            await _mediator.Send(cmd);
            return NoContent();
        }
        
    }
}
