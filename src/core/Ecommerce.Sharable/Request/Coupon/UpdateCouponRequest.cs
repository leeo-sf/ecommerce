using Ecommerce.Sharable.Config;
using Ecommerce.Sharable.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Sharable.Request.Coupon;

[SwaggerSchemaName("AtualizarCupom")]
public record UpdateCouponRequest : IRequest<Result<CouponDto>>
{
    public Guid Id { get; init; }
    public string Code { get; init; }
    public float DiscountPercentage { get; init; }
    [DataType(DataType.Date)]
    public DateTime? ValidUntil { get; init; }
    public DateTime UpdatedIn { get; }

    public UpdateCouponRequest(Guid id, string code, float discountPercentage, DateTime? validUntil)
    {
        Id = id;
        Code = code.ToUpper();
        DiscountPercentage = discountPercentage / 100;
        ValidUntil = validUntil?.Date.Add(DateTime.Now.TimeOfDay).ToUniversalTime();
        UpdatedIn = DateTime.Now.ToUniversalTime();
    }
}