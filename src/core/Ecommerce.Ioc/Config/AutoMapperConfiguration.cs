using AutoMapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Sharable.Request.Coupon;
using Ecommerce.Sharable.VO;

namespace Ecommerce.Infra.Ioc.Config;

public static class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMaps()
    {
        return new MapperConfiguration(config =>
        {
            config.CreateMap<Category, CategoryVO>();
            config.CreateMap<Coupon, CouponVO>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            config.CreateMap<UpdateCouponRequest, Coupon>();
            config.CreateMap<DateTime?, DateOnly?>()
                .ConvertUsing(src => 
                    src.HasValue
                        ? DateOnly.FromDateTime(src.Value)
                        : null);
        });
    }
}
