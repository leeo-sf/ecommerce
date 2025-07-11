using Ecommerce.Sharable.Enum;
using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Sharable.Request.Address;

public record CreateAddressRequest : IRequest<Result<AddressDto>>
{
    public string ZipCode { get; }
    public string PublicPlace { get; }
    public string Neighborhood { get; }
    public int Number { get; }
    public UfEnum Uf { get; }
    public Guid SupplierId { get; set; }

    public CreateAddressRequest(
        string zipCode, string publicPlace, string neighborhood, int number, UfEnum uf, Guid supplierId)
    {
        ZipCode = zipCode;
        PublicPlace = publicPlace.ToUpper();
        Neighborhood = neighborhood.ToUpper();
        Number = number;
        Uf = uf;
        SupplierId = supplierId;
    }
};