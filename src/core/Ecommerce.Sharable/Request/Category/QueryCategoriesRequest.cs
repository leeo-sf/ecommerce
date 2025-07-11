using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Sharable.Request.Category;

public record QueryCategoriesRequest() : IRequest<Result<ICollection<CategoryDto>>> { }
