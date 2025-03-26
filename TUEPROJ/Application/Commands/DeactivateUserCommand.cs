using MediatR;

namespace TUEPROJ.Application.Commands
{
    public class DeactivateUserCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public DeactivateUserCommand(int id)
        {
            Id = id;
        }
    }
}
