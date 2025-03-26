using MediatR;

namespace TUEPROJ.Application.Commands
{
    public class ToggleStatusCommand:IRequest<bool>
    {
        public int UserId { get; set; }
        public ToggleStatusCommand(int userId)
        {
            UserId = userId;
        }
    }
}
