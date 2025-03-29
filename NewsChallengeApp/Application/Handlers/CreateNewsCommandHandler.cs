using MediatR;
using NewsApi.Application.Commands;
using NewsApi.Domain.Entities;
using NewsApi.Infrastructure.Persistence;

namespace NewsApi.Application.Handlers
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, int>
    {
        private readonly NewsDbContext _context;

        public CreateNewsCommandHandler(NewsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new News
            {
                Title = request.Title,
                Body = request.Body,
                ImageUrl = request.ImageUrl,
                Author = request.Author,
                Date = request.Date
            };

            _context.News.Add(news);
            await _context.SaveChangesAsync(cancellationToken);
            return news.Id;
        }
    }
}
