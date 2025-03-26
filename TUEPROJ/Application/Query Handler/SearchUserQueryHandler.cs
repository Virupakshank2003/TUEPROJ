//using MediatR;
//using TUEPROJ.Application.DTOs;
//using TUEPROJ.Application.Queries;
//using TUEPROJ.Domain;
//using TUEPROJ.Infrastructure;

//namespace TUEPROJ.Application.Query_Handler
//{
//    public class SearchUserQueryHandler : IRequestHandler<SearchUserQuery, PaginatedSearchUserResponse>
//    {
//        private readonly IUserRepository _userRepository;
//        public SearchUserQueryHandler(IUserRepository userRepository)
//        {
//               _userRepository = userRepository; 
//        }

//        public async Task<PaginatedSearchUserResponse>Handle(SearchUserQuery request, CancellationToken cancellationToken)
//        {
//            var (users, totalCount) = await _userRepository.SearchUsersAsync(request.SearchTerm, request.Page, request.PageSize);
//            int totalPages= (int)Math.Ceiling((double)totalCount / request.PageSize);
//            return new PaginatedSearchUserResponse
//            {
//                Users = users,
//                TotalPages = totalPages
//            };



           
//        }

       
//    }
//}
