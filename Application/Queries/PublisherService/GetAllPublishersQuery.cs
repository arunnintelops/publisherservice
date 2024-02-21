using MediatR;
using Application.Responses;

namespace Application.Queries.PublisherService
{
    public class GetAllPublishersQuery : IRequest<List<PublisherResponse>>
    {

    }
}
