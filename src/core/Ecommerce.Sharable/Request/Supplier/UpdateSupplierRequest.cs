using MediatR;

namespace Ecommerce.Sharable.Request.Supplier;

public record UpdateSupplierRequest : IRequest<Result>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Cnpj { get; init; }
    public bool IsActive { get; init; } = true;

    public UpdateSupplierRequest(
        Guid id, string name, string cnpj, bool isActive)
    {
        Id = id;
        Name = name.ToUpper();
        Cnpj = cnpj;
        IsActive = isActive;
    }
}