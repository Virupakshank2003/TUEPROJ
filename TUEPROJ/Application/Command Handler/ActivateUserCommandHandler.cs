using MediatR;
using System.Reflection.Metadata.Ecma335;
using TUEPROJ.Application.Commands;
using TUEPROJ.Infrastructure;

namespace TUEPROJ.Application.Command_Handler
{
    public class ActivateUserCommandHandler:IRequestHandler<ActivateUserCommand,bool>
    {
        private readonly IUserRepository _userRepository;

        public ActivateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool>Handle(ActivateUserCommand command,CancellationToken cancellation)
        {
            var user=await _userRepository.GetByIdAsync(command.Id);
            if (user.Status == true)
            {
                return false;
            }

            user.Status=!user.Status;
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
