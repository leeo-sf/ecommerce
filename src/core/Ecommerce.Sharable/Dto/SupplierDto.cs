namespace Ecommerce.Sharable.Dto;

public record SupplierDto
    (Guid Id, string Name, string Cnpj, bool IsActive, List<AddressDto> Addresses) { }