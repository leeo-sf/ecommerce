using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Api;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.DTOs;
using Ecommerce.Sharable.Exceptions;
using Ecommerce.Sharable.Request;
using Ecommerce.Sharable.Responses;

namespace Ecommerce.Application.Service;

public class KeycloakApiService : IKeycloakApiService
{
    private readonly KeycloakClientConfiguration _keycloakConfiguration;
    private readonly IKeycloakApi _keycloakApi;

    public KeycloakApiService(
        KeycloakClientConfiguration keycloakConfiguration,
        IKeycloakApi keycloakApi
    )
    {
        _keycloakConfiguration = keycloakConfiguration;
        _keycloakApi = keycloakApi;
    }

    public async Task<Result<KeycloakResponse>> ObterTokenAsync(string username, string password)
    {
        var request = KeycloakRequest.CreateFromConfig(_keycloakConfiguration, username, password);
        var response = await _keycloakApi.ObterTokenAsync(request);
        return !response.IsSuccessful
            ? new KeycloakException("Credenciais inválidas!")
            : response.Content;
    }
}
