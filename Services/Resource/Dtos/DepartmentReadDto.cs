using System;
namespace ResourceService.Dtos;

public class DepartmentReadDto
{
    public long Id { get; set; }
    public long MetodologiaId { get; set; }
    public long MuestraId { get; set; }
    public long DepartamentoId { get; set; }
    public long SubcategoriaId { get; set; }
    public bool Acreditado { get; set; }
    public bool Muestreo { get; set; }
    public string TipoAcreditacion { get; set; } = string.Empty;
}
