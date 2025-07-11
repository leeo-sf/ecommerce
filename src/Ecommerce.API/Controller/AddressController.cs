using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Request.Address;
using Ecommerce.Sharable.VO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class AddressController : BaseApiController
{
    public AddressController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    public async Task<ActionResult<AddressVO>> CreateAddressAsync(
        [Required, FromBody] CreateAddressRequest request)
            => await SendCommand(request, 201);

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> DeleteAddressAsync(
        [Required, FromRoute] Guid id)
            => await SendCommand(new DeleteAddressRequest(id));
}