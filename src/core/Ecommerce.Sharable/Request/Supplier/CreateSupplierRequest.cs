using Ecommerce.Sharable.Request.Address;
using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Sharable.Request.Supplier;

public record CreateSupplierRequest : IRequest<Result<SupplierDto>>
{
    public string Name { get; init; }
    public string Cnpj { get; init; }
    public bool IsActive { get; init; } = true;
    public CreateAddressRequest Address { get; init; }

    public CreateSupplierRequest(
        string name, string cnpj, bool isActive, CreateAddressRequest address)
    {
        Name = name.ToUpper();
        Cnpj = cnpj;
        IsActive = isActive;
        Address = address;
    }
}