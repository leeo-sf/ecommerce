using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Data.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoryRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async Task<bool> CategoryExistsAsync(string name) =>
        await _appDbContext.Category.AnyAsync(c => c.Name == name);

    public async Task CreateAsync(Category category)
    {
        _appDbContext.Category.Add(category);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<ICollection<Category>> GetAllCategoriesAsync() =>
        await _appDbContext.Category.ToListAsync();

    public async Task DeleteAsync(Category category)
    {
        _appDbContext.Category.Remove(category);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id)
        => await _appDbContext.Category
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
}
