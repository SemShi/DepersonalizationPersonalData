using DepersonalizationPersonalData.Models;

namespace DepersonalizationPersonalData.Repositories.Users
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetUserById(Guid guid);
        Task<IEnumerable<User>> GetFromDatabase(string query);
        Task<IEnumerable<User>> SignUp(string login, string password);
    }
}
