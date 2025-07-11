using Ecommerce.Domain.Entity;
using Ecommerce.Sharable.Enum;

namespace Ecommerce.Domain.Interface;

public interface IAddressRepository
{
    Task<Address?> GetAddressByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> AddressAlreadyExistsAsync(string zipCode, string publicPlace, int number, UfEnum uf, CancellationToken cancellationToken);
    Task<Address> CreateAddressAsync(Address address, CancellationToken cancellationToken);
    Task DeleteAddressAsync(Address address, CancellationToken cancellationToken);
}