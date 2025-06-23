using Ecommerce.Sharable.Config;
using Refit;

namespace Ecommerce.Sharable.Request;

public record KeycloakRequest(
    [property: AliasAs("grant_type")] string GrantType,
    [property: AliasAs("client_id")] string ClientId,
    [property: AliasAs("client_secret")] string ClientSecret,
    [property: AliasAs("username")] string Username,
    [property: AliasAs("password")] string Password)
{
    public static KeycloakRequest CreateFromConfig(KeycloakClientConfiguration config, string username, string password)
        => new(config.GrantType, config.ClientId, config.ClientSecret, username, password);
}
