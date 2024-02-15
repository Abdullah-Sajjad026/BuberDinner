using System.ComponentModel.DataAnnotations;

namespace BuberDinner.Contracts.Authentication;

public class RegisterRequest
{
    [Required]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public required string FirstName { get; set; }
    [Required]
    public required string LastName { get; set; }
}