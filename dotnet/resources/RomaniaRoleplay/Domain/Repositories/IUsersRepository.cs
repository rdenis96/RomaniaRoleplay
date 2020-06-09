using Domain.Users.Models;

namespace Domain.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        User GetWrapperByUsername(string username);
        bool ExistsUser(string username);
        User GetByUsernameAndPassword(string username, string password);
    }
}
