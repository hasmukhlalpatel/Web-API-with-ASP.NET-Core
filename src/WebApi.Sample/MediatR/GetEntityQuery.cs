using MediatR;

namespace WebApi.Sample.MediatR
{
    public static class GetEntityQuery
    {

        public record Query : IRequest<Response>
        {
            public int Id { get; set; }
        }

        public record Response(int Id, string Description) : IRequest<Response>;

        public class Handler : IRequestHandler<Query, Response>
        {
            public Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new Response(request.Id, "Test from MediatR"));
            }
        }
    }
    
}
