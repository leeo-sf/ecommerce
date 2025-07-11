using Ecommerce.Sharable.VO;
using MediatR;

namespace Ecommerce.Sharable.Request.Supplier;

public record GetSuppliersRequest() : IRequest<Result<ICollection<SupplierVO>>>;