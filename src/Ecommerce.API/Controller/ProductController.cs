using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Dto;
using Ecommerce.Sharable.Request.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class ProductController(IMediator mediator) 
    : BaseApiController(mediator)
{
    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProductAsync(
        [Required, FromBody] CreateProductRequest request)
            => await SendCommand(request, 201);

    [HttpPost("customize")]
    public async Task<ActionResult<ProductDto>> CustomizeProductAsync(
        [Required, FromBody] CustomizeProductRequest request)
            => await SendCommand(request);
}