﻿using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Request.Coupon;
using Ecommerce.Sharable.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class CouponController : BaseApiController
{
    public CouponController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    public async Task<ActionResult> CreateCouponAsync(
        [Required, FromBody] CreateCouponRequest request)
        => await SendCommand(request, 201);

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CouponDto>> GetCouponByIdAsync(
        [Required, FromRoute] Guid id)
        => await SendCommand(new GetCouponByIdRequest(id));

    [HttpGet]
    public async Task<ActionResult<ICollection<CouponDto>>> GetCouponByIdAsync()
        => await SendCommand(new GetAllCouponRequest());

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult<CouponDto>> DeleteCouponAsync(
        [Required, FromRoute] Guid id)
        => await SendCommand(new DeleteCouponRequest(id));

    [HttpPut("update")]
    public async Task<ActionResult<CouponDto>> UpdateCouponAsync(
        [Required, FromBody] UpdateCouponRequest request)
        => await SendCommand(request);
}