using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ecommerce.Sharable.Dto;

public class KeycloakExceptionDto
{
    [JsonPropertyName("error")]
    public string? Error { get; }

    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; }

    public KeycloakExceptionDto(string error, string errorDescription)
    {
        Error = error;
        ErrorDescription = errorDescription;
    }

    public static KeycloakExceptionDto GetContentError(string contentKeycloakError)
    {
        return JsonSerializer.Deserialize<KeycloakExceptionDto>(contentKeycloakError)!;
    }
}
