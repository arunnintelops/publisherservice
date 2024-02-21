using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
