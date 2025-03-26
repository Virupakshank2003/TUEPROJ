using MediatR;
using TUEPROJ.Application.DTOs;
using TUEPROJ.Domain;

namespace TUEPROJ.Application.Queries
{
    public class GetUsersQuery:IRequest<PaginatedUserResponse>
    {
        public int Page { get; }
        public int PageSize { get; }

        public string? SearchTerm { get; }

        public GetUsersQuery(int page,int pageSize, string? searchTerm=null)
        {
            Page = page;
            PageSize = pageSize;
            SearchTerm = searchTerm;
        }

    }
}
