using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Sharable.DTOs;

public class LoginDTO
{
    [Required(ErrorMessage = "{0} is required")]
    public string? Username { get; }

    [Required(ErrorMessage = "{0} is required")]
    [PasswordPropertyText]
    public string? Password { get; }
}
