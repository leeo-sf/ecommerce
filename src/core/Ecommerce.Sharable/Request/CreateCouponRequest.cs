using Ecommerce.Sharable.Config;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Sharable.Request;

[SwaggerSchemaName("CriarCupom")]
public record CreateCouponRequest : IRequest<Result>
{
    public string Code { get; init; }
    public float DiscountPercentage { get; init; }
    [DataType(DataType.Date)]
    public DateTime? ValidUntil { get; init; }

    public CreateCouponRequest(string code, float discountPercentage, DateTime? validUntil)
    {
        Code = code.ToUpper();
        DiscountPercentage = discountPercentage / 100;
        ValidUntil = validUntil?.Date.Add(DateTime.Now.TimeOfDay).ToUniversalTime();
    }
}