using Ecommerce.Domain.Interfaces;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Requests;
using Ecommerce.Sharable.Responses;
using MediatR;

namespace Ecommerce.Domain.Handler;

public class LoginRequestHandler : IRequestHandler<LoginRequest, Result<KeycloakResponse>>
{
    private readonly IKeycloakApiService _keycloakApiService;

    public LoginRequestHandler(IKeycloakApiService keycloakApiService) =>
        _keycloakApiService = keycloakApiService;

    public async Task<Result<KeycloakResponse>> Handle(
        LoginRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await _keycloakApiService.ObterTokenAsync(
            request.username,
            request.password
        );
        return response;
    }
}
