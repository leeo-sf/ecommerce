using AutoMapper;
using Ecommerce.Domain.Interface;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Exceptions;
using Ecommerce.Sharable.Request.Address;
using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Domain.Handler;

public class AddressHandler
    : IRequestHandler<CreateAddressRequest, Result<AddressDto>>,
        IRequestHandler<DeleteAddressRequest, Result>
{
    private readonly IAddressRepository _addressRepository;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public AddressHandler(
        IAddressRepository addressRepository,
        ISupplierRepository supplierRepository,
        IMapper mapper)
    {
        _addressRepository = addressRepository;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<Result<AddressDto>> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        var addressExists = await _addressRepository.AddressAlreadyExistsAsync
            (request.ZipCode, request.PublicPlace, request.Number, request.Uf, cancellationToken);
        if (addressExists)
            return new AppException("Endereço já cadastrado!");

        var supplier = await _supplierRepository.GetSupplierByIdAsync(request.SupplierId, cancellationToken);
        if (supplier is null)
            return new KeyNotFoundException("Fornecedor não encontrado!");

        var address = await _addressRepository.CreateAddressAsync(
            new(Guid.NewGuid(), DateTime.Now, DateTime.Now, request.ZipCode, request.PublicPlace, request.Neighborhood, request.Number, request.Uf, supplier.id), cancellationToken);
        return _mapper.Map<AddressDto>(address);
    }

    public async Task<Result> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.GetAddressByIdAsync(request.Id, cancellationToken);
        if (address is null)
            return new(new KeyNotFoundException("Endereço não encontrado!"));
        await _addressRepository.DeleteAddressAsync(address, cancellationToken);
        return new(true);
    }
}