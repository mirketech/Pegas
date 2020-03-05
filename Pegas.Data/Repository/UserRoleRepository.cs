using Pegas.Data.Infrastructure;

namespace Pegas.Data.Repository
{
    public class UserRoleRepository : RepositoryBase<UserRoleEnum>, IUserRoleRepository
    {
        public UserRoleRepository(IDatabaseFactory provider) : base(provider)
        {

        }
    }
    public interface IUserRoleRepository : IRepository<UserRoleEnum>
    {

    }
}