using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IUserRepository : IRepository<User>
    {

    }
}