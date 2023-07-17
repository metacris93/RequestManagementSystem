using System;
using Services.Common;

namespace Service.API.Entities;

public class Muestra : BaseEntity
{
	public string Nombre { get; set; }
	public string Descripcion { get; set; }
}

