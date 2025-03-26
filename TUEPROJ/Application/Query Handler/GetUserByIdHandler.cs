using MediatR;
using TUEPROJ.Application.Queries;
using TUEPROJ.Domain;
using TUEPROJ.Infrastructure;

namespace TUEPROJ.Application.Query_Handler
{
    public class GetUserByIdHandler:IRequestHandler<GetUserByIdQuery,User>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User>Handle(GetUserByIdQuery query,CancellationToken cancellationToken)
        {
            var user=await _userRepository.GetByIdAsync(query.Id);

           if (user == null)
            {
                return null;
            }

            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Status = user.Status,
            };


        }
    }
}
