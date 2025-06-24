using Ecommerce.Domain.Interfaces;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Exceptions;
using Ecommerce.Sharable.Request;
using MediatR;

namespace Ecommerce.Domain.Handler;

public class CreateAccountRequestHandler : IRequestHandler<CreateAccountRequest, Result>
{
    private IKeycloakApiService _keycloakApiService;

    public CreateAccountRequestHandler(IKeycloakApiService keycloakApiService)
        => _keycloakApiService = keycloakApiService;

    public async Task<Result> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        var responseTokenClient = await _keycloakApiService.ObterTokenClientAsync();

        if (!responseTokenClient.IsSuccess)
            throw new KeycloakException("Falha ao obter token!");

        var responseGeraUsuario = await _keycloakApiService.CriarUsuarioAsync(responseTokenClient.Value.AccessToken, request.username, request.email, request.firstName, request.lastName, request.credentials);
        return responseGeraUsuario;
    }
}
