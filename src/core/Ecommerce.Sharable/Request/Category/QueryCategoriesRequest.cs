using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Sharable.Request.Category;

public record QueryCategoriesRequest() : IRequest<Result<ICollection<CategoryVO>>> { }
