using System;
using Microsoft.EntityFrameworkCore;
using ResourceService.Models;

namespace ResourceService.Data;

public class AppDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; } = null!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}

