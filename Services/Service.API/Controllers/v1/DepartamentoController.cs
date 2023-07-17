using System;
using Microsoft.AspNetCore.Mvc;

namespace Service.API.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class DepartamentoController : ControllerBase
{
	public DepartamentoController()
	{
	}
}

