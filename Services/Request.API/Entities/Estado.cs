using System;
using Services.Common;

namespace Request.API.Entities;

public class Estado : BaseEntity
{
	public string Nombre { get; set; } = string.Empty;
}

