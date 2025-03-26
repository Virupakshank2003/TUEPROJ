using MediatR;
using TUEPROJ.Application.Commands;
using TUEPROJ.Infrastructure;

namespace TUEPROJ.Application.Command_Handler
{
    public class DeleteUserCommandHandler:IRequestHandler<DeleteUserCommand,bool>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public async Task<bool>Handle(DeleteUserCommand command,CancellationToken cancellation)
        {
            var user = await _userRepository.GetByIdAsync(command.Id);
            if (user == null)
            {
                return false;
            }
            await _userRepository.DeleteAsync(user);
            return true;
        }
    }
}
