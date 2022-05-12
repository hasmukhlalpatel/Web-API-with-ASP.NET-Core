using MediatR;

namespace WebApi.Sample.MediatR;

public static class AddEntityCommand
{
    public record Response(int Id);

    public record Command(int Id, string Discription) : IRequest<Response>;

    public class Handler : IRequestHandler<Command, Response>
    {
        public Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Response(request.Id));
        }
    }
}