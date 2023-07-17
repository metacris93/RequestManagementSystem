using System;
using Services.Common;

namespace Service.API.Entities;

public class Metodologia : BaseEntity
{
	public string Nombre { get; set; }
	public string Descripcion { get; set; }
}

