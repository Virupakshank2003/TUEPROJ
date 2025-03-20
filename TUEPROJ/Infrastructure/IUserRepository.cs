using TUEPROJ.Domain;

namespace TUEPROJ.Infrastructure
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<IEnumerable<User>> SearchUsersAsync(string searchTerm);
    }
}
