using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.PublisherService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.PublisherService
{
    public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly ILogger<DeletePublisherCommandHandler> _logger;

        public DeletePublisherCommandHandler(IPublisherRepository publisherRepository, ILogger<DeletePublisherCommandHandler> logger)
        {
            _publisherRepository = publisherRepository;
            _logger = logger;
        }
        public async Task Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisherToDelete = await _publisherRepository.GetByIdAsync(request.Id);
            if (publisherToDelete == null)
            {
                throw new PublisherNotFoundException(nameof(Publisher), request.Id);
            }

            await _publisherRepository.DeleteAsync(publisherToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
