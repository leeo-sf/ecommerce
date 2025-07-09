using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Sharable.Request.Category;

[SwaggerSchemaName("CategoriaPorId")]
public record GetCategoryByIdRequest(Guid id) : IRequest<Result<CategoryVO>>;