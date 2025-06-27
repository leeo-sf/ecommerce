using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.VO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Sharable.Request;

[SwaggerSchemaName("CategoriaPorId")]
public record GetCategoryByIdRequest([FromRoute] Guid id) : IRequest<Result<CategoryVO>>;