namespace Ecommerce.Sharable.Exceptions;

public class KeycloakException : Exception
{
    public KeycloakException(string message)
        : base(message) { }
}
