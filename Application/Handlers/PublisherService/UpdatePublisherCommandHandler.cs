using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.PublisherService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.PublisherService
{
    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePublisherCommandHandler> _logger;

        public UpdatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper, ILogger<UpdatePublisherCommandHandler> logger)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisherToUpdate = await _publisherRepository.GetByIdAsync(request.Id);
            if (publisherToUpdate == null)
            {
                throw new PublisherNotFoundException(nameof(Publisher), request.Id);
            }

            _mapper.Map(request, publisherToUpdate, typeof(UpdatePublisherCommand), typeof(Publisher));
            await _publisherRepository.UpdateAsync(publisherToUpdate);
            _logger.LogInformation($"Publisher is successfully updated");
        }
    }
}
