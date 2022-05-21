using System.ComponentModel.DataAnnotations;

namespace FlexForm_Backend.Models;

public class RegisterRequest
{

    [Required]
    public string title { get; set; }
    [Required]
    public string first_name { get; set; }
    [Required]
    public string last_name { get; set; }
    [Required]
    public char gender { get; set; }
    [Required]
    public string username { get; set; }
    [Required]
    public string password { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public DateTime birth_date { get; set; }
    [Required]
    public string phone_number { get; set; }
    [Required]
    public string division_id { get; set; }
    [Required]
    public string role_id { get; set; }
    public bool activated { get; set; }
    public string profile_pic { get; set; }

}