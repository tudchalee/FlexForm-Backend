namespace FlexForm_Backend.Models;
public class AuthenticateResponse
{
    public Guid employee_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string username { get; set; }
    public string Token { get; set; }
}