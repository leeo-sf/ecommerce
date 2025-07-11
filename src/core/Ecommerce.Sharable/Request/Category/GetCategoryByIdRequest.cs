using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Sharable.Request.Category;

[SwaggerSchemaName("CategoriaPorId")]
public record GetCategoryByIdRequest(Guid id) : IRequest<Result<CategoryDto>>;