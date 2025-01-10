using FastEndpoints;
using FruitStore.Application.DTOs;
using FruitStore.Infrastructure.Features.Queries;
using MediatR;

namespace FruitStore.API.Endpoints.Categories;

public sealed class GetCategoryList
{
    public sealed class Output
    {
        public string Message { get; set; }
        public List<CategoryResponse> Info { get; set; }
    }

    public sealed class ApiEndpoint(ISender mediator) : EndpointWithoutRequest<Output>
    {
        private readonly ISender _mediator = mediator;
        public override void Configure()
        {
            Get("api/categories");
            AllowAnonymous();
            Description(d => d.WithTags("Category"));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var query = new GetAllCategory.Query();
            var res = await _mediator.Send(query);

            await SendAsync(new Output
            {
                Message = "Get list category successfully!",
                Info = res
            });
        }
    }
}
