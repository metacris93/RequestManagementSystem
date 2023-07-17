using System;
using Microsoft.AspNetCore.Mvc;
using Request.API.Dtos;
using Request.API.Repositories;

namespace Request.API.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class EstadoController : ControllerBase
{
	private readonly IEstadoRepository _estadoRepository;

    public EstadoController(IEstadoRepository estadoRepository)
    {
        _estadoRepository = estadoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstadoReadDto>>> GetAllEstados()
	{
        return Ok(await _estadoRepository.GetEstadosAsync());
    }
}

