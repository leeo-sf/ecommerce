using Ecommerce.Sharable.Config;
using MediatR;

namespace Ecommerce.Sharable.Request.Category;

[SwaggerSchemaName("CriarCategoria")]
public record CategoryRequest : IRequest<Result>
{
    public string Name { get; init; }

    public CategoryRequest(string name) => Name = name.ToUpper();
}
