using MediatR;
using TUEPROJ.Domain;

namespace TUEPROJ.Application.Queries
{
    public class SearchUserQuery:IRequest<IEnumerable<User>>
    {
        public string SearchTerm { get; }

        public SearchUserQuery(string searchTerm)
        {
               SearchTerm = searchTerm; 
        }
    }
}
