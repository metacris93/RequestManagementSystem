using User.API.Entities;

namespace User.API.Service.IService;

public interface IJwtTokenGenerator
{
    string GenerateToken(Usuario user, IEnumerable<string> roles);
}
