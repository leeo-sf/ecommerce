using AutoMapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Sharable.Dto;

namespace Ecommerce.Infra.Ioc.Config;

public static class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMaps()
    {
        return new MapperConfiguration(config =>
        {
            config.CreateMap<Category, CategoryDto>();
            config.CreateMap<Coupon, CouponDto>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            config.CreateMap<Address, AddressDto>();
            config.CreateMap<Supplier, SupplierDto>();

            config.CreateMap<DateTime?, DateOnly?>().ConvertUsing(src => src.HasValue 
                ? DateOnly.FromDateTime(src.Value)
                : null);
        });
    }
}
