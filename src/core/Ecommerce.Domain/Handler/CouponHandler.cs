using AutoMapper;
using Ecommerce.Domain.Interface;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Exceptions;
using Ecommerce.Sharable.Request.Coupon;
using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Domain.Handler;

public sealed class CouponHandler
    : IRequestHandler<CreateCouponRequest, Result>,
        IRequestHandler<GetCouponByIdRequest, Result<CouponDto>>,
        IRequestHandler<DeleteCouponRequest, Result>,
        IRequestHandler<UpdateCouponRequest, Result<CouponDto>>,
        IRequestHandler<GetAllCouponRequest, Result<ICollection<CouponDto>>>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IMapper _mapper;

    public CouponHandler(
        ICouponRepository couponRepository,
        IMapper mapper)
    {
        _couponRepository = couponRepository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateCouponRequest request, CancellationToken cancellationToken)
    {
        var couponAlreadyExists = await _couponRepository.AlreadyExistsAsync(request.Code, cancellationToken);
        if (couponAlreadyExists)
            return new(new AppException($"Coupon {request.Code} já existe!"));
        await _couponRepository.CreateCouponAsync(new(Guid.NewGuid(), DateTime.Now, DateTime.Now, request.Code, request.DiscountPercentage, request.ValidUntil), cancellationToken);
        return new(true);
    }

    public async Task<Result<CouponDto>> Handle(GetCouponByIdRequest request, CancellationToken cancellationToken)
    {
        var coupon = await _couponRepository.CouponByIdAsync(request.Id, cancellationToken);

        return coupon is not null
            ? _mapper.Map<CouponDto>(coupon)
            : new KeyNotFoundException("Cupom não encontrado!");
    }

    public async Task<Result> Handle(DeleteCouponRequest request, CancellationToken cancellationToken)
    {
        var coupon = await _couponRepository.CouponByIdAsync(request.Id, cancellationToken);
        if (coupon is null)
            return new(new KeyNotFoundException("Cupom não encontrado!"));
        await _couponRepository.DeleteCouponAsync(coupon, cancellationToken);
        return new(true);
    }

    public async Task<Result<CouponDto>> Handle(UpdateCouponRequest request, CancellationToken cancellationToken)
    {
        var coupon = await _couponRepository.CouponByIdAsync(request.Id, cancellationToken);
        if (coupon is null)
            return new(new KeyNotFoundException("Cupom não encontrado!"));
        var updatedCoupon = await _couponRepository.UpdateCouponAsync(
            coupon with { UpdatedIn = DateTime.Now.ToUniversalTime(), Code = request.Code, DiscountPercentage = request.DiscountPercentage, ValidUntil = request.ValidUntil }, cancellationToken);
        return new(_mapper.Map<CouponDto>(updatedCoupon));
    }

    public async Task<Result<ICollection<CouponDto>>> Handle(GetAllCouponRequest request, CancellationToken cancellationToken)
        => _mapper.Map<List<CouponDto>>(await _couponRepository.GetAllCouponAsync());
}
