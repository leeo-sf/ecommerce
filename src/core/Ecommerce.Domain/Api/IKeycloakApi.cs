using Ecommerce.Sharable;
using Ecommerce.Sharable.Request;
using Ecommerce.Sharable.Responses;
using Refit;

namespace Ecommerce.Domain.Api;

public interface IKeycloakApi
{
    [Post("/realms/ecommerce_services/protocol/openid-connect/token")]
    Task<ApiResponse<KeycloakResponse>> ObterTokenUsuarioAsync(
        [Body(BodySerializationMethod.UrlEncoded)] KeycloakRequest request);

    [Post("/realms/ecommerce_services/protocol/openid-connect/token")]
    Task<ApiResponse<KeycloakResponse>> ObterTokenClientAsync(
        [Body(BodySerializationMethod.UrlEncoded)] BaseKeycloakRequest request);

    [Post("/admin/realms/ecommerce_services/users")]
    Task<ApiResponse<Result>> GerarUsuarioAsync(
        [Header("Authorization: Bearer ")] string token,
        [Body] KeycloakGerarUsuarioRequest request);
}