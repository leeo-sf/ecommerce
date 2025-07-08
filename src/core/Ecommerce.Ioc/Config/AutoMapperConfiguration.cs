using AutoMapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Sharable.Request;
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
                .ForMember(c => c.ValidUntil,
                map => map.MapFrom(x => x.ValidUntil.HasValue ? x.ValidUntil.Value.ToString() : null))
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            config.CreateMap<UpdateCouponRequest, Coupon>();
        });
    }
}
