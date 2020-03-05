using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class FlightCodeRepository : RepositoryBase<FlightCodeEnum>, IFlightCodeRepository
    {
        public FlightCodeRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IFlightCodeRepository : IRepository<FlightCodeEnum>
    {

    }
}