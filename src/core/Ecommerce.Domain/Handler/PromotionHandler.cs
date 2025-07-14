using AutoMapper;
using Ecommerce.Domain.Interface;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Dto;
using Ecommerce.Sharable.Request.Promotion;
using MediatR;

namespace Ecommerce.Domain.Handler;

public class PromotionHandler
    : IRequestHandler<CreatePromotionRequest, Result<PromotionDto>>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private const string PRODUCT_NOT_FOUND = "Produto não encontrado!";

    public PromotionHandler(
        IPromotionRepository promotionRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _promotionRepository = promotionRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Result<PromotionDto>> Handle(CreatePromotionRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(request.ProductId, cancellationToken);
        if (product is null)
            return new KeyNotFoundException(PRODUCT_NOT_FOUND);

        var promotion = await _promotionRepository.CreatePromotionAsync(
            new(Guid.NewGuid(), DateTime.Now, DateTime.Now, request.IsPromotion, request.DiscountPercentage, request.PromotionStartsIn, request.ValidUntil, request.ProductId)
                { Product = product }, cancellationToken);
        return _mapper.Map<PromotionDto>(promotion);
    }
}