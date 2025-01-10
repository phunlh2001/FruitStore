﻿using FastEndpoints;
using FruitStore.Application.DTOs;
using FruitStore.Infrastructure.Features.Queries;
using MediatR;

namespace FruitStore.API.Endpoints.Products;

public sealed class GetList
{
    public sealed class Output
    {
        public string Message { get; set; }
        public List<ProductResponse> Info { get; set; }
    }

    public sealed class ApiEndpoint(ISender mediator) : EndpointWithoutRequest<Output>
    {
        private readonly ISender _mediator = mediator;
        public override void Configure()
        {
            Get("/api/products/list");
            AllowAnonymous();
            Description(d => d.WithTags("Products"));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var query = new GetProductList.Query();
            var res = await _mediator.Send(query);

            await SendAsync(new Output
            {
                Message = "Get list successfully!",
                Info = res
            });
        }
    }
}
