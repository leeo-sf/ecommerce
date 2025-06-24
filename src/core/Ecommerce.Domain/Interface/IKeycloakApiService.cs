using Ecommerce.Sharable;
using Ecommerce.Sharable.Contracts;
using Ecommerce.Sharable.DTOs;
using Ecommerce.Sharable.Requests;
using Ecommerce.Sharable.Responses;

namespace Ecommerce.Domain.Interfaces;

public interface IKeycloakApiService
{
    Task<Result<KeycloakResponse>> ObterTokenUsuarioAsync(string username, string password);
    Task<Result<KeycloakResponse>> ObterTokenClientAsync();
    Task<Result> CriarUsuarioAsync(string tokenClient, string username, string email, string firstname, string lastname, IEnumerable<KeycloakCredentials> credentials);
}