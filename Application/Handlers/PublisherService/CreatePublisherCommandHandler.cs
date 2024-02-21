using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.PublisherService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.PublisherService
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, int>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePublisherCommandHandler> _logger;

        public CreatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper, ILogger<CreatePublisherCommandHandler> logger)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisherEntity = _mapper.Map<Publisher>(request);

            /*****************************************************************************/
            var generatedPublisher = await _publisherRepository.AddAsync(publisherEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedPublisher} successfully created.");
            return generatedPublisher.Id;
        }
    }
}
