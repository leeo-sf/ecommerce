using Ecommerce.Sharable.Config;

namespace Ecommerce.Sharable.Dto;

[SwaggerSchemaName("Categoria")]
public record CategoryDto(Guid Id, string Name) { }