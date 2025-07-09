using Ecommerce.Sharable.Config;
using MediatR;

namespace Ecommerce.Sharable.Request.Category;

[SwaggerSchemaName("DeletarCategoria")]
public record class DeleteCategoryRequest(Guid id) : IRequest<Result>;