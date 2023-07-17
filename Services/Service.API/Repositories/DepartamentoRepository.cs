using System;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Service.API.Data;
using Service.API.Dtos;

namespace Service.API.Repositories;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly SqlServerContext _dbContext;
    private readonly IMapper _mapper;

    public DepartamentoRepository(SqlServerContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DepartamentoReadDto>> GetDepartamentosAsync()
    {
        var data = await _dbContext.Departamentos.ToListAsync();
        var dto = _mapper.Map<IEnumerable<DepartamentoReadDto>>(data);
        return dto;
    }
}

