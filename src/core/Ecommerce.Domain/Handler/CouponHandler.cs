using AutoMapper;
using Ecommerce.Domain.Interface;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Exceptions;
using Ecommerce.Sharable.Request;
using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Domain.Handler;

public sealed class CouponHandler
    : IRequestHandler<CreateCouponRequest, Result>,
        IRequestHandler<GetCouponByIdRequest, Result<CouponVO>>,
        IRequestHandler<DeleteCouponRequest, Result>,
        IRequestHandler<UpdateCouponRequest, Result<CouponVO>>,
        IRequestHandler<GetAllCouponRequest, Result<ICollection<CouponVO>>>
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

    public async Task<Result<CouponVO>> Handle(GetCouponByIdRequest request, CancellationToken cancellationToken)
    {
        var coupon = await _couponRepository.CouponByIdAsync(request.Id, cancellationToken);

        return coupon is not null
            ? _mapper.Map<CouponVO>(coupon)
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

    public async Task<Result<CouponVO>> Handle(UpdateCouponRequest request, CancellationToken cancellationToken)
    {
        var coupon = await _couponRepository.CouponByIdAsync(request.Id, cancellationToken);
        if (coupon is null)
            return new(new KeyNotFoundException("Cupom não encontrado!"));
        var updatedCoupon = await _couponRepository.UpdateCouponAsync(_mapper.Map(request, coupon), cancellationToken);
        return new(_mapper.Map<CouponVO>(updatedCoupon));
    }

    public async Task<Result<ICollection<CouponVO>>> Handle(GetAllCouponRequest request, CancellationToken cancellationToken)
        => _mapper.Map<List<CouponVO>>(await _couponRepository.GetAllCouponAsync());
}
