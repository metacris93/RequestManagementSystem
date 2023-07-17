using System;
using Services.Common;

namespace Laboratory.API.Entities;

public class Laboratorio : BaseEntity
{
	public string Nombre { get; set; }
	public string Descripcion { get; set; }
	public string Imagen { get; set; }
}
