using AutoMapper;
using MediatR;
using Application.Queries.PublisherService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.PublisherService
{
    public class GetAllPublishersQueryHandler : IRequestHandler<GetAllPublishersQuery, List<PublisherResponse>>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public GetAllPublishersQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }
        public async Task<List<PublisherResponse>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
        {
            var generatedPublisher = await _publisherRepository.GetAllAsync();
            var publisherEntity = _mapper.Map<List<PublisherResponse>>(generatedPublisher);
            return publisherEntity;
        }
    }
}
