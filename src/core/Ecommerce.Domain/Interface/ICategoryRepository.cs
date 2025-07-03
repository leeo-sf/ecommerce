using Ecommerce.Domain.Entity;

namespace Ecommerce.Domain.Interface;

public interface ICategoryRepository
{
    Task CreateAsync(Category category, CancellationToken cancelationToken);
    Task<bool> CategoryExistsAsync(string name, CancellationToken cancelationToken);
    Task<ICollection<Category>> GetAllCategoriesAsync(CancellationToken cancelationToken);
    Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken cancelationToken);
    Task DeleteAsync(Category category, CancellationToken cancelationToken);
}
