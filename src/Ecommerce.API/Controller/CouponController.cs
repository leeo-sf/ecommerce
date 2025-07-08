using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Request;
using Ecommerce.Sharable.VO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[ControllerName("cupom")]
public class CouponController : BaseApiController
{
    public CouponController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    public async Task<ActionResult> CreateCouponAsync(
        [Required, FromBody] CreateCouponRequest request)
        => await SendCommand(request, 201);

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CouponVO>> GetCouponByIdAsync(
        [Required, FromRoute] Guid id)
        => await SendCommand(new GetCouponByIdRequest(id));

    [HttpGet]
    public async Task<ActionResult<ICollection<CouponVO>>> GetCouponByIdAsync()
        => await SendCommand(new GetAllCouponRequest());

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CouponVO>> DeleteCouponAsync(
        [Required, FromRoute] Guid id)
        => await SendCommand(new DeleteCouponRequest(id));

    [HttpPut("atualizar")]
    public async Task<ActionResult<CouponVO>> UpdateCouponAsync(
        [Required, FromBody] UpdateCouponRequest request)
        => await SendCommand(request);
}