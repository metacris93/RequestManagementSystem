using System;
using Services.Common;

namespace Service.API.Entities;

public class ServicioMetodologia : BaseEntity
{
	public long ServicioId { get; set; }
	public long MetodologiaId { get; set; }
}

