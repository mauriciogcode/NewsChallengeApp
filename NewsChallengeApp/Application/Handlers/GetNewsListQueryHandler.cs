using MediatR;
using NewsApi.Domain.Entities;
using NewsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using NewsApi.Application.Queries;

namespace NewsApi.Application.Handlers
{
    public class GetNewsListQueryHandler : IRequestHandler<GetNewsListQuery, List<News>>
    {
        private readonly NewsDbContext _context;

        public GetNewsListQueryHandler(NewsDbContext context)
        {
            _context = context;
        }

        public async Task<List<News>> Handle(GetNewsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.News
                                 .Where(n => !n.IsDeleted)
                                 .Skip((request.PageNumber - 1) * request.PageSize)
                                 .Take(request.PageSize)
                                 .ToListAsync(cancellationToken);
        }
    }
}
