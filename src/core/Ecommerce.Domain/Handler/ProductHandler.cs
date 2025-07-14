using AutoMapper;
using Ecommerce.Domain.Interface;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Dto;
using Ecommerce.Sharable.Extensions;
using Ecommerce.Sharable.Request.Product;
using MediatR;

namespace Ecommerce.Domain.Handler;

public class ProductHandler
    : IRequestHandler<CreateProductRequest, Result<ProductDto>>,
        IRequestHandler<CustomizeProductRequest, Result>
{
    private readonly IProductRepository _productRepository;
    private readonly ISupplierRepository _supplierRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IPromotionRepository _promotionRepository;
    private readonly ICouponRepository _couponRepository;
    private readonly IMapper _mapper;

    public ProductHandler(
        IProductRepository productRepository,
        ISupplierRepository supplierRepository, 
        ICategoryRepository categoryRepository, 
        IPromotionRepository promotionRepository, 
        ICouponRepository couponRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _supplierRepository = supplierRepository;
        _categoryRepository = categoryRepository;
        _promotionRepository = promotionRepository;
        _couponRepository = couponRepository;
        _mapper = mapper;
    }

    public async Task<Result<ProductDto>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        if (!await IsValidSupplier(request.SupplierId, cancellationToken))
            return new KeyNotFoundException(MessageExtensions.MessageNotFound("Fornecedor"));

        if (!await IsValidCategory(request.CategoryId, cancellationToken))
            return new KeyNotFoundException(MessageExtensions.MessageNotFound("Categoria", "a"));

        var product = await _productRepository.CreateProductAsync(
            new(Guid.NewGuid(), DateTime.Now, DateTime.Now, request.Name, request.Description,
            request.Color, request.ImagesUrl, request.Price, request.QuantityInStock, request.SupplierId, request.CategoryId, null, null), cancellationToken);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<Result> Handle(CustomizeProductRequest request, CancellationToken cancellationToken)
    {
        // verificar se produto existe

        if (request.PromotionId.HasValue)
            if (!await IsValidPromotion(request.PromotionId.Value, cancellationToken))
                return new(new KeyNotFoundException(MessageExtensions.MessageNotFound("Promoção", "a")));

        if (request.CouponId.HasValue)
            if (!await IsValidCoupon(request.CouponId.Value, cancellationToken))
                return new(new KeyNotFoundException(MessageExtensions.MessageNotFound("Cupom")));

        // realizar operação para customizar o produto
        return new(true);
    }

    private async Task<bool> IsValidSupplier(Guid supplierId, CancellationToken cancellationToken)
        => await _supplierRepository.GetSupplierByIdAsync(supplierId, cancellationToken) is not null;

    private async Task<bool> IsValidCategory(Guid categoryId, CancellationToken cancellationToken)
        => await _categoryRepository.GetCategoryByIdAsync(categoryId, cancellationToken) is not null;

    private async Task<bool> IsValidPromotion(Guid promotionId, CancellationToken cancellationToken)
        => await _promotionRepository.GetPromotionByIdAsync(promotionId, cancellationToken) is not null;

    private async Task<bool> IsValidCoupon(Guid couponId, CancellationToken cancellationToken)
        => await _couponRepository.CouponByIdAsync(couponId, cancellationToken) is not null;
}