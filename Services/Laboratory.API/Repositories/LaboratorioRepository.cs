using System;
using Laboratory.API.Data;
using Laboratory.API.Dtos;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.API.Repositories;

public class LaboratorioRepository : ILaboratorioRepository
{
    private readonly SqlServerContext _dbContext;
    private readonly IMapper _mapper;

    public LaboratorioRepository(SqlServerContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LaboratorioReadDto>> GetLaboratoriosAsync()
    {
        var data = await _dbContext.Laboratorios.ToListAsync();
        var dto = _mapper.Map<IEnumerable<LaboratorioReadDto>>(data);
        return dto;
    }
}

