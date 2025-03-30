using MediatR;
using NewsApi.Domain.Entities;
using NewsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using NewsApi.Application.Commands;
using System;

namespace NewsApi.Application.Handlers
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Unit>
    {
        private readonly NewsDbContext _context;

        public UpdateNewsCommandHandler(NewsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _context.News
                                     .Where(n => n.Id == request.Id && !n.IsDeleted)
                                     .FirstOrDefaultAsync(cancellationToken);

            if (news == null)
            {
                throw new KeyNotFoundException("News not found");
            }

            news.Title = request.Title;
            news.Body = request.Body;
            news.ImageUrl = request.ImageUrl;
            news.Author = request.Author;
            news.Date = request.Date;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
