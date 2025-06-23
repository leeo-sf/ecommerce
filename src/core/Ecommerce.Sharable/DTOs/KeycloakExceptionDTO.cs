using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ecommerce.Sharable.DTOs;

public class KeycloakExceptionDTO
{
    [JsonPropertyName("error")]
    public string? Error { get; }
    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; }

    public KeycloakExceptionDTO(string error, string errorDescription)
    {
        Error = error;
        ErrorDescription = errorDescription;
    }

    public static KeycloakExceptionDTO GetContentError(string contentKeycloakError)
    {
        return JsonSerializer.Deserialize<KeycloakExceptionDTO>(contentKeycloakError)!;
    }
}
