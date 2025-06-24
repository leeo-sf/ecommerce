using System.Text.Json.Serialization;

namespace Ecommerce.Sharable.Contracts;

public class KeycloakCredentials(
    string value)
{
    [JsonPropertyName("type")]
    public string Type { get; } = "password";
    [JsonPropertyName("value")]
    public string Password { get; } = value;
}
