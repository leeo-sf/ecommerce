namespace Ecommerce.Sharable.Extensions;

public static class MessageExtensions
{
    public static string MessageNotFound(string objNameNotFound, string gender = "o")
        => $"{char.ToUpper(objNameNotFound[0]) + objNameNotFound[1..].ToLower()} não encontrad{gender.Trim().ToLower()}!";
}