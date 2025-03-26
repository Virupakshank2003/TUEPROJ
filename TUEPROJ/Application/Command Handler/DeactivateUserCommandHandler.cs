using MediatR;
using TUEPROJ.Application.Commands;
using TUEPROJ.Infrastructure;

namespace TUEPROJ.Application.Command_Handler
{
    public class DeactivateUserCommandHandler:IRequestHandler<DeactivateUserCommand,bool>
    {
        private readonly IUserRepository _userRepository;
        public DeactivateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public async Task<bool>Handle(DeactivateUserCommand command,CancellationToken cancellation)
        {
            var user = await _userRepository.GetByIdAsync(command.Id);
            if (user.Status == false)
            {
                return false;
            }
            user.Status = !user.Status;
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
