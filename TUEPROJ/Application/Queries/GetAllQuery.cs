using MediatR;
using TUEPROJ.Domain;

namespace TUEPROJ.Application.Queries
{
    public class GetAllQuery:IRequest<IEnumerable<User>>
    {
        public int Page { get; }
        public int PageSize { get; }

        public GetAllQuery(int page,int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

    }
}
