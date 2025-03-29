using MediatR;

namespace NewsApi.Application.Commands
{
    public class DeleteNewsCommand : IRequest
    {
        public int Id { get; set; }
    }
}
