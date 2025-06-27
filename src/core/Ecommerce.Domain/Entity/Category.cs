using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity;

[Table("category_table")]
public sealed class Category : BaseEntity
{
    public string Name { get; private set; }

    public Category(string name)
    {
        Name = name;
    }

    public Category(Guid id, string name)
        : base(id) { }
}
