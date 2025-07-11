using System.ComponentModel.DataAnnotations;
using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Request;
using Ecommerce.Sharable.Request.Category;
using Ecommerce.Sharable.VO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class CategoryController : BaseApiController
{
    public CategoryController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    public async Task<ActionResult> Create(
        [Required, FromBody] CategoryRequest request) =>
        await SendCommand(request, 201);

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<CategoryVO>>> List() =>
        await SendCommand(new QueryCategoriesRequest());

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult<CategoryVO>> GetById(
        [Required, FromRoute] Guid id) =>
        await SendCommand(new GetCategoryByIdRequest(id));

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(
        [Required, FromRoute] Guid id) =>
        await SendCommand(new DeleteCategoryRequest(id));
}
