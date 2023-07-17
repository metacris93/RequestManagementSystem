using System;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Request.API.Data;
using Request.API.Dtos;

namespace Request.API.Repositories;

public class EstadoRepository : IEstadoRepository
{
    private readonly SqlServerContext _dbContext;
    private readonly IMapper _mapper;

    public EstadoRepository(SqlServerContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EstadoReadDto>> GetEstadosAsync()
    {
        var data = await _dbContext.Estados.ToListAsync();
        var dto = _mapper.Map<IEnumerable<EstadoReadDto>>(data);
        return dto;
    }
}

