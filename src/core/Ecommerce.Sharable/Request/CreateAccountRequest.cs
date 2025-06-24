using Ecommerce.Sharable.Contracts;
using MediatR;

namespace Ecommerce.Sharable.Request;

public record CreateAccountRequest(
    string username,
    string email,
    string firstName,
    string lastName,
    IEnumerable<KeycloakCredentials> credentials) : IRequest<Result>;
