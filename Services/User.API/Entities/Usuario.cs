using System;
using Services.Common;

namespace User.API.Entities;

public class Usuario : BaseEntity
{
	public string Nombres { get; set; }
	public string Apellidos { get; set; }
	public DateTime FechaNacimiento { get; set; }
	public string Genero { get; set; }
	public string Identificacion { get; set; }
	public long RolId { get; set; }
	public string Correo { get; set; }
	public string Password { get; set; }
}

