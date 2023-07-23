using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Common.Dto;
using User.API.Data;
using User.API.Dtos;
using User.API.Entities;
using User.API.Service.IService;

namespace User.API.Service;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly SqlServerContext _db;
    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(SqlServerContext db, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    {
        _db = db;
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ApiResponse<string>> AssignRole(AssignRoleRequestDto assignRoleRequestDto)
    {
        var user = await _db.Usuarios.FirstAsync(u => u.Email.ToLower() == assignRoleRequestDto.Email.ToLower());
        if (user is null)
        {
            return new ApiResponse<string>("usuario no encontrado");
        }
        if (! await _roleManager.RoleExistsAsync(assignRoleRequestDto.Role))
        {
            await _roleManager.CreateAsync(new IdentityRole(assignRoleRequestDto.Role));
            await _userManager.AddToRoleAsync(user, assignRoleRequestDto.Role);
            return new ApiResponse<string>("rol asignado", true);
        }
        return new ApiResponse<string>("rol asignado", true);
    }

    public async Task<ApiResponse<LoginResponseDto>> Login(LoginRequestDto loginRequestDto)
    {
        var user = _db.Usuarios.First(u => u.Email.ToLower() == loginRequestDto.Email.ToLower());
        bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
        if (user is null || !isValid)
        {
            return new ApiResponse<LoginResponseDto>("Correo o contraseña incorrecto");
        }
        var dto = _mapper.Map<UserDto>(user);
        var roles = await _userManager.GetRolesAsync(user);
        var res = new LoginResponseDto
        {
            User = dto,
            Token = _jwtTokenGenerator.GenerateToken(user, roles),
        };
        return new ApiResponse<LoginResponseDto>(res);
    }

    public async Task<ApiResponse<UserDto>> Register(RegistrationRequestDto registrationRequestDto)
    {
        Usuario user = new()
        {
            UserName = registrationRequestDto.Email,
            NormalizedUserName = registrationRequestDto.Email.ToUpper(),
            Email = registrationRequestDto.Email,
            BirthDate = registrationRequestDto.BirthDate,
            Gender = registrationRequestDto.Gender,
            Name = registrationRequestDto.Name,
            LastName = registrationRequestDto.LastName,
            Identification = registrationRequestDto.Identification,
            NormalizedEmail = registrationRequestDto.Email.ToUpper(),
        };
        try
        {
            var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
            if (result.Succeeded)
            {
                var userToReturn = _db.Usuarios.First(u => u.Email.ToLower() == registrationRequestDto.Email.ToLower());
                var dto = _mapper.Map<UserDto>(userToReturn);
                return new ApiResponse<UserDto>(dto);
            }
            var errors = result.Errors.ToDictionary(
                kvp => kvp.Code,
                kvp => kvp.Description
            );
            return new ApiResponse<UserDto>("No se pudo registrar el usuario", errors);
        }
        catch (Exception e)
        {
            return new ApiResponse<UserDto>(e.ToString());
        }
    }
}
