using MediatR;
using System.Security.Principal;
using TUEPROJ.Domain;

namespace TUEPROJ.Application.Queries
{
    public class GetUserByIdQuery:IRequest<User>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
       
    }
}
