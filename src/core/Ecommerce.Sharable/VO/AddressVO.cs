using Ecommerce.Sharable.Config;
using System;

namespace Ecommerce.Sharable.VO;

[SwaggerSchemaName("Endereco")]
public record AddressVO(Guid Id, string ZipCode, string PublicPlace, string Neighborhood, int Number, string Uf) { }