using System;
namespace RequestService.Dtos;

public class RequestReadDto
{
    public long Id { get; set; }
    public long ServicioId { get; set; }
    public long SubCategoriaServicioId { get; set; }
    public long MetodologiaId { get; set; }
    public long MuestraId { get; set; }
    public long ClienteId { get; set; }
    public long EstadoId { get; set; }
    public long LaboratorioAsignadoId { get; set; }
    public bool Acreditado { get; set; }
    public bool Muestreo { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public DateTime FechaFinalizacion { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

