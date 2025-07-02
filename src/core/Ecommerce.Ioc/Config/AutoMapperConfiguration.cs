using AutoMapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Sharable.VO;

namespace Ecommerce.Infra.Ioc.Config;

public static class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMaps()
    {
        return new MapperConfiguration(config =>
        {
            config.CreateMap<Category, CategoryVO>();
        });
    }
}
