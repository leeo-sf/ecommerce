using Ecommerce.Sharable.Contracts;
using Refit;

namespace Ecommerce.Sharable.Request;

public record KeycloakGerarUsuarioRequest(
    [property: AliasAs("username")] string username,
    [property: AliasAs("email")] string email,
    [property: AliasAs("firstName")] string firstName,
    [property: AliasAs("lastName")] string lastName,
    [property: AliasAs("credentials")] IEnumerable<KeycloakCredentials> credentials)
    //string userName,
    //string email,
    //string firstName,
    //string lastName,
    //IEnumerable<KeycloakCredentials> credentials)
{
    public static KeycloakGerarUsuarioRequest CreateFromConfig(string username, string email, string firstname, string lastname, IEnumerable<KeycloakCredentials> credentials)
        => new(username, email, firstname, lastname, credentials);
}