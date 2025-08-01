﻿using AutoMapper;
using Ecommerce.Domain.Interface;
using Ecommerce.Sharable;
using Ecommerce.Sharable.Exceptions;
using Ecommerce.Sharable.Request.Category;
using Ecommerce.Sharable.Dto;
using MediatR;

namespace Ecommerce.Domain.Handler;

public class CategoryHandler
    : IRequestHandler<CategoryRequest, Result>,
        IRequestHandler<QueryCategoriesRequest, Result<ICollection<CategoryDto>>>,
        IRequestHandler<DeleteCategoryRequest, Result>,
        IRequestHandler<GetCategoryByIdRequest, Result<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepo;
    private readonly IMapper _mapper;

    public CategoryHandler(ICategoryRepository categoryService, IMapper mapper)
    {
        _categoryRepo = categoryService;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CategoryRequest request, CancellationToken cancellationToken)
    {
        var categoryExists = await _categoryRepo.CategoryExistsAsync(request.Name, cancellationToken);
        if (categoryExists)
            return new(new AppException($"Categoria {request.Name} já existe!"));
        await _categoryRepo.CreateAsync(new(request), cancellationToken);
        return new(true);
    }

    public async Task<Result<ICollection<CategoryDto>>> Handle(QueryCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepo.GetAllCategoriesAsync(cancellationToken);
        return new(_mapper.Map<ICollection<CategoryDto>>(categories));
    }

    public async Task<Result> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepo.GetCategoryByIdAsync(request.id, cancellationToken);
        if (category is null)
            return new(new KeyNotFoundException("Categoria não encontrada!"));
        await _categoryRepo.DeleteAsync(category, cancellationToken);
        return new(true);
    }

    public async Task<Result<CategoryDto>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepo.GetCategoryByIdAsync(request.id, cancellationToken);
        if (category is null)
            return new(new KeyNotFoundException("Categoria não encontrada!"));
        return new(_mapper.Map<CategoryDto>(category));
    }
}
