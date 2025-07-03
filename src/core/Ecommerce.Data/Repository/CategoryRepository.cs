using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoryRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async Task<bool> CategoryExistsAsync(string name, CancellationToken cancelationToken) =>
        await _appDbContext.Category.AnyAsync(c => c.Name == name, cancelationToken);

    public async Task CreateAsync(Category category, CancellationToken cancelationToken)
    {
        _appDbContext.Category.Add(category);
        await _appDbContext.SaveChangesAsync(cancelationToken);
    }

    public async Task<ICollection<Category>> GetAllCategoriesAsync(CancellationToken cancelationToken) =>
        await _appDbContext.Category.ToListAsync(cancelationToken);

    public async Task DeleteAsync(Category category, CancellationToken cancelationToken)
    {
        _appDbContext.Category.Remove(category);
        await _appDbContext.SaveChangesAsync(cancelationToken);
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken cancelationToken)
        => await _appDbContext.Category
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync(cancelationToken);
}
