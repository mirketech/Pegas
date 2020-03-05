using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IVehicleRepository : IRepository<Vehicle>
    {

    }
}