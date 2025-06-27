namespace Ecommerce.Sharable.Config;

[AttributeUsage(AttributeTargets.Class)]
public class SwaggerSchemaName : Attribute
{
    public string Name { get; }
    public SwaggerSchemaName(string name) => Name = name;
}
