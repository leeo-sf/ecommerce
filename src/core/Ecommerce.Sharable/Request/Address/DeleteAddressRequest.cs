using MediatR;

namespace Ecommerce.Sharable.Request.Address;

public record DeleteAddressRequest(Guid Id) : IRequest<Result>;