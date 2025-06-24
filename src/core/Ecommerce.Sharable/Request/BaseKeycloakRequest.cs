using Ecommerce.Sharable.Config;
using Refit;

namespace Ecommerce.Sharable.Request;

public record BaseKeycloakRequest
{
    [property: AliasAs("grant_type")] string GrantType { get; }
    [property: AliasAs("client_id")] string ClientId { get; }
    [property: AliasAs("client_secret")] string ClientSecret { get; }

    protected BaseKeycloakRequest(string clientId, string clientSecret)
    {
        GrantType = "client_credentials";
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    protected BaseKeycloakRequest(string grantType, string clientId, string clientSecret)
    {
        GrantType = grantType;
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    public static BaseKeycloakRequest CreateFromConfig(KeycloakClientConfiguration config)
        => new(config.ClientId, config.ClientSecret);
}
