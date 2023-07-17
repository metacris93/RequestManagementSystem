using System;
using Services.Common;

namespace Service.API.Entities;

public class ParametroServicio : BaseEntity
{
	public string Nombre { get; set; }
	public string Descripcion { get; set; }
	public long ServicioId { get; set; }
}

