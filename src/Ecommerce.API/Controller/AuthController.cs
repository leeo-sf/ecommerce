using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Request;
using Ecommerce.Sharable.Requests;
using Ecommerce.Sharable.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ControllerName("auth")]
[ApiVersion("1.0")]
public class AuthController : BaseApiController
{
    public AuthController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<KeycloakResponse>> Login(
        [Required] LoginRequest request)
        => await SendCommand(request);

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> CreateAccount(
        [FromBody, Required] CreateAccountRequest request)
        => await SendCommand(request);
}
