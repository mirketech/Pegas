using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class VehicleTypeRepository : RepositoryBase<VehicleTypeEnum>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IVehicleTypeRepository : IRepository<VehicleTypeEnum>
    {

    }
}