using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Sharable.Request.Supplier;

public record GetSuppliersRequest() : IRequest<Result<ICollection<SupplierDto>>>;