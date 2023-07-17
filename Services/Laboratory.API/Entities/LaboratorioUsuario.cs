using System;
using Services.Common;

namespace Laboratory.API.Entities;

public class LaboratorioUsuario : BaseEntity
{
	public long LaboratorioId { get; set; }
	public long UsuarioId { get; set; }
}

