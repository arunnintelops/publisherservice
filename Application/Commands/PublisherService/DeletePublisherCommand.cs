using MediatR;

namespace Application.Commands.PublisherService
{
    public class DeletePublisherCommand : IRequest
    {
        public int Id { get; set; }
    }
}
