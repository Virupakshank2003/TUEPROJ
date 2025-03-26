using MediatR;
using TUEPROJ.Application.Commands;
using TUEPROJ.Infrastructure;

namespace TUEPROJ.Application.Command_Handler
{
    public class ToggleStatusCommandHandler : IRequestHandler<ToggleStatusCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ToggleStatusCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public async Task<bool> Handle(ToggleStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null) return false;

            user.ToggleStatus();
            await _userRepository.UpdateAsync(user);

            return true;


        }
    }
}
