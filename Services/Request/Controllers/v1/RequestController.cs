using System;
using System.Text.Json;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using RequestService.Data;
using RequestService.Dtos;

namespace RequestService.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IRequestRepository _repository;
    private readonly IMapper _mapper;

    public RequestController(IRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    //[HttpPost]
    //public IActionResult Create()
    //{
    //    return Ok("-- OK --");
    //}

    [HttpGet]
    public ActionResult<IEnumerable<RequestReadDto>> GetAllRequests()
    {
        var requests = _repository.GetAllRequests();
        Console.WriteLine(JsonSerializer.Serialize(requests));
        var dto = _mapper.Map<IEnumerable<RequestReadDto>>(requests);
        return Ok(dto);
    }
}

