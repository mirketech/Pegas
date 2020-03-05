using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class JobTypeRepository : RepositoryBase<JobTypeEnum>, IJobTypeRepository
    {
        public JobTypeRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IJobTypeRepository : IRepository<JobTypeEnum>
    {

    }
}