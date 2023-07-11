using System;
using System.Text.Json;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using ResourceService.Data;
using ResourceService.Dtos;

namespace ResourceService.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _repository;
    private readonly IMapper _mapper;

    public DepartmentController(IDepartmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DepartmentReadDto>> GetAllDepartments()
    {
        var requests = _repository.GetAllDepartments();
        Console.WriteLine(JsonSerializer.Serialize(requests));
        var dto = _mapper.Map<IEnumerable<DepartmentReadDto>>(requests);
        return Ok(dto);
    }
}

