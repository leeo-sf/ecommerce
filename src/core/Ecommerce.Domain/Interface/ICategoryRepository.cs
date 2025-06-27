using Ecommerce.Domain.Entity;

namespace Ecommerce.Domain.Interface;

public interface ICategoryRepository
{
    Task CreateAsync(Category category);
    Task<bool> CategoryExistsAsync(string name);
    Task<ICollection<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(Guid id);
    Task DeleteAsync(Category category);
}
