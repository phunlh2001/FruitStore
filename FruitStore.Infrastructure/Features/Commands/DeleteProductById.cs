using ErrorOr;
using FruitStore.Application.Contracts.Product;
using FruitStore.Application.DTOs;
using MediatR;

namespace FruitStore.Infrastructure.Features.Commands;

public static class DeleteProductById
{
    public sealed record Command(Guid id) : IRequest<ErrorOr<EmptyResponse>>;
    public sealed class Handler(IProductRepository repo) : IRequestHandler<Command, ErrorOr<EmptyResponse>>
    {
        private readonly IProductRepository _repo = repo;
        public async Task<ErrorOr<EmptyResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            var res = await _repo.DeleteProductAsync(request.id);
            if (res.IsError)
            {
                return res.Errors[0];
            }

            return res.Value;
        }
    }
}
