using Ecommerce.Sharable.Responses;
using MediatR;

namespace Ecommerce.Sharable.Requests;

public record LoginRequest(
    string email,
    string password) : IRequest<Result<KeycloakResponse>>;
