using FastEndpoints;
using FruitStore.Application.DTOs;
using FruitStore.Infrastructure.Features.Commands;
using MediatR;

namespace FruitStore.API.Endpoints.Products;

public sealed class UpdateById
{
    public sealed class Input
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public CategoryRequest Category { get; set; }
    }

    public sealed class Output
    {
        public string Message { get; set; }
    }

    public sealed class ApiEndpoint(ISender mediator) : Endpoint<Input, Output>
    {
        private readonly ISender _mediator = mediator;
        public override void Configure()
        {
            Put("/api/products/update/{id}");
            AllowAnonymous();
            Description(t => t.WithTags("Products"));
        }

        public override async Task HandleAsync(Input req, CancellationToken ct)
        {
            var command = new UpdateProductById.Command(req.Id, req.Name, req.Price, req.Description, req.Category);
            await _mediator.Send(command);

            await SendAsync(new Output
            {
                Message = "Update successfully!"
            });
        }
    }
}
