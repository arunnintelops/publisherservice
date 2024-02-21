using AutoMapper;
using Moq;
using Application.Handlers.PublisherService;
using Application.Queries.PublisherService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.PublisherService
{
    public class GetPublisherByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsPublisherResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Publisher, PublisherResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new Publisher { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IPublisherRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetPublisherByIdQuery(Id);
            var handler = new GetPublisherByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PublisherResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
