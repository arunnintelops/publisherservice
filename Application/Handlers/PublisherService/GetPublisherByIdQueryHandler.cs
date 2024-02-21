using AutoMapper;
using MediatR;
using Application.Queries.PublisherService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.PublisherService
{
    public class GetPublisherByIdQueryHandler : IRequestHandler<GetPublisherByIdQuery, PublisherResponse>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public GetPublisherByIdQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }
        public async Task<PublisherResponse> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedPublisher = await _publisherRepository.GetByIdAsync(request.id);
            var publisherEntity = _mapper.Map<PublisherResponse>(generatedPublisher);
            return publisherEntity;
        }
    }
}
