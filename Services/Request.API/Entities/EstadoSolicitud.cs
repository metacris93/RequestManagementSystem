using System;
using Services.Common;

namespace Request.API.Entities;

public class EstadoSolicitud : BaseEntity
{
	public long EstadoId { get; set; }
	public long SolicitudId { get; set; }
	public long LaboratorioId { get; set; }
	public long UsuarioSilabId { get; set; }
	public long UsuarioDepartamentoId { get; set; }
}
