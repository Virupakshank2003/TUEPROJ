using MediatR;
using TUEPROJ.Application.Queries;
using TUEPROJ.Domain;
using TUEPROJ.Infrastructure;

namespace TUEPROJ.Application.Query_Handler
{
    public class SearchUserQueryHandler : IRequestHandler<SearchUserQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;
        public SearchUserQueryHandler(IUserRepository userRepository)
        {
               _userRepository = userRepository; 
        }

        public async Task<IEnumerable<User>>Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {
            var users= ( await _userRepository.SearchUsersAsync(request.SearchTerm)).ToList();

            if (!users.Any())
            {
                throw new KeyNotFoundException("User Not Found!");
            }

            return users;
        }
    }
}
