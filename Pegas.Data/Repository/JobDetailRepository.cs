using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class JobDetailRepository : RepositoryBase<JobDetail>, IJobDetailRepository
    {
        public JobDetailRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IJobDetailRepository : IRepository<JobDetail>
    {

    }
}