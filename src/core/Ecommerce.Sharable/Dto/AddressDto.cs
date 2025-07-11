using Ecommerce.Sharable.Config;
using System;

namespace Ecommerce.Sharable.Dto;

[SwaggerSchemaName("Endereco")]
public record AddressDto(Guid Id, string ZipCode, string PublicPlace, string Neighborhood, int Number, string Uf) { }