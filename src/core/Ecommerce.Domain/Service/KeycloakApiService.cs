using Ecommerce.Domain.Api;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.Contracts;
using Ecommerce.Sharable.DTOs;
using Ecommerce.Sharable.Exceptions;
using Ecommerce.Sharable.Request;
using Ecommerce.Sharable.Responses;

namespace Ecommerce.Domain.Service;

public class KeycloakApiService : IKeycloakApiService
{
    private readonly KeycloakClientConfiguration _keycloakConfiguration;
    private readonly IKeycloakApi _keycloakApi;

    public KeycloakApiService(KeycloakClientConfiguration keycloakConfiguration,
        IKeycloakApi keycloakApi)
    {
        _keycloakConfiguration = keycloakConfiguration;
        _keycloakApi = keycloakApi;
    }

    public async Task<Result<KeycloakResponse>> ObterTokenUsuarioAsync(string username, string password)
    {
        var request = KeycloakRequest.CreateFromConfig(_keycloakConfiguration, username, password);
        var response = await _keycloakApi.ObterTokenUsuarioAsync(request);
        return !response.IsSuccessful
            ? new KeycloakException(KeycloakExceptionDTO.GetContentError(response.Error.Content!).ErrorDescription!)
            : response.Content;
    }

    public Task<Result<KeycloakResponse>> ObterTokenClientAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Result> CriarUsuarioAsync(string tokenClient, string username, string email, string firstname, string lastname, IEnumerable<KeycloakCredentials> credentials)
    {
        var requestCreateUser = KeycloakGerarUsuarioRequest.CreateFromConfig(username, email, firstname, lastname, credentials);
        var responseCreateUser = await _keycloakApi.GerarUsuarioAsync(tokenClient, requestCreateUser);

        return !responseCreateUser.IsSuccessful
            ? new Result(new KeycloakException("Falha ao criar usuário."))
            : new Result(true);
    }
}
