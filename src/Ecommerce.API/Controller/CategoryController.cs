﻿using System.ComponentModel.DataAnnotations;
using Asp.Versioning;
using Ecommerce.API.Controller.Base;
using Ecommerce.Sharable.Request;
using Ecommerce.Sharable.VO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[ControllerName("categoria")]
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
        [Required, FromRoute] GetCategoryByIdRequest id) =>
        await SendCommand(id);

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(
        [Required, FromRoute] DeleteCategoryRequest id) =>
        await SendCommand(id);
}
