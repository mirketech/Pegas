using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class MeetingPointRepository : RepositoryBase<MeetingPointEnum>, IMeetingPointRepository
    {
        public MeetingPointRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IMeetingPointRepository : IRepository<MeetingPointEnum>
    {

    }
}