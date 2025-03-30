using MediatR;
using NewsApi.Domain.Entities;

namespace NewsApi.Application.Queries
{
    public class GetNewsListQuery : IRequest<List<News>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool OrderByDescending { get; set; } = true;
    }
}
