using FastEndpoints;
using FruitStore.Application.DTOs;
using FruitStore.Infrastructure.Features.Queries;
using MediatR;

namespace FruitStore.API.Endpoints.Products;

public sealed class GetOneById
{
    public sealed class Input
    {
        public Guid Id { get; set; }
    }
    public sealed class Output
    {
        public string Message { get; set; }
        public ProductResponse Info { get; set; }
    }
    public sealed class ApiEndpoint(ISender mediator) : Endpoint<Input, Output>
    {
        private readonly ISender _mediator = mediator;
        public override void Configure()
        {
            Get("/api/products/{id}");
            AllowAnonymous();
            Description(d => d.WithTags("Products"));
        }

        public override async Task HandleAsync(Input request, CancellationToken ct)
        {
            var query = new GetOneProductById.Query(request.Id);
            var res = await _mediator.Send(query);

            await SendAsync(new Output
            {
                Message = "Get one product successfully!",
                Info = res
            });
        }
    }
}
