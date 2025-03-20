using MediatR;
using System.Linq.Expressions;
using TUEPROJ.Application.Commands;
using TUEPROJ.Domain;
using TUEPROJ.Domain.Enums;
using TUEPROJ.Infrastructure;

namespace TUEPROJ.Application.Command_Handler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)

        {
            try
            {
                if (!Enum.IsDefined(typeof(UserRole), request.Role))
                {
                    throw new ArgumentException("Invalid Role Value");
                }

                var user = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    Role = request.Role,
                    Status = request.Status,
                };

                return await _userRepository.AddUserAsync(user);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                throw;
            }




        }

    }
}
