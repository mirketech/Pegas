using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IContractRepository : IRepository<Contract>
    {

    }
}