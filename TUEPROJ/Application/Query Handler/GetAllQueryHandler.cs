using MediatR;
using TUEPROJ.Application.DTOs;
using TUEPROJ.Application.Queries;
using TUEPROJ.Domain;
using TUEPROJ.Infrastructure;

namespace TUEPROJ.Application.Query_Handler
{
    public class GetAllQueryHandler : IRequestHandler<GetUsersQuery, PaginatedUserResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetAllQueryHandler(IUserRepository userRepository)
        {
                _userRepository = userRepository;
        }
        public async Task<PaginatedUserResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var (users, totalCount) = await _userRepository.GetUsersWithSearchAsync(request.SearchTerm, request.Page, request.PageSize);
            int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            return new PaginatedUserResponse
            {
                Users = users,
                TotalPages = totalPages
            };

        }

    }
}
