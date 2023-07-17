using System;
using Request.API.Dtos;

namespace Request.API.Repositories;

public interface IEstadoRepository
{
    Task<IEnumerable<EstadoReadDto>> GetEstadosAsync();
}

