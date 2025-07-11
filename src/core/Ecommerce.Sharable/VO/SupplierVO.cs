namespace Ecommerce.Sharable.VO;

public record SupplierVO
    (Guid Id, string Name, string Cnpj, bool IsActive, List<AddressVO> Addresses) { }