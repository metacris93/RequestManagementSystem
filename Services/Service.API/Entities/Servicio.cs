using System;
using Services.Common;

namespace Service.API.Entities;

public class Servicio : BaseEntity
{
	public string Nombre { get; set; }
	public string Descripcion { get; set; }
	public string Imagen { get; set; }
}

