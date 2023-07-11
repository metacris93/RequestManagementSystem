namespace RequestService.Data;

using Microsoft.EntityFrameworkCore;
using RequestService.Models;

public class AppDbContext : DbContext
{
  public DbSet<Request> Requests { get; set; } = null!;
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
    
  }
}
