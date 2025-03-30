using MediatR;

namespace NewsApi.Application.Commands
{
    public class DeleteNewsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
