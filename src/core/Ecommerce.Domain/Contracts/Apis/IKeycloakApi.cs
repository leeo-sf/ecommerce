using Ecommerce.Sharable.Request;
using Ecommerce.Sharable.Responses;
using Refit;

namespace Ecommerce.Domain.Contracts.Apis;

public interface IKeycloakApi
{
    [Post("/realms/ecommerce_services/protocol/openid-connect/token")]
    Task<ApiResponse<KeycloakResponse>> ObterTokenAsync(
        [Body(BodySerializationMethod.UrlEncoded)] KeycloakRequest request
    );
}
