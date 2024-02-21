using MediatR;
using Application.Responses;

namespace Application.Queries.PublisherService
{
    public class GetPublisherByIdQuery : IRequest<PublisherResponse>
    {
        public int id { get; set; }

        public GetPublisherByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
