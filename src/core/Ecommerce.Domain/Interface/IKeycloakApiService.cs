using Ecommerce.Sharable;
using Ecommerce.Sharable.Responses;

namespace Ecommerce.Domain.Interfaces;

public interface IKeycloakApiService
{
    Task<Result<KeycloakResponse>> ObterTokenAsync(string username, string password);
}
