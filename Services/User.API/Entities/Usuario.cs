using Microsoft.AspNetCore.Identity;

namespace User.API.Entities;

public class Usuario : IdentityUser
{
	public string Name { get; set; }
	public string LastName { get; set; }
	public DateTime? BirthDate { get; set; }
	public string Gender { get; set; }
	public string Identification { get; set; }
	public string Email { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

