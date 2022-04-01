using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace FlexForm_Backend.Models;

public class ShowEditUser
{
    public Guid employee_id { get; set; }
    public string title { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public char gender { get; set; }
    [Key]
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public DateTime birth_date { get; set; }
    public string phone_number { get; set; }
    public string division_id { get; set; }
    public string role_id { get; set; }
    public bool activated { get; set; }
    public string profile_pic { get; set; }
}