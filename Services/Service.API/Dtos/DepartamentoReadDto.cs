using System;
namespace Service.API.Dtos;

public class DepartamentoReadDto
{
    public bool Acreditado { get; set; }
    public bool Muestreo { get; set; }
    public string TipoAcreditacion { get; set; }
}

