using System.Text.Json.Serialization;

namespace Ecommerce.Sharable.Responses;

public class KeycloakResponse
{
    public KeycloakResponse(
        string accessToken,
        int expiresIn,
        int refreshExpiresIn,
        string refreshToken,
        string tokenType,
        int notBeforePolicy,
        string sessionState,
        string scope)
    {
        AccessToken = accessToken;
        ExpiresIn = expiresIn;
        RefreshExpiresIn = refreshExpiresIn;
        RefreshToken = refreshToken;
        TokenType = tokenType;
        NotBeforePolicy = notBeforePolicy;
        SessionState = sessionState;
        Scope = scope;
    }

    [JsonPropertyName("access_token")]
    public string AccessToken { get; }
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; }
    [JsonPropertyName("refresh_expires_in")]
    public int RefreshExpiresIn { get; }
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; }
    [JsonPropertyName("token_type")]
    public string TokenType { get; }
    [JsonPropertyName("not-before-policy")]
    public int NotBeforePolicy { get; }
    [JsonPropertyName("session-state")]
    public string SessionState { get; }
    [JsonPropertyName("scope")]
    public string Scope { get; }
}
