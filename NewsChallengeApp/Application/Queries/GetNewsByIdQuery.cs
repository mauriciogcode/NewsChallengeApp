using MediatR;
using NewsApi.Domain.Entities;

namespace NewsApi.Application.Queries
{
    public class GetNewsByIdQuery : IRequest<News>
    {
        public int Id { get; set; }
    }
}
