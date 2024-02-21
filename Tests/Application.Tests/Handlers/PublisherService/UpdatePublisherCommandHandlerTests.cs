using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.PublisherService;
using Application.Exceptions;
using Application.Handlers.PublisherService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.PublisherService
{
    public class UpdatePublisherCommandHandlerTests
    {
        private readonly Mock<IPublisherRepository> _publisherRepository;
        private readonly Mock<ILogger<UpdatePublisherCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdatePublisherCommandHandlerTests()
        {
            _publisherRepository = new();
            _logger = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_ThrowsPublisherNotFoundExceptionWhenPublisherNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdatePublisherCommand { Id = Id }; // Create a request object

            _publisherRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Publisher)null); // Mock the repository to return null

            var handler = new UpdatePublisherCommandHandler(_publisherRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<PublisherNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
