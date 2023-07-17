using System;
using Services.Common;

namespace Request.API.Entities;

public class Solicitud : BaseEntity
{
	public long ServicioId { get; set; }
	public long MetodologiaId { get; set; }
	public long ParametroId { get; set; }
	public long MuestraId { get; set; }
	public long ClienteId { get; set; }
	public long LaboratorioAsignadoId { get; set; }
	public bool Acreditado { get; set; }
	public bool Muestreo { get; set; }
	public string Descripcion { get; set; } = string.Empty;
	public int Estado { get; set; }
	public DateTime FechaFinalizacion { get; set; }
}

