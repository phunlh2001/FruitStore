using FastEndpoints;
using FruitStore.Application.DTOs;
using MediatR;

namespace FruitStore.API.Endpoints.Products
{
    public class CreateProduct(IMediator mediator) : Endpoint<CreateProductRequest, ProductResponse>
    {
        private readonly IMediator _mediator = mediator;
        public override void Configure()
        {
            Post("/api/products/create");
            AllowAnonymous();
            Description(t => t.WithTags("Products"));
        }

        public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
        {
            var prod = await _mediator.Send(req, ct);

            await SendAsync(prod, 201);
        }
    }
}
