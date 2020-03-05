using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
    {
        public DriverRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IDriverRepository : IRepository<Driver>
    {

    }
}