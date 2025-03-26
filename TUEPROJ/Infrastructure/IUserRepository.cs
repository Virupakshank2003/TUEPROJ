using TUEPROJ.Domain;

namespace TUEPROJ.Infrastructure
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(User user);
        Task<(IEnumerable<User>Users,int TotalCount)> GetUsersWithSearchAsync(string?searchTerm,int page, int pageSize);

        //Task<(IEnumerable<User>Users,int TotalCount)> SearchUsersAsync(string searchTerm,int page, int pageSize);
        Task<User> GetByIdAsync(int id);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);
    }
}
