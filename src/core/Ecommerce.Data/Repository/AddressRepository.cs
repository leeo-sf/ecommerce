using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Sharable.Enum;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly AppDbContext _appDbContext;

    public AddressRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async Task<Address?> GetAddressByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _appDbContext.Address
            .AsNoTracking()
            .FirstOrDefaultAsync(address => address.Id == id);

    public async Task<bool> AddressAlreadyExistsAsync(string zipCode, string publicPlace, int number, UfEnum uf, CancellationToken cancellationToken)
        => await _appDbContext.Address
            .AsNoTracking()
            .AnyAsync(add => 
                add.ZipCode == zipCode
                && add.PublicPlace == publicPlace
                && add.Number == number
                && add.Uf == uf, cancellationToken);

    public async Task<Address> CreateAddressAsync(Address address, CancellationToken cancellationToken)
    {
        _appDbContext.Address.Add(address);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return address;
    }

    public async Task DeleteAddressAsync(Address address, CancellationToken cancellationToken)
    {
        _appDbContext.Address.Remove(address);
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }
}