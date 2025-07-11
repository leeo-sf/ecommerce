using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Request.Address;
using Ecommerce.Sharable.Request.Supplier;
using Ecommerce.Sharable.VO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class SupplierController : BaseApiController
{
    public SupplierController(IMediator mediator)
        : base(mediator) { }

    [HttpGet]
    public async Task<ActionResult<ICollection<SupplierVO>>> GetSuppliersAsync()
        => await SendCommand(new GetSuppliersRequest());

    [HttpPost]
    public async Task<ActionResult<SupplierVO>> CreateSupplierAsync(
        [Required, FromBody] CreateSupplierRequest request)
            => await SendCommand(request, 201);

    [HttpPut("update")]
    public async Task<ActionResult> UpdateSupplierAsync(
        [Required, FromBody] UpdateSupplierRequest request)
            => await SendCommand(request);
}