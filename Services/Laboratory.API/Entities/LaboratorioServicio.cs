using System;
using Services.Common;

namespace Laboratory.API.Entities;

public class LaboratorioServicio : BaseEntity
{
	public long DepartamentoId { get; set; }
	public long ServicioId { get; set; }
	public string Tipo { get; set; }
}
