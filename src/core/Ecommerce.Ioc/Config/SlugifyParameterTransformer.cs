using Microsoft.AspNetCore.Routing;

namespace Ecommerce.Ioc.Config;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
        => value?.ToString()?.ToLowerInvariant();
}