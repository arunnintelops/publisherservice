using AutoMapper;
using Moq;
using Application.Handlers.PublisherService;
using Application.Queries.PublisherService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.PublisherService
{
    public class GetAllPublishersQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfPublisherResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Publisher, PublisherResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<Publisher> 
        {
            new Publisher { Id = 1 },
            new Publisher { Id = 2 }

        };

            var RepositoryMock = new Mock<IPublisherRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllPublishersQuery();
            var handler = new GetAllPublishersQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<PublisherResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
