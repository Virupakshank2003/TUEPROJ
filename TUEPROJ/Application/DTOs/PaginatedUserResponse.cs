using TUEPROJ.Domain;

namespace TUEPROJ.Application.DTOs
{
    public class PaginatedUserResponse
    {
        public IEnumerable<User> Users { get; set; }
        public int TotalPages { get; set; }
    }
}
