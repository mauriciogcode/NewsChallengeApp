using MediatR;
using NewsApi.Domain.Entities;
using NewsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using NewsApi.Application.Commands;

namespace NewsApi.Application.Handlers
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, Unit>
    {
        private readonly NewsDbContext _context;

        public DeleteNewsCommandHandler(NewsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _context.News
                                     .Where(n => n.Id == request.Id && !n.IsDeleted)
                                     .FirstOrDefaultAsync(cancellationToken);

            if (news != null)
            {
                news.IsDeleted = true; // O _context.News.Remove(news); para eliminación física
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}