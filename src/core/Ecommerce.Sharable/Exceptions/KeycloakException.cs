using Ecommerce.Sharable.DTOs;
using System.Text.Json;

namespace Ecommerce.Sharable.Exceptions;

public class KeycloakException : Exception
{
    public KeycloakException(string message)
        : base(message) { }
}
