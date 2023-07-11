using System;
using ResourceService.Models;

namespace ResourceService.Data;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;
    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _context.Departments.ToList();
    }

    public Department GetDepartmentById(long id)
    {
        return _context.Departments.FirstOrDefault(x => x.Id == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}

