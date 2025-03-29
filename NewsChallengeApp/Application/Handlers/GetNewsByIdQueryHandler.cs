using MediatR;
using NewsApi.Domain.Entities;
using NewsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using NewsApi.Application.Queries;

namespace NewsApi.Application.Handlers
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, News>
    {
        private readonly NewsDbContext _context;

        public GetNewsByIdQueryHandler(NewsDbContext context)
        {
            _context = context;
        }

        public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.News
                                 .Where(n => n.Id == request.Id && !n.IsDeleted)
                                 .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
