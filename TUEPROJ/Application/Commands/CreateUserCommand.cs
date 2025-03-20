using MediatR;
using TUEPROJ.Domain.Enums;

namespace TUEPROJ.Application.Commands
{
    public class CreateUserCommand: IRequest<int>
    {
        
        public string Name { get; set; }

        public string Email { get; set; }
        public UserRole Role { get; set; }
        public bool Status { get; set; }

        public CreateUserCommand(string name,string email,UserRole role,bool status)
        {
           Name = name;
           Email = email;
           Role = role;
           Status = status;
        }
    }
    
}
