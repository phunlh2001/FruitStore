using FastEndpoints;
using FruitStore.Infrastructure.Features.Commands;
using MediatR;

namespace FruitStore.API.Endpoints.Products;

public sealed class DeleteOneById
{
    public sealed class Output
    {
        public string Message { get; set; }
    }

    public sealed class ApiEndpoint(ISender mediator) : EndpointWithoutRequest<Output>
    {
        private readonly ISender _mediator = mediator;
        public override void Configure()
        {
            Delete("api/products/delete/{id}");
            AllowAnonymous();
            Description(d => d.WithTags("Products"));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<Guid>("id");
            var command = new DeleteProductById.Command(id);
            var res = await _mediator.Send(command);

            if (res.IsError)
            {
                return;
            }
            await SendAsync(new Output
            {
                Message = "Delete successfully!"
            });
        }
    }
}
