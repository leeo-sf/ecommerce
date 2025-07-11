using AutoMapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Exceptions;
using Ecommerce.Sharable.Request.Supplier;
using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Domain.Handler;

public class SupplierHandler
    : IRequestHandler<CreateSupplierRequest, Result<SupplierVO>>,
        IRequestHandler<UpdateSupplierRequest, Result>,
        IRequestHandler<GetSuppliersRequest, Result<ICollection<SupplierVO>>>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;
    private const string SUPPLIER_ALREADY_REGISTERED = "CNPJ já cadastrado!";

    public SupplierHandler(
        ISupplierRepository supplierRepository,
        IAddressRepository addressRepository,
        IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<Result<SupplierVO>> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplierAlreadyExists = await _supplierRepository.SupplierAlreadyExistsAsync(s => s.Cnpj == request.Cnpj, cancellationToken);
        if (supplierAlreadyExists)
            return new AppException(SUPPLIER_ALREADY_REGISTERED);

        var addressAlreadyExists = await _addressRepository.AddressAlreadyExistsAsync
            (request.Address.ZipCode, request.Address.PublicPlace, request.Address.Number, request.Address.Uf, cancellationToken);
        if (addressAlreadyExists)
            return new AppException($"Endereço já cadastrado!");

        var supplierId = Guid.NewGuid();
        var supplier = await _supplierRepository.CreateSupplierAsync(
            new(supplierId, DateTime.Now, DateTime.Now, request.Name, request.Cnpj, request.IsActive)
            { Addresses = new List<Address> { new(Guid.NewGuid(), DateTime.Now, DateTime.Now, request.Address.ZipCode, request.Address.PublicPlace, request.Address.Neighborhood, request.Address.Number, request.Address.Uf, supplierId) } }, cancellationToken);
        return _mapper.Map<SupplierVO>(supplier);
    }

    public async Task<Result> Handle(UpdateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplierAlreadyExists = await _supplierRepository.SupplierAlreadyExistsAsync(
            s => s.Cnpj == request.Cnpj && s.Id != request.Id, cancellationToken);
        if (supplierAlreadyExists)
            return new(new AppException(SUPPLIER_ALREADY_REGISTERED));

        var supplier = await _supplierRepository.GetSupplierByIdAsync(request.Id, cancellationToken);
        if (supplier is null)
            return new(new KeyNotFoundException($"Id não encontrado!"));

        await _supplierRepository.UpdateSupplierAsync(
            supplier with { UpdatedIn = DateTime.Now.ToUniversalTime(), Name = request.Name, Cnpj = request.Cnpj, IsActive = request.IsActive }, cancellationToken);
        return new(true);
    }

    public async Task<Result<ICollection<SupplierVO>>> Handle(GetSuppliersRequest request, CancellationToken cancellationToken)
        => _mapper.Map<List<SupplierVO>>(
            await _supplierRepository.GetSuppliersAsync(cancellationToken));
}