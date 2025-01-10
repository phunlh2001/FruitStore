using FastEndpoints;
using FruitStore.Application.DTOs;
using FruitStore.Infrastructure.Features.Commands;
using MediatR;

namespace FruitStore.API.Endpoints.Products;

public sealed class AddNew
{
    public sealed class Input
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public CategoryRequest Category { get; set; }
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
            Post("/api/products/create");
            AllowAnonymous();
            Description(t => t.WithTags("Products"));
        }

        public override async Task HandleAsync(Input req, CancellationToken ct)
        {
            var command = new CreateProduct.Command(req.Name, req.Price, req.Description, req.Category);
            var prod = await _mediator.Send(command);

            await SendAsync(new Output
            {
                Message = "Create successfully!",
                Info = prod
            }, 201);
        }
    }
}
