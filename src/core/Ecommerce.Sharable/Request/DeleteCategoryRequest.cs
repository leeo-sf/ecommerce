using Ecommerce.Sharable.Config;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Sharable.Request;

[SwaggerSchemaName("DeletarCategoria")]
public record class DeleteCategoryRequest([FromHeader] Guid id) : IRequest<Result>;