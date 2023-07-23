namespace User.API.Dtos; 
public class UserDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public string Identification { get; set; }
}
