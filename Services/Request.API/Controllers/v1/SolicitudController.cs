using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common;

namespace Request.API.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class SolicitudController : ControllerBase
{
    [HttpGet()]
    public IActionResult GetAllRequest()
    {
        return new OkObjectResult("VERSION 1");
    }
}

