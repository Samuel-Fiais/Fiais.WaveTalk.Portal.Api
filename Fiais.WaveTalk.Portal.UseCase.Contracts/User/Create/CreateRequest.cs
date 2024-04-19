using System.ComponentModel.DataAnnotations;
using Fiais.WaveTalk.Portal.Application.Extensions;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;

public sealed record CreateRequest
{
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;
    
    [MinLength(8, ErrorMessage = "Password must have at least 8 characters.")]
    public string Password { get; set; } = string.Empty;
    
    public void Format()
    {
        Username = Username.Trim().ToLower();
        Email = Email.Trim().ToLower();
        Name = Name.Trim();
        Password = Password.Trim().Encrypt();
    }
}