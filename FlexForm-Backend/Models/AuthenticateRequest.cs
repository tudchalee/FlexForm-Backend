namespace FlexForm_Backend.Models;

using System.ComponentModel.DataAnnotations;

public class AuthenticateRequest
{
    [Required]
    public string username { get; set; }

    [Required]
    public string password { get; set; }
}