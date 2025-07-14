using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Dto;
using Ecommerce.Sharable.Request.Promotion;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class PromotionController(IMediator mediator) 
    : BaseApiController(mediator)
{
    [HttpPost]
    public async Task<ActionResult<PromotionDto>> CreatePromotionAsync(
        [Required, FromBody] CreatePromotionRequest request)
            => await SendCommand(request, 201);
}