using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Sharable.Request;

public record QueryCategoriesRequest() : IRequest<Result<ICollection<CategoryVO>>> { }
