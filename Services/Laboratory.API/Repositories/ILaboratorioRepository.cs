using System;
using Laboratory.API.Dtos;

namespace Laboratory.API.Repositories;

public interface ILaboratorioRepository
{
    public Task<IEnumerable<LaboratorioReadDto>> GetLaboratoriosAsync();
}

