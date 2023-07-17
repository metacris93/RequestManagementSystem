using System;
using Services.Common;

namespace Service.API.Entities;

public class Departamento : BaseEntity
{
	public long ServicioId { get; set; }
	public long MetodologiaId { get; set; }
	public long MuestraId { get; set; }
	public long LaboratorioId { get; set; }
	public long ParametroId { get; set; }
	public bool Acreditado { get; set; }
	public bool Muestreo { get; set; }
	public string TipoAcreditacion { get; set; }
}

