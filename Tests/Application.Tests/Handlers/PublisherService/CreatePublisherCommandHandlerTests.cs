using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.PublisherService;
using Application.Handlers.PublisherService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.PublisherService
{
    public class CreatePublisherCommandHandlerTests
    {
        private readonly Mock<IPublisherRepository> _publisherRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreatePublisherCommandHandler>> _logger;

        public CreatePublisherCommandHandlerTests()
        {
            _publisherRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreatePublisherCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<Publisher>(request))
                .Returns(new Publisher()); 

            _publisherRepository
                .Setup(r => r.AddAsync(It.IsAny<Publisher>()))
                .ReturnsAsync(new Publisher { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreatePublisherCommandHandler>>();
            var handler = new CreatePublisherCommandHandler(_publisherRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
