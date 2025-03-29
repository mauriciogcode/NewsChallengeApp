using MediatR;
using NewsApi.Domain.Entities;

namespace NewsApi.Application.Commands
{
    public class UpdateNewsCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
