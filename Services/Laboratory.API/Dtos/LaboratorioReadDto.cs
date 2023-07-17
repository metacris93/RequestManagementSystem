using System;
namespace Laboratory.API.Dtos;

public class LaboratorioReadDto
{
	public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Imagen { get; set; } = string.Empty;
}

