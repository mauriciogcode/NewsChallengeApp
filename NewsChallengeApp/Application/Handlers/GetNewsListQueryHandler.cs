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
            // Query base filtrada por noticias no eliminadas
            var query = _context.News.Where(n => !n.IsDeleted);

            // Aplicar ordenamiento (por defecto es descendente por fecha)
            if (request.OrderByDescending)
            {
                query = query.OrderByDescending(n => n.Date);
            }
            else
            {
                query = query.OrderBy(n => n.Date);
            }

            // Aplicar paginado
            return await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
        }
    }
}