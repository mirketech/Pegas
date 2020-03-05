using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface ICompanyRepository : IRepository<Company>
    {

    }
}