using Ecommerce.Sharable.Dto;
using Ecommerce.Sharable.Enum;
using MediatR;

namespace Ecommerce.Sharable.Request.Product;

public record CreateProductRequest(string Name, string Description, ColorEnum Color, ICollection<string> ImagesUrl,
    double Price, int QuantityInStock, Guid SupplierId, Guid CategoryId) : IRequest<Result<ProductDto>>;