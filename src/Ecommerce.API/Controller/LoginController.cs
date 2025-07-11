using System.ComponentModel.DataAnnotations;
using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Requests;
using Ecommerce.Sharable.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class LoginController : BaseApiController
{
    public LoginController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<KeycloakResponse>> Login([Required] LoginRequest request) =>
        await SendCommand(request);
}
