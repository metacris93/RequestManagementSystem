using System;
using ResourceService.Models;

namespace ResourceService.Data;

public interface IDepartmentRepository
{
    bool SaveChanges();
    IEnumerable<Department> GetAllDepartments();
    Department GetDepartmentById(long id);
}

