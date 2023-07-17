using System;
using Service.API.Dtos;

namespace Service.API.Repositories;

public interface IDepartamentoRepository
{
    public Task<IEnumerable<DepartamentoReadDto>> GetDepartamentosAsync();
}

