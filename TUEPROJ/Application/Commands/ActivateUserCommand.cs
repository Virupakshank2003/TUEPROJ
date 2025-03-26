using MediatR;

namespace TUEPROJ.Application.Commands
{
    public class ActivateUserCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public ActivateUserCommand(int id)
        {
            Id = id;
        }
    }
}
