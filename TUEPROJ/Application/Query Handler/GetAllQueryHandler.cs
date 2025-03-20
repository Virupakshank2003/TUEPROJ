using MediatR;
using TUEPROJ.Application.Queries;
using TUEPROJ.Domain;
using TUEPROJ.Infrastructure;

namespace TUEPROJ.Application.Query_Handler
{
    public class GetAllQueryHandler:IRequestHandler<GetAllQuery,IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllQueryHandler(IUserRepository userRepository)
        {
                _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>>Handle(GetAllQuery request,CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsersAsync();
        }

    }
}
