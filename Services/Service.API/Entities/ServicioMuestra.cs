using System;
using Services.Common;

namespace Service.API.Entities;

public class ServicioMuestra : BaseEntity
{
	public long ServicioId { get; set; }
	public long MuestraId { get; set; }
}
