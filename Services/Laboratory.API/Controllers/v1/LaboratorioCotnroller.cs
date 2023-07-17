using System;
using Laboratory.API.Dtos;
using Laboratory.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Laboratory.API.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class LaboratorioCotnroller : ControllerBase
{
    private readonly ILaboratorioRepository _laboratorioRepository;

    public LaboratorioCotnroller(ILaboratorioRepository laboratorioRepository)
    {
        _laboratorioRepository = laboratorioRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LaboratorioReadDto>>> GetAllEstados()
    {
        return Ok(await _laboratorioRepository.GetLaboratoriosAsync());
    }
}

