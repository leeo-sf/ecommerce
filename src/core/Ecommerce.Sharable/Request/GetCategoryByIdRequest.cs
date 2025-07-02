using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Sharable.Request;

[SwaggerSchemaName("CategoriaPorId")]
public record GetCategoryByIdRequest(Guid id) : IRequest<Result<CategoryVO>>;